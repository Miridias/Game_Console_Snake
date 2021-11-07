namespace NewConsoleSnake_Kabin
{
    class Point : IPoint
    {
        public int XPosition {get; set;}
        public int YPosition {get; set;}

        public Point(int xPosition, int yPosition)
        {
            XPosition = xPosition;
            YPosition = yPosition;
        }
    }
}
