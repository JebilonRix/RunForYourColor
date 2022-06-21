using RedPanda.Upgrade;
using UnityEngine;

namespace RedPanda.PointSystem
{
    public class CheckPoint : Point
    {
        [SerializeField] private float _speedAddAmount = 1f;

        protected override void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_playerTag))
            {
                SpeedChange(other.GetComponent<PlayerStat>());
            }
            else if (other.CompareTag(_racerTag))
            {
                SpeedChange(other.GetComponent<RacerStat>());
            }
        }

        private void SpeedChange(CharacterStat character)
        {
            if (character.ColorType == _colorType)
            {
                character.UpdateSpeed(_speedAddAmount);
            }
            else
            {
                character.UpdateSpeed(-_speedAddAmount);
            }
        }
    }
}