using RedPanda.ObjectPooling;
using UnityEditor;
using UnityEngine;

namespace RedPanda.ObjectPooling_Editor
{
    [CustomEditor(typeof(SpawnerOnce))]
    public class ObjectPoolingEditor : Editor
    {
        private SpawnerOnce spawner;
        private bool _isFinished = false;
        private bool _isSeen = false;

        private void OnEnable()
        {
            spawner = (SpawnerOnce)target;
        }
        private void OnDisable()
        {
            spawner.ReleaseAll();
            _isFinished = false;
            _isSeen = false;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Finish Level"))
            {
                _isFinished = true;
                spawner.ReleaseAll();
            }

            if (GUILayout.Button("See Level"))
            {
                if (_isSeen)
                {
                    return;
                }

                if (_isFinished)
                {
                    spawner.SpawnObjects();
                    _isSeen = true;
                }
                else
                {
                    Debug.Log("Please, finish level first.");
                }
            }
            if (GUILayout.Button("Delete Level"))
            {
                spawner.DeleteAll();
            }
        }
    }
}