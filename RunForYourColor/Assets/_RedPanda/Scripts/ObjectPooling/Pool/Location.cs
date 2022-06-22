using UnityEngine;

namespace RedPanda.ObjectPooling
{
    [System.Serializable]
    public class Location
    {
        [SerializeField] private Vector3 _position;
        [SerializeField] private Vector3 _rotation;
        [SerializeField] private Vector3 _scale = new Vector3(1, 1, 1);

        public Vector3 Position { get => _position; set => _position = value; }
        public Vector3 Rotation { get => _rotation; set => _rotation = value; }
        public Vector3 Scale { get => _scale; set => _scale = value; }
    }
}