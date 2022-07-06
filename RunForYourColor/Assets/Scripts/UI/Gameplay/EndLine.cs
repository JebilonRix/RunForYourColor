using RedPanda.SpriteHandler;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.UI
{
    [RequireComponent(typeof(Image))]
    public class EndLine : MonoBehaviour
    {
        #region Fields
        [SerializeField] private SO_SpriteHandler _lineHolder;
        [SerializeField] private float _activeTime = 1f;
        private Image _image;
        #endregion Fields

        #region Unity Methods
        private void Awake() => _image = GetComponent<Image>();
        private void Start() => TextActivate(false);
        #endregion Unity Methods

        #region Public Methods
        public void GetRandomText() => StartCoroutine(TextAnim());
        #endregion Public Methods

        #region Private Methods
        private IEnumerator TextAnim()
        {
            TextActivate(true);

            _image.overrideSprite = _lineHolder.GetRandomLine();

            yield return new WaitForSeconds(_activeTime);

            TextActivate(false);
        }
        private void TextActivate(bool active) => _image.enabled = active;

        #endregion Private Methods
    }
}