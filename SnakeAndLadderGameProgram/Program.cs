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



            int option = Option.Check();

            switch (option)
            {
                case 0:
                    Console.WriteLine("No Play! Player stays in the same position: " + position);
                    break;
                case 1:
                    position += diceRoll;
                    Console.WriteLine("Player landed on a ladder! Moves ahead to position: " + position);
                    break;
                case 2:
                    position -= diceRoll;
                    Console.WriteLine("Player landed on a snake! Moves behind to position: " + position);
                    break;
                
            }

        }
        class Dice
        {
            public static int Roll()
            {
                Random random = new Random();
                return random.Next(1, 7); // Returns a random number between 1 and 6
            }
        }
        class Option
        {
            public static int Check()
            {
                Random random = new Random();
                return random.Next(0, 3); // Returns a random number between 0 and 2
            }
        }

    }
}
