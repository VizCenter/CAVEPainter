using Leap.Unity;
using UnityEngine;

public class LeapMotionBehaviour : MonoBehaviour
{
    public string currentBrush;

    [SerializeField]
    private PinchDetector[] pinchDetectors;

    private PlayerBehaviour brushPlayer;
    private Vector3 previousPosition;

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (brushPlayer == null && GameObject.FindGameObjectWithTag("LocalPlayer") != null)
            brushPlayer = GameObject.FindGameObjectWithTag("LocalPlayer").GetComponent<PlayerBehaviour>();

        if (brushPlayer == null)
            return;

        for (int i = 0; i < pinchDetectors.Length; i++)
        {
            var detector = pinchDetectors[i];

            if (detector.DidStartPinch)
            {
                brushPlayer.CmdCreateBrush(this.transform.position, false);
                currentBrush = brushPlayer.currentBrush;
            }

            if (detector.DidEndPinch)
            {
                currentBrush = null;
            }

            if (detector.IsPinching)
            {
                Paint(detector.Position);
            }
        }
    }

    /// <summary>
    /// Paint method that send the position data to the brush to update the draw.
    /// </summary>
    /// <param name="position">Position of the pinch detector.</param>
    private void Paint(Vector3 position)
    {
        // Validate if the current point was already added.
        if (Mathf.Approximately(position.magnitude, previousPosition.magnitude))
            return;

        // Validate if there is a current brush to paint.
        if (string.IsNullOrEmpty(currentBrush))
        {
            currentBrush = brushPlayer.currentBrush;
            return;
        }

        // Call the Command method to execute this in the server.
        brushPlayer.CmdEmitPosition(currentBrush, position);

        previousPosition = position;
    }
}
