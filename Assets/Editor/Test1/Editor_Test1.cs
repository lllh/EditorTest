using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Test1))]
public class Editor_Test1 : Editor {

	public override void OnInspectorGUI(){
		Test1 test = target as Test1;

		test.MRect = EditorGUILayout.RectField("rect title", test.MRect);
		test.MTexture = EditorGUILayout.ObjectField("一个texture", test.MTexture, typeof(Texture)) as Texture;
		test.tmpRect = EditorGUILayout.RectField("tmp rect title", test.tmpRect);
		test.tmpTexture = EditorGUILayout.ObjectField("tmp texture", test.tmpTexture, typeof(Texture)) as Texture;
	}
}
