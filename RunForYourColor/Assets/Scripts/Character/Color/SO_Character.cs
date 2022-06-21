using System.Collections.Generic;
using UnityEngine;

namespace RedPanda.Character
{
    [CreateAssetMenu(fileName = "Character", menuName = "Red Panda/Character")]
    public class SO_Character : ScriptableObject
    {
        [SerializeField] private List<Material> _colorMaterial = new List<Material>();

        public void GetColor(GameObject[] racers)
        {
            _colorMaterial.Shuffle();

            for (int i = 0; i < _colorMaterial.Count; i++)
            {
                racers[i].GetComponent<MeshRenderer>().material = _colorMaterial[i];
            }
        }
    }
}