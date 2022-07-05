using RedPanda.StateMachine;
using UnityEngine;

namespace RedPanda
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Animator))]
    public class YayAnimHandler : MonoBehaviour
    {
        [SerializeField] private string _racerTag = "Racer";
        private Animator animator;

        private void Awake()
        {
            GetComponent<BoxCollider>().isTrigger = true;
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.Play("YayAnim", 0);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_racerTag))
            {
                other.GetComponent<CharacterStateManager>().Jump();

                animator.Play("YayAnim", 0);
            }
        }
    }
}