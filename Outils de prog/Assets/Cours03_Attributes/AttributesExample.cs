using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
[RequireComponent(typeof(BoxCollider))]
public class AttributesExample : MonoBehaviour
{
    [System.Serializable]
    public class ExampleInfo
    {
        public int m_ID;
        public float m_Value;
        public Color m_Color;
    }


    // en-tête, fonctionne sur tous les types de variables, pas sur les classes though
    [Header("My Header")]
    public float m_HeaderExample;

    [HideInInspector]
    public float m_HideExample;

    //String only
    [Multiline(5)]
    public string m_MultilineExample;

    [Space(25)]
    [Tooltip("This is the character speed for all the characters that are easdnvlaksndla,sdn,vmnfbkdfjnjkhylkfmas,ldmnwjhgb,dmg n")]
    public int m_NonSenseValue;

    [Range(0f, 100f)]
    public float m_RangeExample;

    [Clear]
    public string m_ClearExample;

    private void Update()
    {
        if (!Application.isPlaying)
        {
            Debug.Log("update in edit mode!");

        }

        
    }


}
