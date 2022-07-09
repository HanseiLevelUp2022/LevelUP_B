using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    GameManager script;

    public void OnValidate()
    {

    }

    public override void OnInspectorGUI()
    {

    }

    private void OnEnable()
    {
        script = target as GameManager;
    }
}
