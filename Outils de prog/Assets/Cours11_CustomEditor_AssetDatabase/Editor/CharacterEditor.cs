using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//notifier unity de la class a overrider
[CustomEditor(typeof(Character))]
public class CharacterEditor : Editor
{
    private const char UP_ARROW = (char)9650;
    private const char DOWN_ARROW = (char)9660;


    private const string LEVEL = "m_Level";
    //overrider l,inspecteur
    public override void OnInspectorGUI()
    {
        // une des façons d'afficher l'inspecteur par défaut
        //base.OnInspectorGUI();
        //2eme
        //DrawDefaultInspector();

        // Permet d'exclure l'affichage de certaines propriétés/variables
        //DrawPropertiesExcluding(serializedObject, "m_Level");

        //Ca va chercher la propriété/variable dans notre serializedObject -> La classe que l'on override sous forme générique/editor
        SerializedProperty levelProp = serializedObject.FindProperty(LEVEL);
        levelProp.intValue = EditorGUILayout.IntSlider(levelProp.displayName, levelProp.intValue, 3, 99);

        //afficher la prop/ var comme elle devrait l'etre par default
        EditorGUILayout.PropertyField(levelProp);

        //le find property ne permet pas d'aller chercher les props/var qui no sont pas serialized
        //SerializedProperty charNameProp = serializedObject.FindProperty("m_CharacterName");
        //charNameProp.stringValue = "Test";

        ShowCustomList(serializedObject.FindProperty("m_Weapons"));

        // dit a l'éditeur d'appliquer les modifs apportées aux prop/var
        serializedObject.ApplyModifiedProperties();
    }

    private void ShowCustomList(SerializedProperty i_List)
    {
        // Affiche proprité avec une fleche pour ouvrir hierarchie
        EditorGUILayout.BeginHorizontal();
        i_List.isExpanded = EditorGUILayout.Foldout(i_List.isExpanded, i_List.displayName);

        GUI.color = Color.green;
        // Editorstyles = classes avec style cool juste dans editeur
        if (GUILayout.Button("+", EditorStyles.toolbarButton, GUILayout.Width(20f)))
        {
            //modifier size
            i_List.arraySize++;
        }
        GUI.color = Color.red;
        if (GUILayout.Button("X", EditorStyles.toolbarButton, GUILayout.Width(20f)))
        {
            i_List.arraySize = 0;

        }
        GUI.color = Color.white;

        EditorGUILayout.EndHorizontal();

        if(i_List.isExpanded)
        {
            EditorGUI.indentLevel++;
            i_List.arraySize = EditorGUILayout.IntField("Size", i_List.arraySize);
            for(int i = 0; i < i_List.arraySize; i++)
            {
                EditorGUILayout.BeginHorizontal(GUI.skin.box);
                //GetArrayetcetc est valide juste pour listes/ arrays et va chercher un element a un index précis
                EditorGUILayout.PropertyField(i_List.GetArrayElementAtIndex(i));

                GUI.color = Color.cyan;
                EditorGUI.BeginDisabledGroup(i == 0);
                if(GUILayout.Button(UP_ARROW.ToString(), EditorStyles.toolbarButton, GUILayout.Width(20f)))
                {
                    //d.place un élément de l'index srcindex à l'index dstindex
                    i_List.MoveArrayElement(i, i - 1);
                }
                EditorGUI.EndDisabledGroup();
                EditorGUI.BeginDisabledGroup(i == i_List.arraySize - 1);
                if (GUILayout.Button(DOWN_ARROW.ToString(), EditorStyles.toolbarButton, GUILayout.Width(20f)))
                {
                    i_List.MoveArrayElement(i, i + 1);
                }
                EditorGUI.EndDisabledGroup();
                GUI.color = Color.red;
                if(GUILayout.Button("-", EditorStyles.toolbarButton, GUILayout.Width(20f)))
                {
                    //supprime un élément a l'index désiré
                    i_List.DeleteArrayElementAtIndex(i);
                }
                GUI.color = Color.white;

                EditorGUILayout.EndHorizontal();

            }

            EditorGUI.indentLevel--;
        }
    }
}

//public class Humain
//{
//    public virtual void Appeler()
//    {
//        Debug.Log("humain répond");

//    }
//}

//public class Enfant : Humain
//{
//    public override void Appeler()
//    {
//        base.Appeler();
//        Debug.Log("Enfant répond");
//    }
//}
