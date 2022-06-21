using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.SceneManagement.SceneManager;

namespace RedPanda.LevelHandler
{
    [CreateAssetMenu(fileName = "LevelHandler", menuName = "Red Panda/Level Handler")]
    public class SO_LevelHandler : ScriptableObject
    {
        #region Fields
        [SerializeField] private LoadingScene _loadingScenePrefab;
        #endregion Fields

        #region Public Methods
        public async void LoadScene(string _sceneName)
        {
            if (_loadingScenePrefab != null)
            {
                _loadingScenePrefab.gameObject.SetActive(true);
            }

            AsyncOperation scene = LoadSceneAsync(_sceneName);

            await LoadTheScene(scene);
        }
        public void QuitGame()
        {
            Application.Quit();
        }
        #endregion Public Methods

        #region Private Methods
        private async Task LoadTheScene(AsyncOperation scene)
        {
            scene.allowSceneActivation = false;

            do
            {
                await Task.Delay(100);

                if (_loadingScenePrefab != null)
                {
                    _loadingScenePrefab.ProgressBar.fillAmount = scene.progress;
                }
            }
            while (scene.progress < 0.9f);

            scene.allowSceneActivation = true;

            if (_loadingScenePrefab != null)
            {
                _loadingScenePrefab.ProgressBar.fillAmount = 0;
                _loadingScenePrefab.gameObject.SetActive(false);
            }
        }
        #endregion Private Methods
    }
}