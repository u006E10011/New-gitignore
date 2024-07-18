using UnityEngine;

namespace Project.Input
{
    public class InputTouch
    {
        public static float Direction { get; private set; }

        private float _oldMousePosition;

        public void Input()
        {
            var deltaX = 0f;

            if (UnityEngine.Input.GetMouseButtonDown(0))
                _oldMousePosition = UnityEngine.Input.mousePosition.x;

            if (UnityEngine.Input.GetMouseButton(0))
            {
                 deltaX = UnityEngine.Input.mousePosition.x - _oldMousePosition;

                Direction = Mathf.Clamp(deltaX, -1f, 1f);
            }

        }
    }
}