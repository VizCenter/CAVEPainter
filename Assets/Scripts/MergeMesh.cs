

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MergeMesh : MonoBehaviour {

	public static List<GameObject> cubes = new List<GameObject>();
	public float rate = 1;

	// Use this for initialization
	void Start () {

//		InvokeRepeating("Merge",1,rate);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	IEnumerator Merge()
//	{
//		int combine : CombineInstance[] = new CombineInstance[cubes.Length-1];
//		var index = 0;
//		
//		for (var i = 0; i < cubes.Count; i++)
//		{
//			if (cubes[i].sharedMesh == null) continue;
//			combine[index].mesh = cubes[i].sharedMesh;
//			combine[index++].transform = cubes[i].transform.localToWorldMatrix;
//			cubes[i].renderer.enabled = false;
//		}
//		
//		GetComponent(MeshFilter).mesh = new Mesh();
//		GetComponent(MeshFilter).mesh.CombineMeshes (combine);
//		renderer.material = cubes[1].renderer.sharedMaterial;
//	}
		//var i = 0;
//		for (int i=0; i<cubes.Count; i++)
//		{
//			if (i.GetComponent<GenerateCubes>().placed == true)
//			{
//				int index = i;
//				//CombineInstance[index].mesh
//				CombineInstance[i].mesh;
//				cube.GetComponent<MeshFilter>().mesh.CombineMeshes(cube);
//			}
//		}
//	}
}
