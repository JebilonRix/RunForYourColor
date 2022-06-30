using RedPanda.UI;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.PointSystem
{
    public class CheckPoint : Point
    {
        [SerializeField] private RandomLine randomLine;
        [SerializeField] private Image _fillImage;
        [SerializeField] private float _fillTime = 1f;
        private bool _passed;

        #region Unity Methods
        private void Start()
        {
            _passed = false;
            _fillImage.fillAmount = 0f;
        }
        private void Update()
        {
            if (!_passed)
            {
                return;
            }

            _fillImage.fillAmount += Mathf.Lerp(0.0f, 1.0f, _fillTime * Time.deltaTime);
        }
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

            if (other.CompareTag(_racerTag))
            {
                if (randomLine == null)
                {
                    RandomLine[] x = FindObjectsOfType<RandomLine>(true);

                    foreach (RandomLine item in x)
                    {
                        if (item.isRandomLine)
                        {
                            randomLine = item;
                            break;
                        }
                    }
                }

                _passed = true;

                SortInTrigger();

                _stateManager.SetCheckPoint(transform);

                SpeedChange(_stateManager, _speedAddAmount);

                if (_stateManager.IsPlayer)
                {
                    randomLine.GetRandomText();
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(_racerTag))
            {
                SortInTrigger();
            }
        }
        #endregion Unity Methods
    }
}