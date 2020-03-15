using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WeaponManagerCustomWindow : ExtendedEditorWindow
{
    public static void Open(WeaponManager wpnManager)
    {
        WeaponManagerCustomWindow window = GetWindow<WeaponManagerCustomWindow>("Weapon Manager");
        window.serializedObject = new SerializedObject(wpnManager);
    }

    private void OnGUI()
    {
        currentProperty = serializedObject.FindProperty("WeaponList");
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical("box", GUILayout.MaxWidth(150), GUILayout.ExpandHeight(true));
        Drawsidebar(currentProperty);
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true));
        if(selectedProp != null)
        {
            Draw(selectedProp, true);
        }
        else
        {
            EditorGUILayout.LabelField("Select a weapon from the list");
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add"))
        {
            //
        }
        if (GUILayout.Button("Remove"))
        {
            //
        }
        EditorGUILayout.EndHorizontal();

    }
}
