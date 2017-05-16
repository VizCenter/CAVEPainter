using UnityEngine;
using ParticlePlayground;

public class InstantiateBrush : MonoBehaviour
{

    public PlaygroundParticlesC brush1;
    public PlaygroundParticlesC brush2;
    public PlaygroundParticlesC brush3;
    public GameObject menu;
    public int numberOfBrushes;
    public string wandButton = "WandButton";
    public string keyCode = "1";

    public static bool canStart;
    public static int selection;

    private Vector3 previous;

    PlayerBehaviour brushPlayer;

    // Use this for initialization
    void Start()
    {
        selection = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(brushPlayer == null && GameObject.FindGameObjectWithTag("LocalPlayer") != null)
            brushPlayer = GameObject.FindGameObjectWithTag("LocalPlayer").GetComponent<PlayerBehaviour>();

        if (brushPlayer == null)
            return;

        canStart = menu.activeInHierarchy;

        if ((getReal3D.Input.GetButtonDown(wandButton) || Input.GetKeyDown(keyCode)) && !canStart)
        {
            if (!Menu.selecting)
            {
                if (selection == 1)
                {
                    Instantiate(brush1);
                }
                if (selection == 2)
                {
                    Instantiate(brush2);
                }
                if (selection == 3)
                {
                    Instantiate(brush3);
                }
            }
        }
    }

    void Instantiate(PlaygroundParticlesC brush)
    {
        brushPlayer.CmdCreateBrush(this.transform.position, true);
    }
}
