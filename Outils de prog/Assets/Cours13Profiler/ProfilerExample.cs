using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfilerExample : MonoBehaviour
{
    private List<int> m_GarbageList;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            CreateGarbage();
        }
    }

    private void CreateGarbage()
    {
        for(int i = 0; 1 < 100; i++)
        {
            m_GarbageList = new List<int>();
        }
    }
}
