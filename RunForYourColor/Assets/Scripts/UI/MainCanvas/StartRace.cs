using RedPanda.StateMachine;
using UnityEngine;

namespace RedPanda.UI
{
    public class StartRace : MonoBehaviour
    {
        public void StarRace()
        {
            CharacterStateManager[] racers = FindObjectsOfType<CharacterStateManager>();

            //Debug.Log(racers.Length);

            foreach (CharacterStateManager race in racers)
            {
                race.StartRace();
            }
        }
    }
}