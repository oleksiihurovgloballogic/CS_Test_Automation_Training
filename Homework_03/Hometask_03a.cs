// I. Write a console game. Program should generate random integer value, ask the user to guess it.
// User has unlimited tries to guess the number.
// After the game, when the number is guessed, game should ask user if they want to play again.

namespace Homework_03
{
    internal class Hometask_03a
    {
        public static void GuesserGame()
        {
            Console.WriteLine("------------");
            Console.WriteLine("Hometask 03a:");
            Console.WriteLine("------------\n");

            Random random_generator = new Random();
            const int min_random_number = 1;
            const int max_random_number = 100;

            Console.WriteLine("Number Guesser Game!");
            Console.WriteLine($"Program generates random integer number from {min_random_number} to {max_random_number}.");
            Console.WriteLine($"You have to guess it by unlimited tries with hints from program on go.");

            do
            {
                int secret_number = random_generator.Next(max_random_number) + min_random_number;
                int guess_counter = 1;

                Console.WriteLine();
                do
                {
                    // int guess_number = Convert.ToInt32(Console.ReadLine());
                    int guess_number;
                    do
                    {
                        Console.Write("Please enter your guess number:  ");
                    } while (!int.TryParse(Console.ReadLine(), out guess_number));

                    if (guess_number > secret_number)
                    {
                        Console.WriteLine("Nope. Your number is larger...");
                        guess_counter++;
                    }
                    else if (guess_number < secret_number)
                    {
                        Console.WriteLine("Nope. Your number is smaller...");
                        guess_counter++;
                    }
                    else // if (guess_number == secret_number)
                    {
                        Console.WriteLine($"Yes! You guessed the number in {guess_counter} attempts!");
                        break;
                    }
                } while (true);

                Console.Write("\nDo you want to take one more game?  y/n:  ");
            } while (Console.ReadLine().ToUpper() == "Y");

            Console.WriteLine("\nThanks for playing!");
        }

        public static void Main()
        {
            GuesserGame();
        }
    }
}
