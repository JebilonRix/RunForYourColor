using UnityEngine;

namespace RedPanda
{
    [RequireComponent(typeof(Animator))]
    public class YayAnimHandler : MonoBehaviour
    {
        [SerializeField] private string _racerTag = "Racer";
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_racerTag))
            {
                animator.SetTrigger("Jump");
            }
        }
    }
}