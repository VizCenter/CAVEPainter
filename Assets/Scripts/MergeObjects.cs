using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MergeObjects : MonoBehaviour {

	public static List<Transform> merge = new List<Transform>();
	public float mergeDistance = 5;
	public Transform bestTarget = null;
	private BoxCollider coll;
	private float dist;

	void Start()
	{
		coll = GetComponent<BoxCollider> ();
		merge.Add (transform); 
		InvokeRepeating ("timer",2f,1f);
	}

	void timer()
	{
		getClosest ();
		unify ();

	}

	Transform getClosest()
	{
		if (bestTarget == null) 
		{
			//if (bestTarget == null) {
			float closestDistanceSqr = Mathf.Infinity;
			Vector3 currentPosition = transform.position;
			foreach (Transform potentialTarget in merge) {
				if (potentialTarget != this.transform)
				{
					Vector3 directionToTarget = potentialTarget.position - currentPosition;
					float dSqrToTarget = directionToTarget.sqrMagnitude;
					if (dSqrToTarget < closestDistanceSqr) {
						closestDistanceSqr = dSqrToTarget;
						bestTarget = potentialTarget;
					}
				}
			}
		
			return bestTarget;
		}
		 else
			return null;
	}


	void unify()
	{

		if (bestTarget != null) 
		{

			dist = Vector3.Distance (gameObject.transform.position, bestTarget.position);
			//Debug.Log (dist);
			if (dist < mergeDistance) {
				transform.SetParent (bestTarget);

			}
			if (transform.parent == bestTarget) {
				coll.enabled = false;
			}
		}

	}

}