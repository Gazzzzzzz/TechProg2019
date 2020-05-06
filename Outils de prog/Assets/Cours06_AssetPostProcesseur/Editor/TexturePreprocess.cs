using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TexturePreprocess : AssetPostprocessor
{
    // Lors de l'importation d'une texture, cette fonction sera appelée
    private void OnPreprocessTexture()
    {
        Debug.Log(assetPath);
        // Le chemin d'accès de la texture lors de son importation
        // EndsWith() => Mon string termine avec [String]
        // ToLower() => Mets le string tout en minuscule
        // Contains(string) => contient un string défini
        if(assetPath.EndsWith(".png") && assetPath.ToLower().Contains("readwrite"))
        {
            TextureImporter textureImporter = (TextureImporter)assetImporter;
            textureImporter.isReadable = true;
            textureImporter.textureType = TextureImporterType.Sprite;
        }
    }
}
