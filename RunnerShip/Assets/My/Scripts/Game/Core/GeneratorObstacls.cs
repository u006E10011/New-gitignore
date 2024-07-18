using System.Collections.Generic;
using UnityEngine;

namespace Project.Game.Core
{
    public class GeneratorObstacls : MonoBehaviour
    {
        [SerializeField] private float _tileLenght;
        [SerializeField] private float _offsetToSpawnTile;
        [SerializeField] private float _offsetToSpawnPlayer;
        [SerializeField] private int _startTiles = 2;
        [SerializeField] private int _maxCount = 4;

        private float _nextPosition;
        private GameObject _prefab;
        private Transform _player;

        [SerializeField, Space(10)] private List<GameObject> _itemPrefabs = new();

        [SerializeField, Space(10)] private Transform _container;

        private List<GameObject> _items = new();
        private List<GameObject> _activeItems = new();

        private void OnValidate() => _container = _container ? _container : _container.transform;

        private void Start()
        {
            InstantiateItem();

            for (int i = 0; i < _startTiles; i++)
                Generate();
        }

        public void Init(Transform player) => _player = player;

        private void Update()
        {
            if (_player.position.z > (_nextPosition - (_startTiles * _tileLenght)) - _offsetToSpawnPlayer)
                Generate();
        }

        private void Generate()
        {
            if (!TryFreeItem())
            {
                Generate();
                return;
            }

            SetTransform(_prefab);

            _prefab.SetActive(true);
            _activeItems.Add(_prefab);

            if (_activeItems.Count >= _maxCount)
                Return();
        }

        private void InstantiateItem()
        {
            for (int i = 0; i < _itemPrefabs.Count; i++)
            {
                GameObject item = Instantiate(_itemPrefabs[i]);
                item.transform.parent = _container;
                item.SetActive(false);

                _items.Add(item);
            }
        }

        private void Return()
        {
            _activeItems[0].SetActive(false);
            _activeItems.Remove(_activeItems[0]);
        }

        private bool TryFreeItem()
        {
            _prefab = _items[Random.Range(0, _items.Count)];

            if (_prefab.activeSelf)
                return false;

            return true;
        }

        private void SetTransform(GameObject item)
        {
            item.transform.localPosition = (Vector3.forward * _nextPosition) + new Vector3(0, 0, _offsetToSpawnTile);
            item.transform.localRotation = Quaternion.identity;

            _nextPosition += _tileLenght;
        }
    }
}

