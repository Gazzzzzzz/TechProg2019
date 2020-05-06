using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ClearAttribute))]
public class ClearAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect i_Position, SerializedProperty i_Property, GUIContent i_Label)
    {
        //base.OnGUI(i_Position, i_Property, i_Label);
        i_Position.width -= 20f;

        EditorGUI.PropertyField(i_Position, i_Property, i_Label);

        Rect buttonRect = i_Position;
        buttonRect.x += i_Position.width;
        buttonRect.width = 20f;

        GUI.color = Color.red;
        if(GUI.Button(buttonRect, "X"))
        {
            switch(i_Property.propertyType)
            {
                case SerializedPropertyType.String:
                    i_Property.stringValue = "";
                    break;
                case SerializedPropertyType.Float:
                    i_Property.floatValue = 0f;
                    break;
                default:
                    Debug.Log("type not supported");
                    break;
            }

            GUI.FocusControl("");
        }
        //Préentivement, di on dessinait d'autre choses après, ça n'apparaitrait pas rouge
        GUI.color = Color.white;
    }
}
