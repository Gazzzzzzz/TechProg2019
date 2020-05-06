using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class AssetDatabaseEditor : EditorWindow
{
    private enum AssetAction
    {
        Copy,
        Move,
        Open,
        Rename
    }
    private AssetAction m_AssetAction;

    private string m_Rename;
    private Object m_Directory;

    private Object m_AssetObject;

    [MenuItem("Tools/AssetDataBase Window...", priority = 200)]
    private static void Init()
    {
        GetWindow<AssetDatabaseEditor>().Show();
    }

    private void OnGUI()
    {
        m_AssetObject = EditorGUILayout.ObjectField("Asset Object", m_AssetObject, typeof(Object), false);

        if(GUILayout.Button("Show Asset Path"))
        {
            if (m_AssetObject != null)
            {
                //Va nous donner le chemin d'acces a partir de 'Assets/...'
                string assetPath = AssetDatabase.GetAssetPath(m_AssetObject);
                string extension = Path.GetExtension(assetPath);
                // GUID est un ID (identifiant) généré automatiquement par unity lors de son importation et ne changera jamais.
                //tres utile quand on veut une référence sur un asset même si ce dernier se fais déplace/renommer
                Debug.Log(assetPath + " | " + extension + " | " + AssetDatabase.AssetPathToGUID(assetPath));
            }
        }
        m_AssetAction = (AssetAction)EditorGUILayout.EnumPopup("Action", m_AssetAction);
        ShowActionParameters();
        EditorGUI.BeginDisabledGroup(m_AssetObject == null);
        if (GUILayout.Button(m_AssetAction.ToString() + " asset"))
        {
            string assetPath = AssetDatabase.GetAssetPath(m_AssetObject);
            bool needSave = false;
            switch (m_AssetAction)
            {
                case AssetAction.Copy:
                case AssetAction.Move:
                    //TODO Prochain cours!!!
                    break;
                case AssetAction.Rename:
                    if (!string.IsNullOrEmpty(m_Rename))
                    {
                        // permet de renommer un string si aucune erreur, renboit string vide
                        string renameMessage = AssetDatabase.RenameAsset(assetPath, m_Rename);
                        needSave = string.IsNullOrEmpty(renameMessage);
                    }
                    break;
                case AssetAction.Open:
                    //Permet d'ouvrir un asset delon le type de l'objet. unity se charge de l'ouvrir selon le bon programme
                    AssetDatabase.OpenAsset(m_AssetObject);
                    break;
            }
            if(needSave)
            {
                //Rafraici l'assetDatabase pour etre sur que tout est a jour
                AssetDatabase.Refresh();
                //Sauvegarde tous les changements dans l'assetdatabase
                AssetDatabase.SaveAssets();
            }
        }
        EditorGUI.EndDisabledGroup();
    }
    private void ShowActionParameters()
    {
        switch(m_AssetAction)
        {
            case AssetAction.Copy:
            case AssetAction.Move:    
                m_Directory = EditorGUILayout.ObjectField("Directory", m_Directory, typeof(Object), false);
                if(m_Directory != null)
                {
                    string assetPath = AssetDatabase.GetAssetPath(m_Directory);
                    string extension = Path.GetExtension(assetPath);
                    if(!string.IsNullOrEmpty(extension))
                    {
                        m_Directory = null;
                        Debug.LogWarning("This isn't a Directory");
                    }
                }
                break;
            case AssetAction.Rename:
                m_Rename = EditorGUILayout.TextField("Rename", m_Rename);
                break;
        }
    }

}
