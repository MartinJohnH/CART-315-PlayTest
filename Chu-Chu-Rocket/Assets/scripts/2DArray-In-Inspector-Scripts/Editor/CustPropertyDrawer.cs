using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(ArrayLayout))]
public class CustPropertyDrawer : PropertyDrawer {


	public override void OnGUI(Rect position,SerializedProperty property,GUIContent label){
		EditorGUI.PrefixLabel(position,label);
		Rect newposition = position;
		newposition.y += 28f;
		SerializedProperty data = property.FindPropertyRelative("rows");
		//data.rows[0][]
		for(int j=0;j< (int)Spawn.gridY; j++){
			SerializedProperty row = data.GetArrayElementAtIndex(j).FindPropertyRelative("row");
			newposition.height = 28f;
			if(row.arraySize != (int)Spawn.gridX)
				row.arraySize = (int)Spawn.gridX;
			newposition.width = position.width/ (int)Spawn.gridX;
			for(int i=0;i< (int)Spawn.gridX; i++){
				EditorGUI.PropertyField(newposition,row.GetArrayElementAtIndex(i),GUIContent.none);
				newposition.x += newposition.width;
			}

			newposition.x = position.x;
			newposition.y += 28f;
		}
	}

	public override float GetPropertyHeight(SerializedProperty property,GUIContent label){
		return 28f * (((int)Spawn.gridY)+2);
	}
}
