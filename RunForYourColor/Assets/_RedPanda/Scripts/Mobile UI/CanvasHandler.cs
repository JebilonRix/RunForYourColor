using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.MobileUI
{
    [RequireComponent(typeof(CanvasScaler))]
    public class CanvasHandler : MonoBehaviour
    {
        #region Fields
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private GameObject _gamePlay;
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject _winScene;
        [SerializeField] private GameObject _gameOverScene;
        private GameObject[] _canvases; 
        #endregion

        private void Awake()
        {
            //Sets canvas scaler values.
            CanvasScaler _scaler = GetComponent<CanvasScaler>();
            _scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            _scaler.referenceResolution = new Vector2(1080, 1920);
            _scaler.matchWidthOrHeight = 1f;

            DontDestroyOnLoad(gameObject);

            if (_mainMenu != null && _gamePlay != null && _pauseMenu != null && _winScene != null && _gameOverScene != null)
            {
                _canvases = new GameObject[] { _mainMenu, _gamePlay, _pauseMenu, _winScene, _gameOverScene };
            }
        }

        internal void SetActiveCanvas(int index)
        {
            //Activates or deactivates canvases.
            for (int i = 0; i < _canvases.Length; i++)
            {
                _canvases[i].SetActive(i == index);
            }
        }
    }
}