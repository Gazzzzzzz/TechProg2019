using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGUIAdvEx : MonoBehaviour
{
    private void OnGUI()
    {
        // Screeen est une class static de Unity nous permettant d'aller chercher certains 
        // paramètres de l'écran tels que la largeur et la hauteur
        float halfWidth = (Screen.width * 0.5f);
        float halfHeight = (Screen.height * 0.5f);

        Rect rect = new Rect(0f, 0f, halfWidth, halfHeight);
        GUI.Box(rect, "My Rect");
    }

}
