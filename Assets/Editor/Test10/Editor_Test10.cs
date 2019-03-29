using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
// [CustomEditor(typeof(UnityEditor.SceneAsset))]
[CustomEditor(typeof(UnityEditor.DefaultAsset))]
public class Editor_Test10 : Editor {

	public override void OnInspectorGUI(){
		string path = AssetDatabase.GetAssetPath(target);
		if(path.EndsWith(".unity")){
			GUILayout.Button("this is scene");
		}
		else if(path.EndsWith("")){
			GUILayout.Button("this is folder");
		}
		else if(path.EndsWith(".cs")){
			GUILayout.Button("this is a .cs");
		}
	}
}
