using UnityEngine;

namespace RedPanda.Character
{
    public class CharacterHandler : MonoBehaviour
    {
        [SerializeField] private GameObject[] _characters;
        [SerializeField] private SO_Character _characterData;

        private void Start()
        {
            SetColor();
        }
        public void SetColor()
        {
            _characterData.GetColor(_characters);
        }
    }
}