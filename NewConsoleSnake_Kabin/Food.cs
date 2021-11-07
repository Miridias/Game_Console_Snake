using System;

namespace NewConsoleSnake_Kabin
{
    class Food : IFood
    {
        Field field;
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        
        public Food(Field field)
        {
            this.field = field;
        }
        public void Draw()
        {
            Random rnd = new Random();
            XPosition = rnd.Next(1, field._windowWidth + 1);
            YPosition = rnd.Next(1, field._windowHeight + 1);
            Console.SetCursorPosition(XPosition,YPosition);
            Console.WriteLine("$");
        }
    }
}
