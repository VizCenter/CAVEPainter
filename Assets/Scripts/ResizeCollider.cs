using UnityEngine;
using System.Collections;
using getReal3D;

public class ResizeCollider : MonoBehaviour {

	//public BoxCollider placer;
	public int smooth = 2;
	public Transform placer;

	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {

		//float volumex = placer.size.x;
		//float volumey = placer.size.y;
		if (getReal3D.Input.GetAxis ("Yaw") > 0 && placer.localScale.x < 2) {
			placer.localScale += new Vector3(0.1F, 0, 0);
		}
		else if (getReal3D.Input.GetAxis ("Yaw") < 0 && placer.localScale.x > 0.1) {
			placer.localScale -= new Vector3(0.1F, 0, 0);
		}
		else if (getReal3D.Input.GetAxis ("Forward") > 0 && placer.localScale.y < 2) {
			placer.localScale += new Vector3(0, 0.1f, 0);
		}
		else if (getReal3D.Input.GetAxis ("Forward") < 0 && placer.localScale.y > 0.1) {
			placer.localScale -= new Vector3(0, 0.1f, 0);
		}
	}

//		float lerp = (Time.deltaTime * smooth);
//		
//		if (getReal3D.Input.GetAxis("Forward") < 0)
//		{
//			colorEnd = Color.red;
//			placer.localScale.x = Scale.Equals(
//			//			changing = true;
//		}
//		if (getReal3D.Input.GetAxis("Forward") > 0)
//		{
//			colorEnd = Color.green;
//			rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
//			//			changing = true
//		}
//		if (getReal3D.Input.GetAxis("Strafe") < 0)
//		{
//			colorEnd = Color.blue;
//			rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
//			//			changing = true;
//		}
//		if (getReal3D.Input.GetAxis("Strafe") > 0)
//		{
//			colorEnd = Color.yellow;
//			rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
//			//			changing = true;
//		}
//			sizeStart = placer.localScale;
//	}
}
