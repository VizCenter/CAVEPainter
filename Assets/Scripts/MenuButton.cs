using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{

    private Color originalColor;
    private Renderer rend;
    public int level = 0;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Pointer")
        {
            rend.material.color = Color.red;
        }
    }

    void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "Pointer")
        {
            if (getReal3D.Input.GetButtonDown("WandButton"))
            {
                SceneManager.LoadScene(level);
            }
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Pointer")
        {
            rend.material.color = originalColor;
        }
    }
}
