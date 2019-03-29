using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test11 : MonoBehaviour {

	// Use this for initialization
	public string name = "弟弟";

#if UNITY_EDITOR
	void Reset(){//绑定脚本或脚本reset的时候调用
		Debug.Log("reset function call");
		BoxCollider collider = this.GetComponent<BoxCollider>();
		if(collider == null)
			this.gameObject.AddComponent<BoxCollider>();
	}

	void OnValidate(){// 脚本序列化的数据发生改变时调用
		Debug.Log("validate function call");
	}
 }
#endif