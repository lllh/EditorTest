using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Editor_Test5 : Editor {

	public override void OnInspectorGUI(){
		base.DrawDefaultInspector();
		if(GUILayout.Button("Test_Button")){
			Debug.Log("你点我做乜春");
		}
	}
}

[CanEditMultipleObjects()]
[CustomEditor(typeof(Camera), true)]
public class Custom_Test5 : Editor_Test5{

}
