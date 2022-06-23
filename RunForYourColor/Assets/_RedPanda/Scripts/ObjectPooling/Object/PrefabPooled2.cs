using System.Collections.Generic;
using UnityEngine;

namespace RedPanda.ObjectPooling
{
    public class PrefabPooled2 : PrefabPooled
    {
        private bool _isAddedToPool = false;
        public bool IsAddedToPool { get => _isAddedToPool; set => _isAddedToPool = value; }

        public void AddMeToPool()
        {
            SpawnerOnce spawner = FindObjectOfType<SpawnerOnce>();

            if (spawner == null)
            {
                Debug.Log("Sahnede pool prefab'ý yok.");
                return;
            }

            bool isListIncludeThis = false;

            foreach (ObjectAndLocation item in spawner.Holder.ObjAndLocList)
            {
                if (item.pooledObject == PooledObject)
                {
                    isListIncludeThis = true;
                    break;
                }
            }

            Location loc = new Location
            {
                Position = transform.position,
                Rotation = transform.rotation.eulerAngles,
                Scale = transform.localScale
            };

            if (isListIncludeThis)
            {
                foreach (ObjectAndLocation item in spawner.Holder.ObjAndLocList)
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

                spawner.Holder.ObjAndLocList.Add(obj);
            }

            IsAddedToPool = true;
        }
    }
}