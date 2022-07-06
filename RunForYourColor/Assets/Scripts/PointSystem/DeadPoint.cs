using UnityEngine;

namespace RedPanda.PointSystem
{
    public class DeadPoint : Point
    {
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

            if (other.CompareTag(_racerTag))
            {
                _stateManager.ToRespawn();
            }
        }
    }
}