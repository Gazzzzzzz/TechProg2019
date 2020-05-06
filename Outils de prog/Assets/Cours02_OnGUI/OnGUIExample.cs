using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGUIExample : MonoBehaviour
{
    [SerializeField]
    private Vector2 m_ScrollRect;
    [SerializeField]
    private Texture2D m_BoxBackground;
    [SerializeField]
    private Rect m_WindowRect = new Rect(20f, 20f, 200f, 150f);


    private float m_SliderValue;
    private bool m_Toggle;
    private string m_TextField;

    private string m_PasswordField = "";

    private int m_GridIndex;
    private string[] m_GridStrings = new string[] { "Grid 1", "Grid 2", "Grid 3", "Grid 4"};

    private int m_ToolbarIndex;

    private Vector2 m_ScrollPos;

    private void OnGUI()
    {
        Rect rect = new Rect(0f, 0f, 100f, 20f);

        Rect scrollView = new Rect(0f, 0f, m_ScrollRect.x, m_ScrollRect.y);
        Rect scrollTotalRect = scrollView;
        scrollTotalRect.height += 200f;
        m_ScrollPos = GUI.BeginScrollView(scrollView, m_ScrollPos, scrollTotalRect);

        GUIStyle style = new GUIStyle(GUI.skin.box);
        if(m_BoxBackground != null)
        {
            style.normal.background = m_BoxBackground;
        }

        GUI.Box(rect, "", style);

        GUI.Label(rect, "This is a lasssssssssssssssaaaaaaaaaaaaaaaaaaaaaaadsasdfgabel!");

        rect.y += 50f;

        m_SliderValue = CustomSlider(rect, m_SliderValue, 0f, 1f);

        rect.y += 50f;

        if (GUI.Button(rect, "Button"))
        {
            Debug.Log("epstein didnt kill himself");
        }

        rect.y += 50f;

        m_Toggle = GUI.Toggle(rect, m_Toggle, "toggle");

        rect.y += 50f;

        m_TextField = GUI.TextField(rect, m_TextField);

        rect.y += 50f;

        m_PasswordField = GUI.PasswordField(rect, m_PasswordField, '*', 5);

        rect.y += 50f;
        rect.width += 100f;
        rect.height += 200f;
        m_GridIndex = GUI.SelectionGrid(rect, m_GridIndex, m_GridStrings, 2);

        rect.y += 50f;

        

        GUI.EndScrollView();

        Rect toolbarRect = new Rect(300f, 10f, 300f, 50f);
        m_ToolbarIndex = GUI.Toolbar(toolbarRect, m_ToolbarIndex, m_GridStrings);

        m_WindowRect = GUI.Window(0, m_WindowRect, DrawWindow, "window");
    }


    private float CustomSlider(Rect i_Position, float i_Value, float i_LeftValue, float i_RightValue)
    {
        i_Value = GUI.HorizontalSlider(i_Position, i_Value, i_LeftValue, i_RightValue);

        Rect labelRect = i_Position;
        labelRect.x += i_Position.width;
        GUI.Label(labelRect, i_Value.ToString("F2"));
        return i_Value;
    }

    private void DrawWindow(int i_ID)
    {
        GUI.Label(new Rect(0f, 30f, 100f, 20f), "dicksneezegang");
        Rect dragRect = m_WindowRect;
        dragRect.x = 0f;
        dragRect.y = 0f;

        GUI.DragWindow(dragRect);
    }
}