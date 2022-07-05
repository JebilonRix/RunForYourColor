using UnityEngine;

namespace RedPanda.PointSystem
{
    public class JumpPoint : Point
    {
        [SerializeField] private float jumpForce = 500f;
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

            //if (other.CompareTag(_racerTag) && other.GetComponent<CharacterStateManager>().ColorType == ColorType)
            //{
            //    other.GetComponent<CharacterStateManager>().Rb.AddForce(new Vector3(0, jumpForce, 0));
            //}
        }
    }
}