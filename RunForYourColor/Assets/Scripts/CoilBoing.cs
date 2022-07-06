using RedPanda.StateMachine;
using System.Collections;
using UnityEngine;

namespace RedPanda
{
    public class CoilBoing : MonoBehaviour
    {
        [SerializeField] private float startScaleY = 0.3f;
        [SerializeField] private float endScaleY = 4f;

        private const string _racerTag = "Racer";
        private Vector3 startScale;
        private Vector3 endScale;

        private void Start()
        {
            startScale = new Vector3(transform.localScale.x, startScaleY, transform.localScale.z);
            endScale = new Vector3(transform.localScale.x, endScaleY, transform.localScale.z);

            transform.localScale = startScale;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_racerTag))
            {
                other.GetComponent<CharacterStateManager>().Jump();

                StartCoroutine(Delay());
            }
        }

        private IEnumerator Delay()
        {
            yield return new WaitForSeconds(0.15f);
            transform.localScale = Vector3.Lerp(startScale, endScale, 1f);
        }
    }
}