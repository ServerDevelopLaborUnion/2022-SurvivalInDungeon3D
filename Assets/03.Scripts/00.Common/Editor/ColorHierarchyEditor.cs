using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColorHierarchyEditor
{
    [MenuItem("Custom/ColorHierarchy/AddColorHierarchy %H")]
    private static void CreateColorHierarchy()
    {
        GameObject[] obj = Selection.gameObjects;


        for (int i = 0; i < obj.Length; i++)
        {
            Undo.AddComponent<ColorHierarchy>(obj[i]);
        }
    }

    [MenuItem("Custom/ColorHierarchy/RemoveColorHierarchy %#H")]
    private static void RemoveColorHierarchy()
    {
        GameObject[] obj = Selection.gameObjects;


        for (int i = 0; i < obj.Length; i++)
        {
            ColorHierarchy ch = obj[i].GetComponent<ColorHierarchy>();
            if(ch != null){
                Undo.DestroyObjectImmediate(ch);
            }
        }
    }
}
