using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.LevelHandler
{
    public class LoadingScene : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Image _progressBarFill;
        #endregion Fields

        #region Properties
        public Image ProgressBar { get => _progressBarFill; }
        #endregion Properties

        #region Unity Methods
        private void Awake()
        {
            ProgressBar.type = Image.Type.Filled;
            ProgressBar.fillMethod = Image.FillMethod.Horizontal;
            ProgressBar.fillAmount = 0;

            DontDestroyOnLoad(gameObject);
        }
        #endregion Unity Methods
    }
}