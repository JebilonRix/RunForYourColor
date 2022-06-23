using RedPanda.ObjectPooling;
using UnityEditor;
using UnityEngine;

namespace RedPanda.ObjectPooling_Editor
{
    [CustomEditor(typeof(SpawnerOnce))]
    public class ObjectPoolingEditor : Editor
    {
        private SpawnerOnce spawner;
        private bool _isSeen = false;

        private void OnEnable()
        {
            spawner = (SpawnerOnce)target;
        }
        private void OnDisable()
        {
            if (_isSeen)
            {
                spawner.DeleteObjs(FindObjectsOfType<PrefabPooled2>(true));
            }

            _isSeen = false;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Finish Level"))
            {
                var prefabs = FindObjectsOfType<PrefabPooled2>(true);

                for (int i = 0; i < prefabs.Length; i++)
                {
                    if (!prefabs[i].IsAddedToPool)
                    {
                        prefabs[i].AddMeToPool();
                        //prefabs[i].OnRelease();
                    }
                }

                spawner.DeleteObjs(prefabs);
            }

            if (GUILayout.Button("See Level"))
            {
                if (_isSeen)
                {
                    return;
                }

                spawner.SeeLevel();
                _isSeen = true;
            }

            if (GUILayout.Button("Reset List"))
            {
                spawner.ResetList(FindObjectsOfType<PrefabPooled2>(true));
            }

            if (GUILayout.Button("Delete Level"))
            {
                spawner.DeleteAndDestroyAll(FindObjectsOfType<PrefabPooled2>(true));
            }
        }
    }
}