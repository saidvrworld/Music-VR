using UnityEngine;
using System.Collections;
using UnityEditor;
using System;


[CustomEditor(typeof(VisWavePropertyModifierEditor))]
public class VisWavePropertyModifierEditor : VisBasePropertyModifierEditor
{
    public VisWavePropertyModifierEditor()
    {
        showAutomaticInspectorGUI = false;
    }

    protected override void CustomInspectorGUI()
    {
        base.CustomInspectorGUI();
        VisWavePropertyModifier modifier = target as VisWavePropertyModifier;
        // VisWavePropertyModifier modifier = target as VisWavePropertyModifier;
        if (modifier == null)
            return;

        modifier.param = (WaveProperty)EditorGUILayout.EnumPopup("\tWave Property", (Enum)modifier.param);
    }
}