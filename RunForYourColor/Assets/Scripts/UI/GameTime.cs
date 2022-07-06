using UnityEngine;

namespace RedPanda.UI
{
    public class GameTime : MonoBehaviour
    {
        private void OnEnable()
        {
            Time.timeScale = 0f;
        }
        private void OnDisable()
        {
            Time.timeScale = 1f;
        }
    }
}