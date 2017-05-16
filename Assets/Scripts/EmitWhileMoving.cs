using UnityEngine;
using PlaygroundSplines;

public class EmitWhileMoving : MonoBehaviour
{
    public PlaygroundSpline spline;
    public GameObject player;
    private int pos;
    private bool placed;
    private bool removed;
    public GameObject selectionBox;
    public BoxCollider boxCollider;
    public string wandButton = "WandButton";
    public string keyCode = "1";
    public float gapDistance = 0.01f;

    private Vector3 previous;
    private Vector3 currentCenter;
    
    private BrushBehaviour brush;
    private PlayerBehaviour brushPlayer;

    // Use this for initialization
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        player = GameObject.FindGameObjectWithTag("Player");
        selectionBox = Menu.selectionBox;
        placed = selectionBox.activeInHierarchy;
        removed = selectionBox.activeInHierarchy;
        
        spline = GetComponentInChildren<PlaygroundSpline>();
        pos = 1;

        brush = this.transform.GetComponent<BrushBehaviour>();
        brushPlayer = GameObject.Find(brush.PlayerID).transform.GetComponent<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        // Validate if the emit should be executed automatically.
        if(brush.emiting)
            brushPlayer.CmdEmit(this.transform.name);
    }

    /// <summary>
    /// Emits the current drawing process. 
    /// Take the current brush position and update the list of points where the paint has been done.
    /// </summary>
    public void Emit()
    {
        Vector3 handPosition = brush.handPosition;

        // Validate if the current point was already added. (Not working here.)
        if (handPosition == previous)
            return;

        if (Vector3.Distance(handPosition, previous) > gapDistance && !placed && !InstantiateBrush.canStart)
        {
            pos = spline.ControlPointCount - 1;
            spline.SetControlPoint(pos, handPosition - this.transform.position);
            spline.AddNode();
            previous = handPosition;
        }

        if (spline.ControlPointCount > 2 && !removed)
        {
            for (int i = 0; i < 2; i++)
            {
                spline.RemoveFirst();
            }

            removed = true;
        }

        currentCenter = new Vector3(transform.position.x + ((spline.GetControlPoint(0).x + spline.GetControlPoint(spline.ControlPointCount - 2).x) * 0.5f),
                                     transform.position.y + ((spline.GetControlPoint(0).y + spline.GetControlPoint(spline.ControlPointCount - 2).y) * 0.5f),
                                     transform.position.z + ((spline.GetControlPoint(0).z + spline.GetControlPoint(spline.ControlPointCount - 2).z) * 0.5f)) - this.transform.position;

        boxCollider.center = currentCenter;

        if (/*getReal3D.Input.GetButtonUp(wandButton) || */Input.GetKeyDown(keyCode))
        {
            if (selectionBox.activeInHierarchy && !placed)
            {
                spline.RemoveLast();
            }

            placed = true;
        }
    }
}
