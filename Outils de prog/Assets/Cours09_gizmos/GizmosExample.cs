using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosExample : MonoBehaviour
{
    [SerializeField]
    private MeshFilter m_MeshFilter = null;

    [SerializeField]
    private Transform m_Target = null;

    private void OnDrawGizmos()
    {
        Color cubeColor = Color.blue;
        cubeColor.a = 0.25f;
        //changer la couleur
        Gizmos.color = cubeColor;
        //Afficher un cube dans la scene seulement
        //Gizmos.DrawCube(transform.position, Vector3.one * 5f);
        //Afficher notre gizmos de cube en version 'WireFrame' (juste les côtés)
        Gizmos.DrawWireCube(transform.position, Vector3.one * 5f);

        Gizmos.DrawSphere(transform.position + Vector3.right * 5f, 2f);

        if (m_MeshFilter != null)
        {
            Gizmos.color = Color.red;
            // Affiche un mesh
            // *Attention a .mesh vs .sharedmesh
            Gizmos.DrawMesh(m_MeshFilter.sharedMesh, transform.position + Vector3.left * 5f);
        }
        Gizmos.color = Color.cyan;
        // Afficher un ray (rayon avec direction)
        Gizmos.DrawRay(transform.position, transform.up * 50f);

        if (m_Target != null)
        {
            Gizmos.color = Color.magenta;
            // ray point A a point B
            Gizmos.DrawLine(transform.position, m_Target.position);
        }
    }
}
