using UnityEngine;

namespace RedPanda.SpriteHandler
{
    [CreateAssetMenu(fileName = "SpriteHandler", menuName = "Red Panda/SpriteHandler")]
    public class SO_SpriteHandler : ScriptableObject
    {
        [Header("Names")]
        [SerializeField] private Sprite _youSprite;
        [SerializeField] private Sprite[] _names;
        [Header("Flags")]
        [SerializeField] private Sprite[] _flags;
        [Header("Lines")]
        [SerializeField] private Sprite[] _endGameLines;

        public Sprite GetRandomName(bool isPlayer)
        {
            return isPlayer ? _youSprite : _names[Random.Range(0, _names.Length)];
        }
        public Sprite GetRandomFlag()
        {
            return _flags[Random.Range(0, _flags.Length)];
        }
        public Sprite GetRandomLine()
        {
            return _flags[Random.Range(0, _endGameLines.Length)];
        }
    }
}