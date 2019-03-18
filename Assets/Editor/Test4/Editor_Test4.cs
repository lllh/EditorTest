using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Test4))]
public class Editor_Test4 : Editor {

	public override void OnInspectorGUI(){
		Test4 test = target as Test4;
		int width = EditorGUILayout.IntField("width a", test.width);
		if(test.width != width)
			test.width = width;
	}
}
