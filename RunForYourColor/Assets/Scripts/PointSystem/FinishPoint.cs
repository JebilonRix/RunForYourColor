using RedPanda.StateMachine;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace RedPanda.PointSystem
{
    public class FinishPoint : Point
    {
        [SerializeField] private UnityEvent _unityEvent;

        #region Unity Methods

        private void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag(_racerTag))
            {
                CharacterStateManager character = other.GetComponent<CharacterStateManager>();

                character.AnimHandler("Victory");
                StartCoroutine(ToZero(character));

                if (character.IsPlayer)
                {
                    _unityEvent?.Invoke();
                }
            }
        }
        #endregion Unity Methods

        #region Private Methods
        private IEnumerator ToZero(CharacterStateManager chr)
        {
            yield return new WaitForSeconds(0.2f);

            chr.Speed = 0;
        }
        #endregion Private Methods
    }
}