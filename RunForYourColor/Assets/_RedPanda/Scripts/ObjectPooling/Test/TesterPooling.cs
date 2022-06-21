using UnityEngine;

namespace RedPanda.ObjectPooling
{
    public class TesterPooling : MonoBehaviour
    {
        [SerializeField] private KeyCode Stop = KeyCode.Space;
        [SerializeField] private KeyCode first = KeyCode.C;
        [SerializeField] private KeyCode second = KeyCode.X;
        [SerializeField] private KeyCode third = KeyCode.V;

        [SerializeField] private SpawnerDifferentObjects sp;
        [SerializeField] private SpawnerSpecificPoints sp2;
        [SerializeField] private SpawnerSimple sp3;

        private void Update()
        {
            if (Input.GetKeyDown(first))
            {
                sp.StartSpawner();
            }
            if (Input.GetKeyDown(second))
            {
                sp2.StartSpawner();
            }
            if (Input.GetKeyDown(third))
            {
                sp3.StartSpawner();
            }
            if (Input.GetKeyDown(Stop))
            {
                if (sp != null)
                {
                    sp.StopSpawnerAndClear();
                }

                if (sp2 != null)
                {
                    sp2.StopSpawnerAndClear();
                }

                if (sp3 != null)
                {
                    sp3.StopSpawnerAndClear();
                }
            }
        }
    }
}