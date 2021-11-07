using System;

namespace NewConsoleSnake_Kabin
{
    class Snake : IAnimal
    {
        Food food;
        Field field;
        Point[] _body;
        SnakeGame snakeGame;
        Point _move = new Point(1, 0);
        ConsoleKey lastKey = ConsoleKey.RightArrow;
        public Snake(Field field, Food food, SnakeGame snakeGame)
        {
            this.field = field;
            this.food = food;
            this.snakeGame = snakeGame;
        }
        public bool Eat()
        {
            if (_body[0].XPosition == food.XPosition && _body[0].YPosition == food.YPosition)
            {
                return true;
            }
            return false;
        }  // Проверка на поедание змеей еды
        public void Move()
        {
            if (Eat())
            {
                food.Draw();
                EnlargementSnakeBody(1);
                ChangeSpeedGame();
                snakeGame.score++;
            }
            else
            {
                EnlargementSnakeBody();
                if (TouchBorder())
                    snakeGame.snakeLive = false;
                if (SnakeEatSnake())
                    snakeGame.snakeLive = false;
            }
        } // Логика перемещения змейки
        public void CreateSnake()
        {
            if (_body == null)
            {
                _body = new Point[4] {new Point(field._windowWidth / 2, field._windowHeight / 2), new Point((field._windowWidth / 2)-1, field._windowHeight / 2),
                new Point((field._windowWidth / 2)-2, field._windowHeight / 2), new Point((field._windowWidth / 2)-3, (field._windowHeight / 2)) };
            }
        }  // Создание начального тела змеи
        public void EnlargementSnakeBody(int count = 0)
        {
            Point[] newBody = new Point[_body.Length + count];
            for (int i = 1; i < newBody.Length; i++)
            {
                newBody[i] = _body[i - 1];
            }
            newBody[0] = new Point(_body[0].XPosition + _move.XPosition, _body[0].YPosition + _move.YPosition);
            _body = newBody;
        } // Увеличение или изменение положения тела змеи
        public void Draw()
        {
            for (int i = 0; i < _body.Length; i++)
            {
                if (i == 0)
                {
                    Console.SetCursorPosition(_body[i].XPosition, _body[i].YPosition);
                    Console.Write("@");
                }
                else if (i > 0 && i < _body.Length - 1)
                {
                    Console.SetCursorPosition(_body[i].XPosition, _body[i].YPosition);
                    Console.WriteLine("#");
                }
                else
                {
                    Console.SetCursorPosition(_body[^1].XPosition, _body[^1].YPosition);
                    Console.WriteLine(" ");
                }
            }
        } // Отрисовка змеи
        public bool TouchBorder() => _body[0].XPosition == 0 ||
            _body[0].XPosition == (field._windowWidth + 2) ||
            _body[0].YPosition == 0 ||
            _body[0].YPosition == (field._windowHeight + 2); // Проверка не вышла ли змея за границы игрового поля
        public bool SnakeEatSnake()
        {
            for (int i = 1; i < _body.Length - 1; i++)
            {
                if (_body[0].XPosition == _body[i].XPosition && _body[0].YPosition == _body[i].YPosition)
                {
                    return true;
                }
            }
            return false;
        } // Проверка не укусила ли змея сама себя
        public void ChangeSpeedGame()
        {
            if (snakeGame.time >= 50)
            {
                snakeGame.time -= 5;
            }
        } // Изменение скорости змеи
        public void KeyPressHandle()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey keyPressed = Console.ReadKey(true).Key;
                switch (keyPressed)
                {
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        if (lastKey == ConsoleKey.A || lastKey == ConsoleKey.LeftArrow)
                        {
                            break;
                        }
                        lastKey = keyPressed;
                        _move = new Point(1, 0);
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if (lastKey == ConsoleKey.D || lastKey == ConsoleKey.RightArrow)
                        {
                            break;
                        }
                        lastKey = keyPressed;
                        _move = new Point(-1, 0);
                        break;
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        if (lastKey == ConsoleKey.S || lastKey == ConsoleKey.DownArrow)
                        {
                            break;
                        }
                        lastKey = keyPressed;
                        _move = new Point(0, -1);
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        if (lastKey == ConsoleKey.W || lastKey == ConsoleKey.UpArrow)
                        {
                            break;
                        }
                        lastKey = keyPressed;
                        _move = new Point(0, 1);
                        break;
                    case ConsoleKey.Escape:
                        snakeGame.snakeLive = false;
                        break;
                }
            }
        } // Обработчик нажатия клавиш для движения змеи
    }
}
