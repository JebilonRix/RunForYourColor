using RedPanda.ObjectPooling;
using UnityEditor;
using UnityEngine;

namespace RedPanda.ObjectPooling_Editor
{
    [CustomEditor(typeof(SpawnerOnce))]
    public class ObjectPoolingEditor : Editor
    {
        private SpawnerOnce spawner;

        private void OnEnable()
        {
            spawner = (SpawnerOnce)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Create Objects"))
            {
                spawner.SpawnObjects();
            }

            if (GUILayout.Button("Delete All Objects"))
            {
                spawner.ReleaseAll();
            }
        }
    }
}