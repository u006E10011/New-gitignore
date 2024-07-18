using UnityEngine;

namespace Project.Game.Player
{
    public class CameraFollover : MonoBehaviour
    {
        [SerializeField] private float _smoothing;

        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;

        private void FixedUpdate() => Move();

        private void Move()
        {
            var nextPosition = Vector3.Lerp(transform.position, _target.position + _offset, _smoothing * Time.deltaTime);

            transform.position = nextPosition;
        }
    }

}