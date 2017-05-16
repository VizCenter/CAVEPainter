using UnityEngine;
using System.Collections;
using getReal3D;



public class ChangePaintbrush: MonoBehaviour {
	
	private Color colorStart;
	public Color colorEnd;
	public float smooth = 2;
	public Renderer rend;
	private bool changing;
	void Start() {
		rend = GetComponent<Renderer>();
//		changing = false;
	}
	void Update() {

		float lerp = (Time.deltaTime * smooth);

		if (getReal3D.Input.GetButton("WandButton"))
		{
			if (getReal3D.Input.GetAxis("Forward") > 0)
			{
				colorEnd = Color.white;
				rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
				//			changing = true;
			}
			else if (getReal3D.Input.GetAxis("Forward") < 0)
			{
				colorEnd = Color.black;
				rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
				//			changing = true
			}
		}

		else if (getReal3D.Input.GetAxis("Forward") < 0)
		{
			colorEnd = Color.red;
			rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
//			changing = true;
		}
		else if (getReal3D.Input.GetAxis("Forward") > 0)
		{
			colorEnd = Color.green;
			rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
//			changing = true
		}
		else if (getReal3D.Input.GetAxis("Yaw") < 0)
		{
			colorEnd = Color.blue;
			rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
//			changing = true;
		}
		else if (getReal3D.Input.GetAxis("Yaw") > 0)
		{
			colorEnd = Color.yellow;
			rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
//			changing = true;
		}
//		if (changing = false)
			colorStart = rend.material.color;



	}
}