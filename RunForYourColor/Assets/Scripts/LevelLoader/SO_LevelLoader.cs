using UnityEngine;
using UnityEngine.SceneManagement;

namespace RedPanda
{
    [CreateAssetMenu(fileName = "LevelLoader", menuName = "Red Panda/Level Loader")]
    public class SO_LevelLoader : ScriptableObject
    {
        public void LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }
    }
}