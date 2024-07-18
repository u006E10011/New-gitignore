using System.Collections.Generic;
using UnityEngine;

namespace Project.Tools
{
    public class Generator : MonoBehaviour
    {
        [SerializeField, Min(0), Range(0, 200)] private int _minCount, _maxCount;
        [SerializeField] private int _maxScale, _minScale;
        [SerializeField] private bool _isRandom;
        private int _currentItem => _children.Count;

        [SerializeField, Space(10)] private Vector3 _radius;
        [SerializeField] private Vector3 _offset;

        [SerializeField, Space(10)] private Transform _container;

        [SerializeField, Space(10)] private List<GameObject> _item;
        [SerializeField] private List<GameObject> _children;

        [ContextMenu(nameof(Generate))]
        private void Generate()
        {
            CLear();

            int count = _isRandom ? Random.Range(_minCount, _maxCount) : _maxCount;

            for (int i = 0; i < count; i++)
            {
                GameObject obj = Instantiate(_item[Random.Range(0, _item.Count)], Position() + _offset, Quaternion.identity, _container);
                _children.Add(obj);
            }
        }

        [ContextMenu(nameof(Delete))]
        private void Delete()
        {
            for (int i = _children.Count - 1; _currentItem >= _maxCount; i--)
            {
                DestroyImmediate(_children[i]);
                _children.Remove(_children[i]);
            }
        }

        [ContextMenu(nameof(Rotation))]
        public void Rotation() => RandomTransform.Rotate(_children);

        [ContextMenu(nameof(Scale))]
        public void Scale() => RandomTransform.Scale(_children, _maxScale, _minScale);

        [ContextMenu(nameof(Add))]
        private void Add()
        {
            _children = new();

            for (int i = 0; i < _container.childCount; i++)
                _children.Add(_container.GetChild(i).gameObject);
        }

        [ContextMenu(nameof(CLear))]
        private void CLear()
        {
            if (_children.Count == 0)
                return;

            Debug.Log($"Current item to Cleat {_children.Count}");

            for (int i = 0; i < _children.Count; i++)
                DestroyImmediate(_children[i]);

            _children = new();
        }

        private Vector3 Position()
        {
            return new Vector3
            {
                x = Random.Range(-_radius.x, _radius.x),
                y = Random.Range(-_radius.y, _radius.y),
                z = Random.Range(-_radius.z, _radius.z)
            };
        }


    }
}
