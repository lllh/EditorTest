using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour {

	[HideInInspector]
	[SerializeField]
	private Rect mRect;

	public Rect MRect{
		get{
			return mRect;
		}
		set{
			mRect = value;
		}
	}

	[HideInInspector]
	[SerializeField]
	private Texture mTexture;

	public Texture MTexture{
		get{
			return mTexture;
		}
		set{
			mTexture = value;
		}
	}

	public Rect tmpRect;

	public Texture tmpTexture;

	void Start()
	{
		Debug.Log(MRect.ToString());
		Debug.Log(MTexture.ToString());
		Debug.Log(tmpRect.ToString());
		Debug.Log(tmpTexture.ToString());
	}
}
