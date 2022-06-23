using RedPanda.StateMachine;
using RedPanda.UI;
using System.Collections;
using UnityEngine;

namespace RedPanda.PointSystem
{
    public class FinishPoint : Point
    {
        #region Unity Methods
        private void OnEnable()
        {
            if (_sortingUI == null)
            {
                _sortingUI = FindObjectOfType<SortingUI>();
            }

            _sortingUI.FindFinishPoint(gameObject);
        }

        protected override void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_racerTag))
            {
                StartCoroutine(ToZero(other));
                _sortingUI.Sort();

                if (other.GetComponent<CharacterStateManager>().IsPlayer)
                {
                    WriteRandomLine(PointType.Finish);
                }
            }
        }
        #endregion Unity Methods

        #region Private Methods
        private IEnumerator ToZero(Collider other)
        {
            yield return new WaitForSeconds(0.2f);
            var character = other.GetComponent<CharacterStateManager>();
            character.Speed = 0;
            character.SwitchState(character.IdleState);
        }
        #endregion Private Methods
    }
}