using UnityEngine;

namespace RedPanda.UI
{
    public class CanvasHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _finishUi;

        private void Start()
        {
            _finishUi.SetActive(false);
        }
    }
}