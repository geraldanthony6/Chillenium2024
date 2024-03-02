using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FieldOfViewEditor))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        PoliceMovement fow = (PoliceMovement)target;
    }
}
