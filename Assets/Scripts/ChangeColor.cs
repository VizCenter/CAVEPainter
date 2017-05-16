using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour {

	private Renderer selfColor;

	// Use this for initialization
	void Start () {
		selfColor = GetComponent<Renderer> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll)
	{
		Renderer other = coll.GetComponent<Renderer> ();

		if (other.enabled == true) 
		{
			other.material.color = selfColor.material.color; 
		}
	}
}
