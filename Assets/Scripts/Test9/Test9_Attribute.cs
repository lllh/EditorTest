using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test9_Attribute : PropertyAttribute {

	public int min;
	public int max;
	
	public Test9_Attribute(int a, int b){
		min = a;
		max = b;
	}
}
