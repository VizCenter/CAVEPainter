using UnityEngine;
using System.Collections;
using getReal3D;

public class Menu : MonoBehaviour {

	public GameObject menu;
	public GameObject selector;
	public static GameObject selectionBox;
	public static bool selecting;

	// Use this for initialization
	void Start () {
		selectionBox = GameObject.FindGameObjectWithTag ("Selectionbox");
		menu.SetActive (false);
		selector.SetActive (false);
		selectionBox.SetActive (false);
		selecting = selectionBox.activeInHierarchy;
	}
	
	// Update is called once per frame
	void Update () {

		selecting = selectionBox.activeInHierarchy;

		if (getReal3D.Input.GetButtonDown ("ChangeWand")) 
		//if(UnityEngine.Input.GetKeyDown (KeyCode.C))
		{
			menu.SetActive (!menu.activeInHierarchy);
			selector.SetActive (!selector.activeInHierarchy);
		}

		if (getReal3D.Input.GetButtonDown ("Jump")) 
		{
			if (menu.activeInHierarchy == false)
			{
				selectionBox.SetActive(!selectionBox.activeInHierarchy);
			}
			else if (menu.activeInHierarchy == true)
			{
				selectionBox.SetActive(false);
			}
		}


	
	}
}
