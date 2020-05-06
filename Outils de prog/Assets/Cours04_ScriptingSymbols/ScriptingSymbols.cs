#if UNITY_EDITOR
#define PIKACHEATS
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptingSymbols : MonoBehaviour
{
    private void Start()
    {
#if UNITY_EDITOR
        Debug.LogError("In Editor", gameObject);
#else
        Debug.LogError("Not In Editor");
#endif
    }

    private void Update()
    {
#if PIKACHEATS
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.LogError("Pressed A");
        }
#endif

#if AUTRE_AFFAIRE
        if(Input.GetKeyDown(KeyCode.B))
        {
            Debug.LogError("Pressed B");
        }
#endif
    }

        


}
