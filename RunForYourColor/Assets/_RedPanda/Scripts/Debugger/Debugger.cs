using UnityEngine;
using UnityEngine.SceneManagement;

namespace RedPanda.Debugger
{
    public class Debugger : MonoBehaviour
    {
        #region Fields
        public KeyCode reloadScene = KeyCode.F1;
        #endregion Fields

        #region Unity Methods
        private void Update()
        {
            if (Input.GetKeyDown(reloadScene))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        #endregion Unity Methods
    }
}