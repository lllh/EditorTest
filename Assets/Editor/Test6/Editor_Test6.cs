using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Editor_Test6 : Editor {
	
	[MenuItem("MyEditorTest/Editor_Test6")]
	static void Test(){
		Transform parent = Selection.activeGameObject.transform;
		Vector3 position = parent.position;
		Vector3 scale = parent.localScale;
		Quaternion ratation = parent.rotation;

		parent.position = Vector3.zero;
		parent.localScale = Vector3.one;
		parent.rotation = Quaternion.Euler(Vector3.zero);

		Collider[] colliders = parent.GetComponentsInChildren<BoxCollider>();
		foreach(Collider col in colliders){
			DestroyImmediate(col);
		}

		Vector3 center = Vector3.zero;

		Renderer[] renderers = parent.GetComponentsInChildren<Renderer>();
		foreach(Renderer child in renderers){
			center += child.bounds.center;
		}

		center /= parent.childCount;// parent.GetComponentsInChildren<Renderer>().Length;
		Bounds bounds = new Bounds(center, Vector3.zero);
		foreach(Renderer child in renderers){
			bounds.Encapsulate(child.bounds);
		}

		BoxCollider boxCollider = parent.gameObject.AddComponent<BoxCollider>();
		boxCollider.center = bounds.center - parent.position;
		boxCollider.size = bounds.size;

		parent.position = position;
		parent.rotation = ratation;
		parent.localScale = scale;
	}
}
