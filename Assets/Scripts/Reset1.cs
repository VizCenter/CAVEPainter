using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset1 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (getReal3D.Input.GetButtonDown("Reset"))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
