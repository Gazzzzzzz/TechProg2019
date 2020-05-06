using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorWindowExample : EditorWindow
{
    private enum Animals
    {
        Elephant,
        Cat,
        Dog
    }

    private int m_TestInt;
    private string m_TextField;
    private Transform m_TransformExample;

    private Animals m_EnumPopupIndex;

    private int m_PopupIndex;

    private string[] m_Strings = new string[]
    {
        "Popup1",
        "popup2",
        "popup3"
    };

    //Crée un bouton dans la barre de menu de Unity. Le '/' crée des sous-groupes.
    [MenuItem("Tools/Editor Example...")]
    private static void Init()
    {
        GetWindow<EditorWindowExample>().Show();
    }

    // Cette fonction permet de commencer à draw des éléments dans la fenêtre un peu comme le OnGUI du Monobehaviour
    private void OnGUI()
    {
        //GUILayout va automatiquement 'dessiner' les éléments un a la suite de l'autre sans avoir a spécifier un 'rect'
        GUILayout.Label("GUI Layout is awesome!");
        GUILayout.Label("Wow! It works automatically!");

        // BeginHorizontal vient avec son End. Tout se qui se trouve entre les 2 se dessine à l'horizontal.
        GUI.color = Color.blue;
        GUILayout.BeginHorizontal(GUI.skin.box);
        GUI.color = Color.white;

        m_TextField = GUILayout.TextField(m_TextField);

        GUI.color = Color.red;
        if(GUILayout.Button("X", GUILayout.Width(20f)))
        {
            Debug.Log("pressed button");
        }

        GUI.color = Color.white;

        GUILayout.EndHorizontal();

        //EditorGUILayout a plus de fonctionnalités que le GUILayout
        m_TextField = EditorGUILayout.TextField("Text Field", m_TextField);

        EditorGUI.BeginChangeCheck();
        m_TestInt = EditorGUILayout.IntField("Test Int", m_TestInt);
        if(EditorGUI.EndChangeCheck())
        {
            Debug.Log("Int Field has changed!");
        }

        m_TransformExample = (Transform)EditorGUILayout.ObjectField("Transform", m_TransformExample, typeof(Transform), true);
        //Permet de désactiver les éléments a dessiner si la condition est vraie
        EditorGUI.BeginDisabledGroup(m_TransformExample == null);
        if (GUILayout.Button(new GUIContent("Show Tranform Name", "This is the button's tooltip!")))
        {
            Debug.Log(m_TransformExample.name);
        }
        EditorGUI.EndDisabledGroup();

        //Popup sert a dessiner une liste déroulante d'array de strings
        m_PopupIndex = EditorGUILayout.Popup("Popup Example", m_PopupIndex, m_Strings);
        Debug.Log(m_Strings[m_PopupIndex]);


        //popup mais en enum
        m_EnumPopupIndex = (Animals)EditorGUILayout.EnumPopup("", m_EnumPopupIndex);


        if(GUILayout.Button("Show Progress Bar"))
        {
            float progress = 0f;
            int total = 10000;
            for(int i = 0; i < total; i++)
            {
                // Division de int/int te retourne un int.
                //ex 99/100 = 0
                //Pour fixer le probleme, cast le dénumérateur en float => [int] / (float) [int]
                progress = i / (float)total;

                float maths = 9 / 9 * 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2 / 2;

                if (EditorUtility.DisplayCancelableProgressBar("Progress", "In Progress (" + i + "/" + total, progress))
                {
                    break;
                }

            }
            EditorUtility.ClearProgressBar();

        }

        // Example du keyword 'params'
        //permet d'ajoueer un nombre x de parametres du type spécifié
        ParamsExample("Title", "String1", "String2", "String3", "String3");
    }

    private void ParamsExample(string i_Title, params string[] i_Messages)
    {
        Debug.Log("Title: " + i_Title);

        for(int i = 0; i <i_Messages.Length; i++)
        {
            Debug.Log(i_Messages[i]);
        }
    }
}
