namespace SnakeAndLadderGameProgram
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Dice dice = new Dice();
            const int WinningPosition = 100;
            int diceCount = 0;

            while (player.GetPosition() < WinningPosition)
            {
                int dieRoll = dice.Roll(); // Roll the die to get a number between 1 to 6
                Console.WriteLine("Die Roll: " + dieRoll);
                diceCount++;

                int option = new Random().Next(0, 3); // Check for an option: No Play, Ladder, or Snake
                switch (option)
                {
                    case 0: // No Play
                        Console.WriteLine("No Play - Stay at the same position");
                        break;
                    case 1: // Ladder
                        Console.WriteLine("Ladder - Move ahead by " + dieRoll + " positions");
                        player.Move(dieRoll);
                        break;
                    case 2: // Snake
                        Console.WriteLine("Snake - Move behind by " + dieRoll + " positions");
                        player.Move(-dieRoll);
                        break;
                }

                if (player.GetPosition() < 0)
                    player.Restart(); // Restart from 0 if position goes below 0
                else if (player.GetPosition() > WinningPosition)
                    player.Move(-dieRoll); // Stay at the previous position if position goes above 100

                Console.WriteLine("Current Position: " + player.GetPosition());
                Console.WriteLine();
            }

            Console.WriteLine("Congratulations! You reached the exact winning position.");
            Console.WriteLine("Number of times the dice was played: " + diceCount);
            Console.ReadLine();
        }
    }

    class Player
    {
        private int position;

        public int GetPosition()
        {
            return position;
        }

        public void SetPosition(int value)
        {
            position = value;
        }

        public void Move(int steps)
        {
            position += steps;
        }

        public void Restart()
        {
            position = 0;
        }
    }

    class Dice
    {
        private Random random;

        public Dice()
        {
            random = new Random();
        }

        public int Roll()
        {
            return random.Next(1, 7); // Returns a random number between 1 and 6
        }
    }
}