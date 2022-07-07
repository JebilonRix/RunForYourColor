using UnityEngine;

namespace RedPanda.SpriteHandler
{
    [CreateAssetMenu(fileName = "Sort", menuName = "Red Panda/SpriteHandler_Sort")]
    public class SO_SpriteHandler_Sort : ScriptableObject
    {
        [Header("Sort")]
        [SerializeField] private Sprite[] _sortNumbers;

        public Sprite GetSortNumberSprite(int number)
        {
            return _sortNumbers[number];
        }
    }
}
