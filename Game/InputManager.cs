using Microsoft.Xna.Framework.Input;

namespace Game
{
    public class InputManager
    {
        // Members
        private KeyboardState currentKeyState;
        public KeyboardState CurrentKeyState
        {
            get { return currentKeyState; }
        }
        private KeyboardState previousKeyState;
        public KeyboardState PreviousKeyState
        {
            get { return previousKeyState; }
        }
        //Constructor
        public InputManager()
        {
            currentKeyState = new KeyboardState();
            previousKeyState = currentKeyState;
        }

        //Methods
        public void Update()
        {
            previousKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();
        }
        public bool IsKeyPressed(Keys key)
        {
            return CurrentKeyState.IsKeyDown(key);
        }
        public bool IsKeyJustPressed(Keys key)
        {
            return CurrentKeyState.IsKeyDown(key) && !PreviousKeyState.IsKeyDown(key);
        }
        public bool IsKeyReleased(Keys key)
        {
            return CurrentKeyState.IsKeyUp(key);
        }
        public bool IsKeyJustReleased(Keys key)
        {
            return CurrentKeyState.IsKeyUp(key) && !PreviousKeyState.IsKeyUp(key);
        }
    }
}
