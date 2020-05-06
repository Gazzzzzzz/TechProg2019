using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int m_Level;
    public float m_MoveSpeed;

    public List<int> m_Weapons;

    [SerializeField]
    private float m_Health;

    private string m_CharacterName;
}
