using UnityEngine;
using System.Collections;
using getReal3D;

public class ColliderToggle : MonoBehaviour {

	public BoxCollider box;

	// Use this for initialization
	void Start () {
	
		//box = GetComponent<BoxCollider> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (getReal3D.Input.GetButton("WandButton"))
		{
			box.enabled = true;
		}
		else
		{
			box.enabled = false;
		}
	
	}
}
