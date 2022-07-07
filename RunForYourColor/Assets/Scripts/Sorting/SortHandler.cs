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
                return;
            }

            _spriteRenderer.sprite = _handler.GetSortNumberSprite(_sortingManager.WhatIsMyPositionNumber(_characterStateManager));
        }
    }
}