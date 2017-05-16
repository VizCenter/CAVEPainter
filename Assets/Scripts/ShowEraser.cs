using UnityEngine;
using System.Collections;
using getReal3D;

public class ShowEraser : MonoBehaviour {

	public Renderer eraser;

	// Use this for initialization
	void Start () {
		eraser.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (getReal3D.Input.GetButton("Jump"))
		{
			eraser.enabled = true;
		}
		else
		{
			eraser.enabled = false;
		}
	
	}
}
