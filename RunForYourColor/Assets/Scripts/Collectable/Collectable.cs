using RedPanda.ObjectPooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedPanda.Collectable
{
    [RequireComponent(typeof(SphereCollider))]
    public class Collectable : MonoBehaviour,IPooled
    {
       [field:SerializeField] public SO_PooledObject PooledObject { get; set ; }

        public void OnRelease()
        {
           
        }

        public void OnStart()
        {
           
        }

        private void Awake()
        {
            GetComponent<SphereCollider>().isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
               
            }
        }
    } 
}