using RedPanda.StateMachine;
using RedPanda.UI;
using System.Collections;
using UnityEngine;

namespace RedPanda.PointSystem
{
    public class FinishPoint : Point
    {
        [SerializeField] private RandomLine randomLine;

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
            base.OnTriggerEnter(other);

            if (other.CompareTag(_racerTag))
            {
                if (randomLine == null)
                {
                    var x = FindObjectsOfType<RandomLine>(true);

                    foreach (var item in x)
                    {
                        if (!item.isRandomLine)
                        {
                            randomLine = item;
                            break;
                        }
                    }
                }

                var character = other.GetComponent<CharacterStateManager>();

                character.AnimHandler("Victory");
                StartCoroutine(ToZero(character));

                if (character.IsPlayer)
                {
                    _randomLine.GetRandomText();
                }

                _sortingUI.Sort();
                _sortingUI.FinishUi.SetActive(true);
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