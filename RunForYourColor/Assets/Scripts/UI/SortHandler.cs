using RedPanda.PointSystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.UI
{
    public class SortHandler : MonoBehaviour
    {
        [SerializeField] private List<Image> _images;

        private GameObject _player;
        private GameObject _bot1;
        private GameObject _bot2;

        private Sprite _playerSprite;
        private Sprite _bot1Sprite;
        private Sprite _bot2Sprite;

        private Transform _finishPoint;

        private void Start()
        {
            _finishPoint = FindObjectOfType<FinishPoint>().transform;

            GameObject[] racers = GameObject.FindGameObjectsWithTag("Racer");
            _player = racers[0];
            _bot1 = racers[1];
            _bot2 = racers[2];

            _playerSprite = _player.GetComponent<SpriteRenderer>().sprite;
            _bot1Sprite = _bot1.GetComponent<SpriteRenderer>().sprite;
            _bot2Sprite = _bot2.GetComponent<SpriteRenderer>().sprite;

            InvokeRepeating(nameof(Sort), 0f, 1f);
        }

        private void Sort()
        {
            Dictionary<float, Sprite> sort = new Dictionary<float, Sprite>();

            float player = Vector3.Distance(transform.position, _player.transform.position);
            float bot1 = Vector3.Distance(transform.position, _bot1.transform.position);
            float bot2 = Vector3.Distance(transform.position, _bot2.transform.position);

            sort.Add(bot1, _bot1Sprite);
            sort.Add(player, _playerSprite);
            sort.Add(bot2, _bot2Sprite);

            sort = sort.OrderByDescending(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            for (int i = 0; i < _images.Count; i++)
            {
                _images[i].sprite = GetSprite(sort);
            }
        }

        private Sprite GetSprite(Dictionary<float, Sprite> sort)
        {
            Sprite ret = sort.FirstOrDefault().Value;
            sort.Remove(sort.FirstOrDefault().Key);
            return ret;
        }
    }
}