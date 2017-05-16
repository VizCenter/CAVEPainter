using UnityEngine;
using System.Collections;
using getReal3D;

public class ToggleMenu : MonoBehaviour {

	public GameObject menu;
	public GameObject pointer;

	// Use this for initialization
	void Start () {

		menu.SetActive (false);
		pointer.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (getReal3D.Input.GetButtonDown ("ChangeWand")) 
			//if(UnityEngine.Input.GetButtonDown ("Fire1"))
		{
			menu.SetActive (!menu.activeInHierarchy);
			pointer.SetActive(!pointer.activeInHierarchy);
		}
	
	}
}
