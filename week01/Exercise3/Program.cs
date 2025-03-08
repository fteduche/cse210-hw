using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;
        Random random = new Random();

        while (playAgain)
        {
            int magicNumber = random.Next(1, 101);
            int guesses = 0;

            Console.WriteLine("Welcome to the Guess My Number game!");

            while (true)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();
                int guess;

                if (int.TryParse(input, out guess))
                {
                    guesses++;

                    if (guess < magicNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else if (guess > magicNumber)
                    {
                        Console.WriteLine("Lower");
                    }
                    else
                    {
                        Console.WriteLine($"You guessed it! It took you {guesses} guesses.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a whole number.");
                }
            }

            Console.Write("Would you like to play again? (yes/no): ");
            string response = Console.ReadLine();

            playAgain = response.ToLower() == "yes";
        }
    }
}