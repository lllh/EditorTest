using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Editor_Test2 : EditorWindow {

	[MenuItem("Editor_Test/Test2_Window")]
	static Editor_Test2 AddWindow(){
		var window = GetWindow<Editor_Test2>("window name");
		// var window = GetWindowWithRect(typeof(Editor_Test2),new Rect(0,0,300,300),true, "window name") as Editor_Test2;
		return window;
	}

	private Texture texture;

	void OnEnable(){


	}


	//绘制窗口时调用
	void OnGUI(){
		EditorGUILayout.TextField("输入文字：", "llll");

		if(GUILayout.Button("打开通知", GUILayout.Width(200))){
			this.ShowNotification(new GUIContent("打开通知"));
		}

		if(GUILayout.Button("关闭通知", GUILayout.Width(200))){
			this.RemoveNotification();
		}

		EditorGUILayout.LabelField("鼠标在窗口的位置    ", Event.current.mousePosition.ToString());

		texture = EditorGUILayout.ObjectField("添加贴图", texture, typeof(Texture), true) as Texture;

		if(GUILayout.Button("关闭窗口", GUILayout.Width(200))){
			this.Close();
		}
	}

	void OnInspectorUpdate(){
		// Debug.Log("repaint");
		this.Repaint();
	}

	void OnFocus(){
		Debug.Log("窗口获得焦点时调用");
	}

	void OnLostFocus(){
		Debug.Log("窗口失去焦点时调用");
	}

	void OnProjectChange(){
		Debug.Log("Project窗口资源改变时调用");
	}

	void OnHierarchyChange(){
		Debug.Log("Hierarchy窗口资源改变时调用");
	}

	void Update(){
		// Debug.Log("窗口更新时调用");
	}

	void OnSelectionChange(){
		foreach(Transform t in Selection.transforms){
			Debug.Log("选中了 "+ t.name);
		}
	}

	void OnDestroy(){
		Debug.Log("窗口关闭时调用"); 
	}
}
