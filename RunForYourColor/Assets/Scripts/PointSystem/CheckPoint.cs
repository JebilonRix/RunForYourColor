using UnityEngine;

namespace RedPanda.PointSystem
{
    [RequireComponent(typeof(MeshRenderer))]
    public class CheckPoint : Point
    {
        [SerializeField] private Material blueMaterial;
        [SerializeField] private Material redMaterial;
        [SerializeField] private Material yellowMaterial;

        private void Start()
        {
            var renderer = GetComponent<MeshRenderer>();

            Material material = renderer.materials[0];

            if (_colorType == "blue")
            {
                material = blueMaterial;
            }
            else if (_colorType == "red")
            {
                material = redMaterial;
            }
            else if (_colorType == "yellow")
            {
                material = yellowMaterial;
            }

            renderer.material = material;
        }
        #region Unity Methods
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

            if (other.CompareTag(_racerTag))
            {
                SortInTrigger();

                _stateManager.SetCheckPoint(transform);
                SpeedChange(_stateManager, _speedAddAmount);

                if (_stateManager.IsPlayer)
                {
                    WriteRandomLine(PointType.Check);
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(_racerTag))
            {
                SortInTrigger();
            }
        }
        #endregion Unity Methods
    }
}