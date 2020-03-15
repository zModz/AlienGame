using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

public class AssetHandler
{
    [OnOpenAsset()]
    public static bool OpenEditor(int instanceID, int line)
    {
        WeaponManager obj = EditorUtility.InstanceIDToObject(instanceID) as WeaponManager;
        if (obj != null)
        {
            WeaponManagerCustomWindow.Open(obj);
            return true;
        }
        return false;
    }
}

[CustomEditor(typeof(WeaponManager))]
public class WeaponManagerCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if(GUILayout.Button("Open Editor"))
        {
            WeaponManagerCustomWindow.Open((WeaponManager)target);
        }
    }
}
