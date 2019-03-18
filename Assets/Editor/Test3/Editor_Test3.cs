using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Test3))]
public class Editor_Test3 : Editor {

	void OnSceneGUI(){
		Test3 test = target as Test3;

		Handles.Label(test.transform.position + Vector3.up * 2,  test.transform.name + " pos: " + test.transform.localPosition);

		Handles.BeginGUI();
		GUILayout.BeginArea(new Rect(100,100,100,100));
		if(GUILayout.Button("这是一个按钮", GUILayout.Width(100))){
			Debug.Log("点我作甚");
		}

		GUILayout.Label("我在scene视图");

		GUILayout.EndArea();
		Handles.EndGUI();
	}

	// [DrawGizmo(GizmoType.SelectedOrChild | GizmoType.NotSelected)]
	// static void DrawGameObjectName(Transform transform, GizmoType gizmoType){
	// 	Handles.Label(transform.position, transform.gameObject.name);
	// }
}
