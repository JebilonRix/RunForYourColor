using UnityEngine;

namespace RedPanda.MobileUI
{
    [CreateAssetMenu(fileName = "UiManager", menuName = "Red Panda/Manager/Ui")]
    public class SO_UiManager : ScriptableObject
    {
        #region Fields
        [SerializeField] private CanvasHandler _canvasHandler;

        private UserInterfaceState _interfaceState;
        #endregion Fields

        #region Unity Methods
        private void OnEnable()
        {
            _interfaceState = UserInterfaceState.MainMenu;
        }
        #endregion Unity Methods

        #region Public Methods
        public void To_MainMenu() => State(UserInterfaceState.MainMenu, false);
        public void To_Game(bool startStopTime) => State(UserInterfaceState.GamePlay, startStopTime);
        public void To_Pause(bool startStopTime) => State(UserInterfaceState.PauseMenu, startStopTime);
        public void To_Win() => State(UserInterfaceState.WinScene, false);
        public void To_GameOver() => State(UserInterfaceState.GameOver, false);
        #endregion Public Methods

        #region Private Methods
        // This method activates or deactivates canvases
        private void State(UserInterfaceState state, bool setTime)
        {
            _interfaceState = state;

            switch (_interfaceState)
            {
                case UserInterfaceState.MainMenu:
                    _canvasHandler.SetActiveCanvas(0);
                    break;

                case UserInterfaceState.GamePlay:
                    _canvasHandler.SetActiveCanvas(1);

                    if (setTime)
                    {
                        Time.timeScale = 1f;
                    }
                    break;

                case UserInterfaceState.PauseMenu:
                    _canvasHandler.SetActiveCanvas(2);

                    if (setTime)
                    {
                        Time.timeScale = 0f;
                    }
                    break;

                case UserInterfaceState.WinScene:
                    _canvasHandler.SetActiveCanvas(3);
                    break;

                case UserInterfaceState.GameOver:
                    _canvasHandler.SetActiveCanvas(4);
                    break;
            }
        }
        #endregion Private Methods
    }
}