using RedPanda.StateMachine;
using UnityEngine;

namespace RedPanda.UI
{
    public class StartRace : MonoBehaviour
    {
       CharacterStateManager _playerRacer;

        public void StartRacer()
        {
            if (_playerRacer == null)
            {
                _playerRacer = FindObjectOfType<CharacterStateManager>();
            }

            _playerRacer.StartRace();
        }
    }
}