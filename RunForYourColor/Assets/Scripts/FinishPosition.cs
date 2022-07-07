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
        private List<HeaderHandler> _positioning = new List<HeaderHandler>();
        private Image[] _posImages;

        private void Start()
        {
            HeaderHandler[] x = FindObjectsOfType<HeaderHandler>();
            _posImages = new Image[x.Length];
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Racer") && other.gameObject.name == "NameSprite")
            {
                HeaderHandler racer = other.GetComponent<HeaderHandler>();

                _positioning.Add(racer);

                if (racer.IsPlayer)
                {
                    Finish();
                }
            }
        }
        private void Finish()
        {
            for (int i = 0; i < _posImages.Length; i++)
            {
                if (_positioning.Count < i)
                {
                    _posImages[i].sprite = _positioning[i].RacerSpriteRenderer.sprite;
                }
                else
                {
                    _posImages[i].sprite = sort.GetRandomName(false);
                }
            }
        }
    }
}