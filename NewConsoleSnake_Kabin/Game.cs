namespace NewConsoleSnake_Kabin
{
    abstract class Game
    {
        public abstract void StartGame();
        public abstract void Setup();
        public abstract void EndGame();
        public abstract bool RetryGame();
    }
}
