using UnityEngine;
using System.Collections;
using getReal3D;

public class DisableControl : MonoBehaviour {

	public GameObject selector;
	private getRealWalkthruController cont;

	// Use this for initialization
	void Start () {
		cont = GetComponent<getRealWalkthruController> ();
	}
	
	// Update is called once per frame
	void Update () {
		cont.enabled = !selector.activeInHierarchy;
	}
}
