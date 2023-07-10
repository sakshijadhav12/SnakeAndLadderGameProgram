namespace SnakeAndLadderGameProgram
{

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }

    class Game
    {
        int position;

        public void Start()
        {
            position = 0;

            Console.WriteLine("Hello!Welcome to Snake and Ladder Game");
            Console.WriteLine("Single player at start, position:" + position);

            Console.WriteLine("Press  Enterkey to roll the dice...");
            Console.ReadKey();

            int diceRoll = Dice.Roll();
            Console.WriteLine("Dice rolled: " + diceRoll);

            position += diceRoll;

            Console.WriteLine("Player moves to position: " + position);
        }
        class Dice
        {
            public static int Roll()
            {
                Random random = new Random();
                return random.Next(1, 7); // Returns a random number between 1 and 6
            }
        }
    }

}