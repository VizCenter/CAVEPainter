using UnityEngine;
using System.Collections;
using getReal3D;

public class FollowTarget : MonoBehaviour {

	public GameObject leader;
	public bool findHand = true;
	private bool placed;

	void Start()
	{
		placed = false;

		if (findHand == true) {
			leader = GameObject.FindGameObjectWithTag("Hand");
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (getReal3D.Input.GetButton ("WandButton")) {

			if (placed == false)
			{
				transform.position = leader.transform.position;
			}

		}

		if (getReal3D.Input.GetButtonUp ("WandButton")) {
			placed = true;
		}
	
	}
}
