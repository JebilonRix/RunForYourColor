using System.Collections.Generic;
using UnityEngine;

namespace RedPanda.ObjectPooling
{
    public class PrefabPooled2 : PrefabPooled
    {
        public void AddMeToPool()
        {
            SpawnerOnce spawner = FindObjectOfType<SpawnerOnce>();

            if (spawner == null)
            {
                Debug.Log("Sahnede pool prefab'ý yok.");
                return;
            }

            bool exist = false;

            foreach (ObjectAndLocation item in spawner.ObjAndLocList)
            {
                if (item.pooledObject == PooledObject)
                {
                    exist = true;
                    break;
                }
            }

            Location loc = new Location
            {
                Position = transform.position,
                Rotation = transform.rotation.eulerAngles,
                Scale = transform.localScale
            };

            if (exist)
            {
                foreach (ObjectAndLocation item in spawner.ObjAndLocList)
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
}