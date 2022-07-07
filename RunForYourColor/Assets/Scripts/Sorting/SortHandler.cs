using RedPanda.SpriteHandler;
using RedPanda.StateMachine;
using UnityEngine;

namespace RedPanda.Sorting
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SortHandler : MonoBehaviour
    {
        [SerializeField] private SO_SpriteHandler_Sort _handler;

        private SortingManager _sortingManager;
        private CharacterStateManager _characterStateManager;
        private SpriteRenderer _spriteRenderer;
        private float _counter = 0;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _characterStateManager = GetComponentInParent<CharacterStateManager>();
            _sortingManager = FindObjectOfType<SortingManager>();
        }
        private void Update()
        {
            if (!_sortingManager.IsStart)
            {
                Debug.Log("not start");
                return;
            }

            _counter += Time.deltaTime;

            if (_counter >= 1f)
            {
                _spriteRenderer.sprite = _handler.GetSortNumberSprite(_sortingManager.WhatIsMyPositionNumber(_characterStateManager));
                _counter = 0;
            }
        }
    }
}