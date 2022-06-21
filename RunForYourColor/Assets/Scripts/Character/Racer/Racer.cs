using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedPanda
{
    public class Racer : MonoBehaviour
    {
        [SerializeField] private float _forwardSpeed = 7;

        public float ForwardSpeed { get => _forwardSpeed; set => _forwardSpeed = value; }
    }
}