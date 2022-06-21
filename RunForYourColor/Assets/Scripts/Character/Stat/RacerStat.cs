using UnityEngine;

namespace RedPanda.Upgrade
{
    public class RacerStat : CharacterStat
    {
        [SerializeField] private Racer _racer;

        public override void UpdateSpeed(float speed)
        {
            _racer.ForwardSpeed += speed;
        }
        public override void StopCharacter()
        {
            _racer.ForwardSpeed = 0f;
        }
    }
}