using System;
using System.Threading;

namespace NewConsoleSnake_Kabin
{
    class SnakeGame : Game
    {
        Field field;
        Food food;
        Snake snake;
        public int score;
        public int time;
        public bool snakeLive;

        public override void StartGame()
        {
            Setup();
            field.Draw();
            food.Draw();
            snake.CreateSnake();
            while (snakeLive)
            {
                snake.Move();
                snake.Draw();
                snake.KeyPressHandle();
                Thread.Sleep(time);
            }
            if (!snakeLive)
            {
                EndGame();
            }
        }
        public override void Setup()
        {
            int windowWidth = 50;
            int windowHeight = 25;
            field = new Field(windowWidth, windowHeight);
            food = new Food(field);
            snake = new Snake(field, food, this);
            score = 0;
            time = 300;
            snakeLive = true;
        }
        public override void EndGame()
        {
            Console.Clear();
            field.Draw();
            Console.SetCursorPosition(field._windowWidth / 2 - 2, field._windowHeight / 2 + 1);
            Console.WriteLine("Game Over!");
            Console.SetCursorPosition(field._windowWidth / 2 - 3, field._windowHeight / 2 + 2);
            Console.Write("You score: {0}", score);
            Console.SetCursorPosition(field._windowWidth / 2 - 17, field._windowHeight / 2 + 3);
            Console.Write("Нажмите клавишу R чтобы начать игру снова");
            Console.SetCursorPosition(field._windowWidth / 2 - 10, field._windowHeight / 2 + 4);
            Console.Write("или Esc чтобы выйти из игры");
            if (RetryGame())
            {
                Console.Clear();
                StartGame();
            }
        }
        public override bool RetryGame()
        {
            while (true)
            {
                ConsoleKey restart = Console.ReadKey(true).Key;

                if (restart == ConsoleKey.R)
                {
                    return true;
                }
                else if (restart == ConsoleKey.Escape)
                {
                    return false;
                }
                Console.SetCursorPosition(field._windowWidth / 2 - 9, field._windowHeight / 2 + 5);
                Console.WriteLine("Вы ввели неверный символ");
            }
        }
    }
}
