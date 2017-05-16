using Leap;
using UnityEngine;

public class ControllersBehaviour : MonoBehaviour
{
    public GameObject leapContainer;

    private Controller controller;
    private string _quit = "Quit";

    // Use this for initialization
    void Start ()
    {
        controller = new Controller();
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Quit the game when the Quit button is pressed.
        if (getReal3D.Input.GetButtonDown(_quit))
        {
            AppHelper.Quit();
        }

        // Validate if the Leap Motion controller is connected to enable the component.
        if (!controller.IsConnected)
        {
            if (leapContainer.activeInHierarchy)
                leapContainer.SetActive(false);
        }
        else
        {
            if (!leapContainer.activeInHierarchy)
            {
                leapContainer.SetActive(true);
                Debug.Log("Leap Motion Controller found!");
            }
        }
    }
}
