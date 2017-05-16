using ParticlePlayground;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerBehaviour : NetworkBehaviour
{
    public class SyncListVector : SyncListStruct<Vector3> { }

    public PlaygroundParticlesC brush1;
    public GameObject brush1_;
    public GameObject bulletPrefab;
    public SyncListVector points = new SyncListVector();
    public string currentBrush;
    public string _fire = "Fire";
    
    private bool painting = false;

    #region Properties

    public bool Painting
    {
        get
        {
            return painting;
        }

        set
        {
            painting = value;
        }
    }

    #endregion Properties

    // Use this for initialization
    void Start ()
    {
        name = "Player_" + netId;
        this.transform.position = new Vector3(0, 0.5f, 0);
        this.transform.tag = isLocalPlayer ? "LocalPlayer" : "RemotePlayer";
        Debug.Log("PlayerBehaviour Start: " + name + " position: " + this.transform.position + " tag: " + this.transform.tag);

        if (!isLocalPlayer)
            return;

        this.transform.parent = GameObject.Find("Hand").transform;
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update ()
    {
        if (!isLocalPlayer)
            return;

        if (getReal3D.Input.GetButtonDown(_fire))
        {
            CmdFire();
        }
    }

    /// <summary>
    /// Command function to instantiate the brush.
    /// This will spawn the new brush in the server and from there it will be created on the clients connected.
    /// This method is called on the client and run on the server.
    /// </summary>
    /// <param name="position">Initial position of the brush.</param>
    /// <param name="emiting">Determines if the emitting script (Update method) should be automatically executed. If not, call the CmdEmit method directly.</param>
    [Command]
    public void CmdCreateBrush(Vector3 position, bool emiting)
    {
        var brush = (GameObject)Instantiate(brush1_, position, Quaternion.identity);
        var behaviour = brush.transform.GetComponent<BrushBehaviour>();
        
        behaviour.PlayerID = GetPlayerID();
        behaviour.brushName = "Brush_" + netId;
        behaviour.emiting = emiting;

        // Spawn the object to the server.
        NetworkServer.Spawn(brush);

        // Change the player color to identify the local player from the others.
        brush.GetComponent<PlaygroundParticlesC>().lifetimeColor.SetKeys(new GradientColorKey[]
                                                                        { new GradientColorKey(Color.red, 0.0f),
                                                                            new GradientColorKey(Color.red, 1.0f) },
                                                                   new GradientAlphaKey[]
                                                                        { new GradientAlphaKey(1.0f, 0.0f),
                                                                            new GradientAlphaKey(0.0f, 1.0f) });

        Painting = true;
    }

    /// <summary>
    /// Command function to instantiate a bullet.
    /// This method is called on the client and run on the server.
    /// </summary>
    [Command]
    private void CmdFire()
    {
        Debug.Log("PlayerBehaviour CmdFire");
        var bullet = (GameObject)Instantiate(bulletPrefab, transform.position - transform.forward, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = -transform.forward * 4;

        NetworkServer.Spawn(bullet);

        Destroy(bullet, 0.5f);
    }

    /// <summary>
    /// Command function to emit the brush position to the server.
    /// This method is called on the client and run on the server.
    /// </summary>
    /// <param name="brush">Brush to update.</param>
    [Command]
    public void CmdEmit(string brush)
    {
        RpcEmit(brush);
    }

    /// <summary>
    /// Remote Procedure Call to emit the position of the brush to be updated on each connected client.
    /// This method is called on the server and run on the clients.
    /// </summary>
    /// <param name="brush">Brush to update.</param>
    [ClientRpc]
    void RpcEmit(string brush)
    {
        if (GameObject.Find(brush) == null)
        {
            return;
        }

        EmitWhileMoving currentEmit = GameObject.Find(brush).GetComponent<EmitWhileMoving>();

        if (currentEmit == null)
        {
            Debug.Log("currentEmit is null");
            return;
        }

        GameObject.Find(brush).transform.GetComponent<BrushBehaviour>().handPosition = this.transform.position;
        currentEmit.Emit();
    }

    /// <summary>
    /// Command function to emit the brush position to the server.
    /// This method is called on the client and run on the server.
    /// </summary>
    /// <param name="brush">Brush to update.</param>
    /// <param name="position">Current position of the draw.</param>
    [Command]
    public void CmdEmitPosition(string brush, Vector3 position)
    {
        RpcEmitPosition(brush, position);
    }

    /// <summary>
    /// Remote Procedure Call to emit the position of the brush to be updated on each connected client.
    /// This method is called on the server and run on the clients.
    /// </summary>
    /// <param name="brush">Brush to update.</param>
    /// <param name="position">Current position of the draw.</param>
    [ClientRpc]
    void RpcEmitPosition(string brush, Vector3 position)
    {
        if (GameObject.Find(brush) == null)
        {
            return;
        }

        EmitWhileMoving currentEmit = GameObject.Find(brush).GetComponent<EmitWhileMoving>();

        if (currentEmit == null)
        {
            Debug.Log("currentEmit is null");
            return;
        }

        GameObject.Find(brush).transform.GetComponent<BrushBehaviour>().handPosition = position;
        currentEmit.Emit();
    }

    /// <summary>
    /// Function that return the player ID (unique).
    /// </summary>
    /// <returns>Player ID.</returns>
    public string GetPlayerID()
    {
        return name;
    }
}
