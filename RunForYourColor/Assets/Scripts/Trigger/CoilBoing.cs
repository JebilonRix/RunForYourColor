using RedPanda.StateMachine;
using UnityEngine;

namespace RedPanda
{
    public class CoilBoing : MonoBehaviour
    {
        [Range(1f, 20f)][SerializeField] private float _jumpForce = 7f;
        [Range(0.001f, 0.05f)][SerializeField] private float _reduceAmount = 0.025f;
        [SerializeField] private string _colorType = "red";
        private const string _racerTag = "Racer";

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(_racerTag))
            {
                return;
            }

            CharacterStateManager character = other.GetComponent<CharacterStateManager>();

            if (character.ColorType == _colorType)
            {
                character.Jump(_jumpForce);
            }
            else
            {
                character.Jump(_jumpForce * _reduceAmount);
            }
        }
    }
}