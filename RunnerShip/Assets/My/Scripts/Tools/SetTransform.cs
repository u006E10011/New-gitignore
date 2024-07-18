using System.Collections.Generic;
using UnityEngine;

namespace Project.Tools
{
    public class SetTransform : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField] private Vector3 _offset = new(0, 0, 160);
        [SerializeField] private Vector3 _rotation = Vector3.zero;
        [SerializeField] private Vector3 _scale = Vector3.one;

        private float _nextPosition;

        [SerializeField] private List<GameObject> _tile = new();

        private void OnValidate()
        { 
            if (Application.isEditor || Application.isPlaying)
                return;
            if (_tile.Count == 0)
                return;

            Position();
            Rotation();
            Scale();
        }

        private void Start() { } // To disable the script in the inspector

        private void Position()
        {
            for (int i = 0; i < _tile.Count; i++)
            {
                _tile[i].transform.localPosition = new Vector3(0, 0, _nextPosition);

                _nextPosition += _offset.z;

                if (_nextPosition <= (_tile.Count * _offset.z) + _nextPosition)
                    ResetPosition();
            }
        }

        private void Rotation()
        {
            for (int i = 0; i < _tile.Count; i++)
                _tile[i].transform.localRotation = Quaternion.Euler(_rotation);
        }

        private void Scale()
        {
            for (int i = 0; i < _tile.Count; i++)
                _tile[i].transform.localScale = _scale;
        }


        [ContextMenu(nameof(ResetPosition))]
        private void ResetPosition()
        {
            _nextPosition = 0;
            Position();
        }
#endif
    }
}