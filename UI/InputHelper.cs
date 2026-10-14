namespace Hangman;

/*
 * Helper class to validate and read user input.
 * Checks player names, letter guesses and menu selections before returning values.
 */
public static class InputHelper
{
    public static string ReadName()
    {
        while (true)
        {
            Console.Write("Enter your name: ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Name cannot be empty. Please try again.");
            }
            else if (input.Trim().Length > 20)
            {
                Console.WriteLine("Name must be 20 characters or fewer. Please try again.");
            }
            else
            {
                return input.Trim();
            }
        }
    }

    public static char ReadLetter()
    {
        while (true)
        {
            Console.Write("Guess a letter: ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("You didnt enter anything. Please type a letter.");
            }
            else
            {
                input = input.Trim();

                if (input.Length != 1)
                {
                    Console.WriteLine("Please enter ONE letter only.");
                }
                else
                {
                    char letter = char.ToUpper(input[0]);

                    if (letter < 'A' || letter > 'Z')
                    {
                        Console.WriteLine("Invalid input, Lettters A-Z only.");
                    }
                    else
                    {
                        return letter;
                    }
                }
            }
        }
    }

    public static int ReadMenuChoice(int min, int max)
    {
        while (true)
        {
            Console.Write($"Enter your choice ({min}-{max}): ");
            string? input = Console.ReadLine();

            int choice;

            if (int.TryParse(input, out choice) && choice >= min && choice <= max)
            {
                return choice;
            }

            Console.WriteLine($"Invalid choice. Please enter a number from {min} to {max}.");
        }
    }
}