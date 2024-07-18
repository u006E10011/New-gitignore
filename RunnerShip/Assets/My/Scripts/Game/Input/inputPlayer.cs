using UnityEngine;

namespace Project.Input
{
    public class inputPlayer : MonoBehaviour
    {
        private InputKeyboard _keyboard;
        private InputTouch _touch;

        private void Awake()
        {
            _keyboard = new();
            _touch = new ();
        }

        private void Update()
        {
            _keyboard.Input();
            _touch.Input();
        }
    }
}