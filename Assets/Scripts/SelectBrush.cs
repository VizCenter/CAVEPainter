using UnityEngine;
using System.Collections;

public class SelectBrush : MonoBehaviour {

	private Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll)
	{
		//Debug.Log ("Colliding");
		rend.material.color = coll.GetComponent<Renderer> ().material.color;
		if (coll.name == "Brush1") {
			InstantiateBrush.selection = 1;
		} 
		if (coll.name == "Brush2") {
			InstantiateBrush.selection = 2;
		}
		if (coll.name == "Brush3") {
			InstantiateBrush.selection = 3;
		}
	}
}
