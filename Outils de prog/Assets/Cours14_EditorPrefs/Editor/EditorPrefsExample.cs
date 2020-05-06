using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class EditorPrefsExample : EditorWindow
{

    private enum Prefs
    {
        TestBool,
        TestInt,
        TestFloat,
        TestString,
        COUNT
    }

    private const string KEY_PREFIX = "EditorPrefsExample.";

    [MenuItem("Tools/Editor Prefs...")]
    private static void Init()
    {
        GetWindow<EditorPrefsExample>().Show();
    }
    private void OnGUI()
    {
        int count = (int)Prefs.COUNT;
        for(int i = 0; i < count; i++)
        {
            Prefs curPref = (Prefs)i;
            // Permet de savoir si une clé existe dans les editor prefs
            bool keyExists = EditorPrefs.HasKey(GetKey(curPref));
            EditorGUI.BeginDisabledGroup(!keyExists);
            if(GUILayout.Button("Delete " + curPref.ToString()))
            {
                //Permet de supprimer une clé
                EditorPrefs.DeleteKey(GetKey(curPref));
            }
            EditorGUI.EndDisabledGroup();
        }
        GUILayout.Space(10f);
        // Permet d"aller chercher la valeur booléenne selon une clé définie.
        // Deuxième param;tres c'est la valeur a retourner si la clé n'existe pas
        bool testBool = EditorPrefs.GetBool(GetKey(Prefs.TestBool), false);
        EditorGUI.BeginChangeCheck();
        testBool = EditorGUILayout.Toggle("TestBool", testBool);
        if(EditorGUI.EndChangeCheck())
        {
            
            EditorPrefs.SetBool(GetKey(Prefs.TestBool), testBool);
        }

        int testInt = EditorPrefs.GetInt(GetKey(Prefs.TestInt), -5);
        EditorGUI.BeginChangeCheck();
        testInt = EditorGUILayout.IntField("Test Int", testInt);
        if(EditorGUI.EndChangeCheck())
        {
            EditorPrefs.SetInt(GetKey(Prefs.TestInt), testInt);
        }

        float testFloat = EditorPrefs.GetFloat(GetKey(Prefs.TestFloat), -10.5f);
        EditorGUI.BeginChangeCheck();
        testFloat = EditorGUILayout.FloatField("Test Float", testFloat);
        if (EditorGUI.EndChangeCheck())
        {
            EditorPrefs.SetFloat(GetKey(Prefs.TestFloat), testFloat);
        }

        string testString = EditorPrefs.GetString(GetKey(Prefs.TestString), "N/A");
        EditorGUI.BeginChangeCheck();
        testString = EditorGUILayout.TextField("Test String", testString);
        if (EditorGUI.EndChangeCheck())
        {
            EditorPrefs.SetString(GetKey(Prefs.TestString), testString);
        }
    }
    private string GetKey(Prefs i_Prefs)
    {
        return KEY_PREFIX + i_Prefs.ToString();
    }

        

}
