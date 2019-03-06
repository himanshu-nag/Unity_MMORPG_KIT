using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(MainQuest))]
public class ColorPointDrawer : PropertyDrawer {

	public override float GetPropertyHeight (SerializedProperty property, GUIContent label) {
        return label != new GUIContent("Quest") && Screen.width < 333 ? (35f + 18f) : 25f;
	}

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
		int oldIndentLevel = EditorGUI.indentLevel;
		label = EditorGUI.BeginProperty(position, label, property);
		Rect contentPosition = EditorGUI.PrefixLabel(position, label);
		if (position.height > 16f) {
			position.height = 16f;
			EditorGUI.indentLevel += 1;
			contentPosition = EditorGUI.IndentedRect(position);
			contentPosition.y += 18f;
		}
		contentPosition.width *= 0.75f;
		EditorGUI.indentLevel = 0;
        EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("position"), new GUIContent("Do What?"));
		contentPosition.x += contentPosition.width;
		contentPosition.width /= 3f;
		EditorGUIUtility.labelWidth = 14f;
		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("color"), new GUIContent("Object"));
		EditorGUI.EndProperty();
		EditorGUI.indentLevel = oldIndentLevel;
	}
}