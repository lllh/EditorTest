using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Test9_Attribute))]
public class Editor_Test9_Drawer : PropertyDrawer {

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label){
		Test9_Attribute attribute = this.attribute as Test9_Attribute;
		property.intValue = Mathf.Min(Mathf.Max(EditorGUI.IntField(position,label.text,property.intValue), attribute.min),attribute.max);
	}
}
