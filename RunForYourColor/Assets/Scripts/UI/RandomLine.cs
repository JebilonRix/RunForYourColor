using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.UI
{
    public class RandomLine : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Text _randomLineText;
        [SerializeField] private float _activeTime = 1f;
        #endregion Fields

        #region Unity Methods
        private void Start()
        {
            TextActivate(false);
        }
        #endregion Unity Methods

        #region Public Methods
        public void TextAnimation(string text)
        {
            StartCoroutine(TextAnim(text));
        }
        #endregion Public Methods

        #region Private Methods
        private IEnumerator TextAnim(string text)
        {
            TextActivate(true);

            _randomLineText.text = text;

            yield return new WaitForSeconds(_activeTime);

            TextActivate(false);
        }
        private void TextActivate(bool active)
        {
            _randomLineText.gameObject.SetActive(active);
        }
        #endregion Private Methods
    }
}