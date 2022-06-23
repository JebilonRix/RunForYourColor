using System.Collections.Generic;
using UnityEngine;

namespace RedPanda.ObjectPooling
{
    [CreateAssetMenu(fileName = "SpawnerOnceHolder", menuName = "Red Panda/SpawnerOnceHolder")]
    public class SO_SpawnerOnceHolder : ScriptableObject
    {
        [SerializeField] private List<ObjectAndLocation> _objAndLocList;
        public List<ObjectAndLocation> ObjAndLocList { get => _objAndLocList; set => _objAndLocList = value; }
    }
}