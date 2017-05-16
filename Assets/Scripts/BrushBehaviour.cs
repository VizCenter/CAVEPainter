using UnityEngine;
using UnityEngine.Networking;

public class BrushBehaviour : NetworkBehaviour
{
    public bool emiting = false;

    [SyncVar]
    public Vector3 handPosition;

    [SyncVar]
    public string playerID;

    [SyncVar]
    public string brushName;
    
    #region Properties

    public string PlayerID
    {
        get
        {
            return playerID;
        }

        set
        {
            playerID = value;
        }
    }

    #endregion Properties

    // Use this for initialization
    void Start ()
    {
        name = brushName + "_" + netId;
        this.transform.position = GameObject.Find(PlayerID).transform.position;

        GameObject.Find(PlayerID).GetComponent<PlayerBehaviour>().currentBrush = name;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
