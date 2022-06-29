using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.UI
{
    public class RandomLine : MonoBehaviour
    {
        #region Fields
        [SerializeField] private GameObject _randomLine;
        [SerializeField] private Holder _randomholder;
        [SerializeField] private Image _image;
        [SerializeField] private float _activeTime = 1f;

        public bool isRandomLine;
        #endregion Fields

        #region Unity Methods
        private void Start()
        {
            TextActivate(false);
        }
        #endregion Unity Methods

        #region Public Methods
        public void GetRandomText()
        {
            StartCoroutine(TextAnim());
        }
        #endregion Public Methods

        #region Private Methods
        private IEnumerator TextAnim()
        {
            TextActivate(true);

            _image.overrideSprite = _randomholder.sprites[Random.Range(0, _randomholder.sprites.Length)];

            yield return new WaitForSeconds(_activeTime);

            TextActivate(false);
        }
        private void TextActivate(bool active)
        {
            _randomLine.SetActive(active);
        }
        #endregion Private Methods
    }
}