using UnityEngine;

namespace RedPanda.Upgrade
{
    public class PlayerStat : CharacterStat
    {
        [SerializeField] private Swerve swerve;

        public override void UpdateSpeed(float speed)
        {
            swerve.ForwardSpeed += speed;
        }
        public override void StopCharacter()
        {
            swerve.ForwardSpeed = 0f;
        }
    }
}