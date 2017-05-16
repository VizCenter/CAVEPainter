using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DisplayLife : MonoBehaviour {

	public static List<GameObject> lives = new List<GameObject>();
	public int lifeTotal = 5;
	public float yOffset = -35;



	// Use this for initialization
	void Start () {

		lives.Add (gameObject); 
		CalculateHealth ();
	
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.H)) {

			lifeTotal -= 1;

			CalculateHealth();

		}
	
	}

	void CalculateHealth()
	{
		int i = -1;
		foreach (GameObject live in lives) 
		{


			live.transform.localPosition = new Vector3 (12*i + 12, yOffset, 0);
			if (i < lifeTotal) 
			{
				live.GetComponent<Image>().enabled = true;
				i ++;
			}
			else
			{
				GetComponent<Image>().enabled = false;
			}

		}


	}
}
