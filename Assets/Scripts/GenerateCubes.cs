using UnityEngine;
using System.Collections;
using getReal3D;

public class GenerateCubes : MonoBehaviour {

	private Renderer display;
	public Texture transparent;
	public Texture solid;
	public bool placed;
	//private GameObject paintbrush;

	// Use this for initialization
	void Start () {
		//paintbrush = GameObject.FindGameObjectWithTag ("Paintbrush");
	
	}
	void Awake ()
	{
		MergeMesh.cubes.Add (gameObject);
		display = GetComponent<Renderer>();
		display.enabled = false;
		display.material.mainTexture = transparent;
		placed = false;
	}
	

	void Update () {

		if (getReal3D.Input.GetButtonDown ("ChangeWand"))
		{
			display.enabled = placed;
		}

	}

	void OnTriggerStay(Collider coll)
	{
		if (coll.gameObject.tag == "Hand") {// && paintbrush.activeInHierarchy == false)

			display.enabled = true;

			if (getReal3D.Input.GetButton ("WandButton")) {
				placed = true;
				display.material.mainTexture = solid;
			}
			if (getReal3D.Input.GetButton ("Jump")) {
				placed = false;
				display.material.mainTexture = transparent;
				display.enabled = false;
				display.material.color = Color.gray;
			}

		}
//		else 
//		{
//			display.enabled = placed;
//		}
	}

	void OnTriggerExit(Collider coll)
	{
//		if (placed == false)//coll.gameObject.tag == "Hand" && placed == false) 
//		{
//			display.enabled = false;
//		}
		display.enabled = placed;
	}
}
