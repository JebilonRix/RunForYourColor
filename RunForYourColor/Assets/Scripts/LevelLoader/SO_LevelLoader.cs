using UnityEngine;
using UnityEngine.SceneManagement;

namespace RedPanda
{
    [CreateAssetMenu(fileName = "LevelLoader", menuName = "Red Panda/Level Loader")]
    public class SO_LevelLoader : ScriptableObject
    {
        public void LevelLoad()
        {
            int index = SceneManager.GetActiveScene().buildIndex + 1;

            if (index > SceneManager.sceneCount)
            {
                index = SceneManager.sceneCount;
            }

            SceneManager.LoadScene(index);
        }

        public void LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }
        public void LoadNextLevel()
        {
            if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCount)
            {
                SceneManager.LoadScene(0);
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}