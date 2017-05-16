using UnityEngine;

public class CopyPasta : MonoBehaviour
{

    public GameObject cloneTarget;
    private Renderer rend;
    private Color color;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        color = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (getReal3D.Input.GetButtonDown("WandButton"))
        {
            if (cloneTarget != null)
            {
                getRealDisplayScreens.Instantiate(cloneTarget, this.transform.position, this.transform.rotation);
            }
        }
    }

    void OnTriggerStay(Collider coll)
    {

        rend.material.color = Color.red;
        cloneTarget = coll.gameObject;
    }

    void OnTriggerExit(Collider coll)
    {
        rend.material.color = color;
    }
}
