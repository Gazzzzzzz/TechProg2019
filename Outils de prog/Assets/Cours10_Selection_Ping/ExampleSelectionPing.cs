using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ExampleSelectionPing : MonoBehaviour
{
    [SerializeField]
    private string m_TagFiler = "";

    private void OnGUI()
    {

        // Pour avoir des fonc editor dans un script pas dans un dossier editor
#if UNITY_EDITOR
        if(GUILayout.Button("Create Empty"))
        {
            GameObject emptyGO = new GameObject("Empty");
            // permet de forcer la sélection dans l'éditeur
            Selection.activeObject = emptyGO;
            // Sert a mettre l'accent jaune
            EditorGUIUtility.PingObject(emptyGO);
        }

        if(GUILayout.Button("Select Objects with tag"))
        {
            GameObject[] gos = GameObject.FindGameObjectsWithTag(m_TagFiler);
            // Permet de sélectionner plusieurs objets en meme temps
            Selection.objects = gos;
        }
#endif
    }
}
