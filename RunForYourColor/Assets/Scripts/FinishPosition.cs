using RedPanda.SpriteHandler;
using RedPanda.StateMachine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda
{
    public class FinishPosition : MonoBehaviour
    {
        [SerializeField] private SO_SpriteHandler sort;
        [SerializeField] private Image[] _posImages;
        private List<HeaderHandler> _positioning = new List<HeaderHandler>();

        //private GameObject[] test;

        //private void Start()
        //{
        //    test = GameObject.FindGameObjectsWithTag("NameLine");
        //}

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Racer") == false)
            {
                return;
            }

            HeaderHandler racer = other.GetComponent<HeaderHandler>();

            _positioning.Add(racer);

            if (other.GetComponent<CharacterStateManager>().IsPlayer)
            {
                Finish(_positioning.LastIndexOf(racer));
            }
        }
        private void Finish(int playerIndex)
        {
            for (int i = 0; i < _posImages.Length; i++)
            {
                _posImages[i].sprite = sort.GetRandomName(playerIndex == i);
            }
        }
    }
}