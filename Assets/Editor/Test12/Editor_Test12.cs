using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEditor;
using UnityEditor.Callbacks;

public class Editor_Test12 {

	// static Dictionary<string,string> dict = new Dictionary<string,string>();
	
	// public Editor_Test12(){
	// 	dict[".lua"] = "/Applications/Sublime Text.app";
	// 	dict[".cs"] = "/Applications/Sublime Text.app";
	// }
	
	[OnOpenAssetAttribute(1)]
	public static bool step1(int instanceID, int line){
		string name = EditorUtility.InstanceIDToObject(instanceID).name;
		UnityEngine.Debug.Log("step1      --" + name);
		return false;
	}

	[OnOpenAssetAttribute(2)]
	public static bool step2(int instanceID, int line){
		string path = AssetDatabase.GetAssetPath(EditorUtility.InstanceIDToObject(instanceID));
		string name = Application.dataPath + "/" + path.Replace("Assets/","");

		if(name.EndsWith(".lua")){
			UnityEngine.Debug.Log(name);
			Process process = new Process();
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.FileName = "/Applications/Sublime Text.app";
			startInfo.Arguments = name;
			process.StartInfo = startInfo;
			process.Start();
			return true;
		}
		return false;
	}
}
