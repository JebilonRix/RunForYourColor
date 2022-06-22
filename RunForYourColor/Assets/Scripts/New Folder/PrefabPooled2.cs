using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR

using UnityEditor;

#endif

namespace RedPanda.ObjectPooling
{
    public class PrefabPooled2 : PrefabPooled
    {
        public void AddMeToPool()
        {
            var spawner = FindObjectOfType<SpawnerOnce>();
            bool icerir = false;

            foreach (var item in spawner.ObjAndLocList)
            {
                if (item.pooledObject == PooledObject)
                {
                    icerir = true;
                    break;
                }
            }

            Location loc = new Location
            {
                Position = transform.position,
                Rotation = transform.rotation.eulerAngles,
                Scale = transform.localScale
            };

            if (icerir)
            {
                foreach (var item in spawner.ObjAndLocList)
                {
                    if (item.pooledObject == PooledObject)
                    {
                        item.locations.Add(loc);
                    }
                }
            }
            else
            {
                ObjectAndLocation obj = new ObjectAndLocation
                {
                    pooledObject = PooledObject,
                    locations = new List<Location>()
                };

                obj.locations.Add(loc);

                spawner.ObjAndLocList.Add(obj);
            }
        }
    }

#if UNITY_EDITOR

    [CustomEditor(typeof(PrefabPooled2))]
    public class PrefabPooled2Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            PrefabPooled2 pre = (PrefabPooled2)target;

            if (GUILayout.Button("Add To Pool"))
            {
                pre.AddMeToPool();
            }
        }
    }

#endif
}