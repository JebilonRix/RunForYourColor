using RedPanda.Upgrade;
using UnityEngine;

namespace RedPanda.PointSystem
{
    public class FinishPoint : Point
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_playerTag))
            {
                PlayerStat _player = other.GetComponent<PlayerStat>();
                _player.StopCharacter();
            }
            else if (other.CompareTag(_racerTag))
            {
                RacerStat _racer = other.GetComponent<RacerStat>();
                _racer.StopCharacter();
            }
        }
    }
}