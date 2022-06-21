using RedPanda.StateMachine;
using System.Collections;
using UnityEngine;

namespace RedPanda.PointSystem
{
    public class FinishPoint : Point
    {
        #region Unity Methods
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Racer"))
            {
                StartCoroutine(ToZero(other));
            }
        }
        #endregion Unity Methods

        #region Private Methods
        private IEnumerator ToZero(Collider other)
        {
            yield return new WaitForSeconds(0.2f);

            other.GetComponent<CharacterStateManager>().Speed = 0;
        }
        #endregion Private Methods
    }
}