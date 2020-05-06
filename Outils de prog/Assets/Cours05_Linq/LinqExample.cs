using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinqExample : MonoBehaviour
{
    public List<GameObject> m_Objects;

    private void OnGUI()
    {
        GameObject closestObject = GetClosestObject(m_Objects);
        //Debug.Log(closestObject.name);

        // Avoir le premier de la liste
        GameObject closestLinq = m_Objects
            .OrderBy(pikachu => Vector3.Distance(transform.position, pikachu.transform.position))
            .FirstOrDefault();

        //Debug.Log(closestLinq.name);

        //Avoir le dernier dans la liste (Version 1)
        GameObject furthestObject = m_Objects
            .OrderBy(go => Vector3.Distance(transform.position, go.transform.position))
            .LastOrDefault();

        //Debug.Log(furthestObject.name);

        // Avoir le dernier dans la liste

        GameObject furthestObject2 = m_Objects
            .OrderByDescending(go => Vector3.Distance(transform.position, go.transform.position))
            .FirstOrDefault();

        // Debug.Log(furthestObject2.name);

        GameObject[] skips = m_Objects
            .Skip(1)
            .ToArray();

        //for(int i = 0; i < skips.Length; i++)
        //    {
        //        Debug.Log(skips[i]);
        //    }

        // 'Prends' le nombre d'éléments spécifiés
        List<GameObject> takeExample = m_Objects
            .Take(2)
            .ToList();

        //for(int i = 0; i < takeExample.Count; i++)
        //{
        //    Debug.Log(takeExample[i].name);
        //}
        
        // Where sert a filtrer la liste et a retourner les éléments selon la condition spécifiée
        List<GameObject> capsules = m_Objects
            .Where(go => go.GetComponent<CapsuleCollider>() != null)
            .ToList();

        //for(int i = 0; i < capsules.Count; i++)
        //{
        //    Debug.Log(capsules[i].name);
        //}

        bool anyExample = m_Objects
            .Any(go => go.name == "Cube2");
        //Debug.Log(anyExample);

        List<int> intListExample = new List<int>() { 1, 1, 1, 2, 2, 3, 4, 4, 4, 4 };

        int[] distinctInt = intListExample
            .Distinct()
            .ToArray();

        for(int i = 0; i< distinctInt.Length; i++)
        {
            Debug.Log(distinctInt[i]);
        }


    }

    private GameObject GetClosestObject(List<GameObject> i_GameObjects)
    {
        float smallestDistance = Mathf.Infinity;
        GameObject closestObject = null;


        for (int i = 0; i < i_GameObjects.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, i_GameObjects[i].transform.position);
            if(distance < smallestDistance)
            {
                smallestDistance = distance;
                closestObject = i_GameObjects[i];
            }
        }

        return closestObject;
        
    }
}
