using UnityEngine;
using System.Collections;
using getReal3D;

public class PaintBrush : MonoBehaviour {

	public GameObject paintbrush;
	public GameObject placer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (getReal3D.Input.GetButtonDown ("ChangeWand")) 
		{
			if (paintbrush.activeInHierarchy == false)
			{
				placer.transform.localScale = new Vector3(0.01f,0.01f,0.01f);
				placer.SetActive(false);
				paintbrush.SetActive(true);
			}
			else 
			{
				paintbrush.SetActive(false);
				placer.SetActive(true);
			}
		} 

	
	}
}
