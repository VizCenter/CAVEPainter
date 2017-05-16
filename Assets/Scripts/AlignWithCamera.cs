using UnityEngine;
using System.Collections;

public class AlignWithCamera : MonoBehaviour {

	public GameObject cam;

	// Use this for initialization
	void Start () {
		transform.position = cam.transform.position + Vector3.forward;
		transform.rotation = cam.transform.rotation;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
