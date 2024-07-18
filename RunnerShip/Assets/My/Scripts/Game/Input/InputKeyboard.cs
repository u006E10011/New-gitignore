namespace Project.Input
{
    public  class InputKeyboard
    {
        public static float Direction { get; private set; }

        public const string HORIZONTAL = "Horizontal";

        public void Input()
        {
            Direction = UnityEngine.Input.GetAxis(HORIZONTAL);
        }
    }
}