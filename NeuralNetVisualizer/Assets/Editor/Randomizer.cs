using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Randomizer : EditorWindow
{
    bool randomX;
    bool randomY;
    bool randomZ;

    [MenuItem("BellaDevTools/Randomizer")]
    static void Init()
    {
        Randomizer window = (Randomizer)GetWindow(typeof(Randomizer));
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("Radomized selected object", EditorStyles.boldLabel);

        randomX = EditorGUILayout.Toggle("Randomize X", randomX);
        randomY = EditorGUILayout.Toggle("Randomize Y", randomY);
        randomZ = EditorGUILayout.Toggle("Randomize Z", randomZ);

        if (GUILayout.Button("Randomize"))
        {
            foreach(GameObject go in Selection.gameObjects)
            {
                go.transform.rotation = Quaternion.Euler(GetRandomRotations(go.transform.rotation.eulerAngles));
            }
        }
    }

    private Vector3 GetRandomRotations(Vector3 current)
    {
        float x = randomX ? Random.Range(0f, 360f) : current.x;
        float y = randomY ? Random.Range(0f, 360f) : current.y;
        float z = randomZ ? Random.Range(0f, 360f) : current.z;

        current.x = x;
        current.y = y;
        current.z = z;
        return current;
    }
}
