using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

[CustomEditor(typeof(VisLightPropertyModifier))]
public class VisLightPropertyModifierEditor : VisBasePropertyModifierEditor 
{
    public VisLightPropertyModifierEditor()
    {
        showAutomaticInspectorGUI = false;
    }

    protected override void CustomInspectorGUI()
    {
        base.CustomInspectorGUI();

        VisLightPropertyModifier modifier = target as VisLightPropertyModifier;
        if (modifier == null)
            return;

        modifier.param = (WaveProperty)EditorGUILayout.EnumPopup("\tTarget Property", (Enum)modifier.param);
    }
}