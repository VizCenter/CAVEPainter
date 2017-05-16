using UnityEngine;
using System.Collections;
using getReal3D;

public class Reset : MonoBehaviour {

	public GameObject cursor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (getReal3D.Input.GetButtonDown ("Reset")) 
		{
			cursor.transform.localScale = new Vector3(0.01f,0.01f,0.01f);

//			foreach(GameObject go in GameObject.FindGameObjectsWithTag("cube")) 
//			{
//				go.GetComponent<Renderer>().enabled = false; //or some such shit
//			}

			//Application.LoadLevel(Application.loadedLevel);
		}
	}
}
