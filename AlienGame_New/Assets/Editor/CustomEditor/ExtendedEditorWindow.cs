using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExtendedEditorWindow : EditorWindow
{
    protected SerializedObject serializedObject;
    protected SerializedProperty currentProperty;

    private string selectedPropPath;
    protected SerializedProperty selectedProp;

    protected void Draw(SerializedProperty prop, bool drawChildren)
    {
        string lastpropPath = string.Empty;
        foreach (SerializedProperty  p in prop)
        {
            if(p.isArray && p.propertyType == SerializedPropertyType.Generic)
            {
                EditorGUILayout.BeginHorizontal();
                p.isExpanded = EditorGUILayout.Foldout(p.isExpanded, p.displayName);
                EditorGUILayout.EndHorizontal();

                if (p.isExpanded)
                {
                    EditorGUI.indentLevel++;
                    Draw(p, drawChildren);
                    EditorGUI.indentLevel--;
                }
            }
            else
            {
                if(!string.IsNullOrEmpty(lastpropPath) && p.propertyPath.Contains(lastpropPath)) { continue; }
                lastpropPath = p.propertyPath;
                EditorGUILayout.PropertyField(p, drawChildren);
            }
        }
    }

    protected void Drawsidebar(SerializedProperty prop)
    {
        foreach (SerializedProperty p in prop)
        {
            if (GUILayout.Button(p.displayName))
            {
                selectedPropPath = p.propertyPath;
            }
        }

        if (!string.IsNullOrEmpty(selectedPropPath))
        {
            selectedProp = serializedObject.FindProperty(selectedPropPath);
        }
    }

}
