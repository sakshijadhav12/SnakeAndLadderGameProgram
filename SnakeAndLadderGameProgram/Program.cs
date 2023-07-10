namespace SnakeAndLadderGameProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player();
            Player player2 = new Player();
            Dice dice = new Dice();
            const int WinningPosition = 100;
            int currentPlayer = 1;

            while (player1.GetPosition() < WinningPosition && player2.GetPosition() < WinningPosition)
            {
                int dieRoll = dice.Roll(); // Roll the die to get a number between 1 to 6
                Console.WriteLine("Player " + currentPlayer + " - Die Roll: " + dieRoll);

                int option = new Random().Next(0, 3); // Check for an option: No Play, Ladder, or Snake
                switch (option)
                {
                    case 0: // No Play
                        Console.WriteLine("No Play - Stay at the same position");
                        break;
                    case 1: // Ladder
                        Console.WriteLine("Ladder - Move ahead by " + dieRoll + " positions");
                        if (currentPlayer == 1)
                        {
                            int newPosition = player1.GetPosition() + dieRoll;
                            if (newPosition <= WinningPosition)
                            {
                                player1.SetPosition(newPosition);
                                Console.WriteLine("Player 1 moves to position: " + player1.GetPosition());
                                currentPlayer = 1; // Player 1 plays again
                            }
                        }
                        else
                        {
                            int newPosition = player2.GetPosition() + dieRoll;
                            if (newPosition <= WinningPosition)
                            {
                                player2.SetPosition(newPosition);
                                Console.WriteLine("Player 2 moves to position: " + player2.GetPosition());
                                currentPlayer = 2; // Player 2 plays again
                            }
                        }
                        break;
                    case 2: // Snake
                        Console.WriteLine("Snake - Move behind by " + dieRoll + " positions");
                        if (currentPlayer == 1)
                        {
                            int newPosition = player1.GetPosition() - dieRoll;
                            if (newPosition >= 0)
                            {
                                player1.SetPosition(newPosition);
                                Console.WriteLine("Player 1 moves to position: " + player1.GetPosition());
                                currentPlayer = 2; // Switch to Player 2
                            }
                        }
                        else
                        {
                            int newPosition = player2.GetPosition() - dieRoll;
                            if (newPosition >= 0)
                            {
                                player2.SetPosition(newPosition);
                                Console.WriteLine("Player 2 moves to position: " + player2.GetPosition());
                                currentPlayer = 1; // Switch to Player 1
                            }
                        }
                        break;
                }

                Console.WriteLine();
            }

            Console.WriteLine("Game over!");

            if (player1.GetPosition() == WinningPosition && player2.GetPosition() == WinningPosition)
                Console.WriteLine("It's a tie! Both Player 1 and Player 2 reached the winning position.");
            else if (player1.GetPosition() == WinningPosition)
                Console.WriteLine("Player 1 won the game!");
            else
                Console.WriteLine("Player 2 won the game!");

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