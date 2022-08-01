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

        private int i = -1;

        public Sprite GetRandomName(bool isPlayer)
        {
            return isPlayer ? _youSprite : _names[Random.Range(0, _names.Length)];
        }
        public Sprite GetName(bool isPlayer)
        {
            if (isPlayer == false)
            {
                i++;
            }

            return isPlayer ? _youSprite : _names[i];
        }
        public Sprite GetRandomFlag(bool isPlayer)
        {
            if (isPlayer)
            {
                return null;
            }

            return _flags[Random.Range(0, _flags.Length)];
        }

        public Sprite GetRandomLine()
        {
            return _flags[Random.Range(0, _endGameLines.Length)];
        }
    }
}