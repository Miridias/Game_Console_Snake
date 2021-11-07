using System;

namespace NewConsoleSnake_Kabin
{
    class Field : IDraw
    {
        public int _windowWidth;
        public int _windowHeight;
        public Field(int windowWidth, int windowHeight)
        {
            _windowWidth = windowWidth;
            _windowHeight = windowHeight;
        }
        public void Draw()
        {
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(_windowWidth + 3, _windowHeight + 3);

            Console.CursorVisible = false;
            for (int i = 0; i <= (_windowWidth + 2); i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("█");
            }
            for (int i = 0; i < _windowHeight + 2; i++)
            {
                Console.SetCursorPosition(_windowWidth + 2, i);
                Console.Write("█");
            }
            for (int i = _windowWidth + 2; i >= 0; i--)
            {
                Console.SetCursorPosition(i, _windowHeight + 2);
                Console.Write("█");
            }
            for (int i = _windowHeight + 2; i >= 0; i--)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("█");
            }
        }
    }
}
