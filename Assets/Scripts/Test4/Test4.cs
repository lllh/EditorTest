using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test4 : MonoBehaviour {

	[SerializeField]
	private int _width;

	public int width{
		get{
			return _width;
		}
		set{
			Debug.Log("set :::" + value);
			_width = value;
		}
	}
}

// public class SetPropertyAttribute:PropertyAttribute{
// 	public string Name{get;private set;}
// 	public bool IsDirty{get;set;}

// 	public SetPropertyAttribute(string name){
// 		this.Name = name;
// 	}
// }