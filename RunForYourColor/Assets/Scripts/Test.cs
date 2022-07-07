using RedPanda.PointSystem;
using RedPanda.StateMachine;
using System.Collections.Generic;
using UnityEngine;

namespace RedPanda
{
    public class Test : MonoBehaviour
    {
        public CharacterStateManager player;
        private List<CharacterStateManager> _characterList = new List<CharacterStateManager>();
        private Transform _finishPoint;

        // Start is called before the first frame update
        private void Start()
        {
            var racers = FindObjectsOfType<CharacterStateManager>();
            _finishPoint = FindObjectOfType<FinishPoint>().transform;

            foreach (var rac in racers)
            {
                _characterList.Add(rac);
            }
        }

        private float counter = 0;

        private void Update()
        {
            counter += Time.deltaTime;

            if (counter >= 2f)
            {
                GetPositioningNumber(player);
                counter = 0;
            }
        }

        public void GetPositioningNumber(CharacterStateManager manager)
        {
            float myDistance = 0f;
            float[] distances = new float[_characterList.Count];

            for (int i = 0; i < distances.Length; i++)
            {
                if (manager.ColorType == _characterList[i].ColorType)
                {
                    myDistance = Vector3.Distance(_finishPoint.position, _characterList[i].transform.position);
                }

                distances[i] = Vector3.Distance(_finishPoint.position, _characterList[i].transform.position);
            }

            int index = 0;

            for (int i = 0; i < distances.Length; i++)
            {
                if (myDistance - distances[i] > 0)
                {
                    index++;
                }
            }

            Debug.Log("index is " + index);
        }
    }
}