using UnityEngine;

namespace RedPanda.ObjectPooling
{
    [System.Serializable]
    public class Location
    {
        [SerializeField] private Vector3 _position;
        [SerializeField] private Vector3 _rotation;

        public Vector3 Position => _position;
        public Vector3 Rotation => _rotation;
    }
}