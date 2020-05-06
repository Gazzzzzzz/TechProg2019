using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoExample : MonoBehaviour
{
    private void OnGUI()
    {
        if(GUILayout.Button("Create Empty"))
        {
            GameObject emptyGO = new GameObject("Empty");
            UnityEditor.Undo.RegisterCreatedObjectUndo(emptyGO, "Create Empty");
        }
    }
}
