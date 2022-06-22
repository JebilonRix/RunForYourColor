using System.Collections.Generic;

namespace RedPanda.ObjectPooling
{
    [System.Serializable]
    public struct ObjectAndLocation
    {
        public SO_PooledObject pooledObject;
        public List<Location> locations;
    }
}