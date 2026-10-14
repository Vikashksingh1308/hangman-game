namespace Hangman;

/*
 * This class handles all messages shown in the terminal.
 * It displays the welcome screen, the game board, the result screen,
 * the menu options and the game stats.
 */
public static class ConsoleUI
{
    public static void ShowWelcome()
    {
        Console.Clear();
        Console.WriteLine("==============================");
        Console.WriteLine("   HANGMAN : GUESS THE FILM   ");
        Console.WriteLine("==============================");
        Console.WriteLine();
    }

    public static void ShowGameScreen(HangmanGame game, string playerName, string message)
    {
        Console.Clear();
        Console.WriteLine("=== HANGMAN : GUESS THE FILM ===");
        Console.WriteLine($"Player: {playerName}");
        Console.WriteLine();

        DrawHangman(game.WrongGuesses);

        Console.WriteLine();
        Console.WriteLine($"Film: {game.GetMaskedWord()}");
        Console.WriteLine($"Guessed letters: {GetGuessedText(game)}");
        Console.WriteLine($"Wrong guesses: {game.WrongGuesses}/{game.MaxWrongGuesses} " + $"({game.MaxWrongGuesses - game.WrongGuesses} left)");
        Console.WriteLine();

        if (message != "")
        {
            Console.WriteLine(message);
            Console.WriteLine();
        }
    }

    public static void DrawHangman(int wrong)
    {
        string baseLine = wrong >= 1 ? "=========" : "";
        char pole = wrong >= 1 ? '|' : ' ';
        char topLeft = wrong >= 1 ? '+' : ' ';
        string beam = wrong >= 1 ? "---" : "   ";
        char topRight = wrong >= 1 ? '+' : ' ';

        char rope = wrong >= 2 ? '|' : ' ';

        char head = wrong >= 3 ? 'O' : ' ';
        char body = wrong >= 4 ? '|' : ' ';
        char leftArm = wrong >= 5 ? '/' : ' ';
        char rightArm = wrong >= 5 ? '\\' : ' ';
        char leftLeg = wrong >= 6 ? '/' : ' ';
        char rightLeg = wrong >= 6 ? '\\' : ' ';

        Console.WriteLine($"  {topLeft}{beam}{topRight}");
        Console.WriteLine($"  {pole}   {rope}");
        Console.WriteLine($"  {pole}   {head}");
        Console.WriteLine($"  {pole}  {leftArm}{body}{rightArm}");
        Console.WriteLine($"  {pole}  {leftLeg} {rightLeg}");
        Console.WriteLine($"  {pole}");
        Console.WriteLine(baseLine);
    }

    private static string GetGuessedText(HangmanGame game)
    {
        if (game.GuessedLetters.Count == 0)
        {
            return "none yet";
        }

        return string.Join(", ", game.GuessedLetters);
    }

    public static void ShowGameResult(HangmanGame game, string playerName)
    {
        Console.WriteLine();

        if (game.IsWon())
        {
            Console.WriteLine($"Congratulations {playerName}, you won!");
        }
        else
        {
            Console.WriteLine($"Sorry {playerName}, you lost!");
        }

        Console.WriteLine($"The film was: {game.FilmTitle}");
        Console.WriteLine();
    }

    public static void ShowMenu()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Play again");
        Console.WriteLine("2. View statistics");
        Console.WriteLine("3. Quit");
        Console.WriteLine();
    }

    public static void ShowStatistics(GameHistory history)
    {
        Console.WriteLine();
        Console.WriteLine("=== STATISTICS ===");

        if (history.TotalPlayed == 0)
        {
            Console.WriteLine("No games played yet");
        }
        else
        {
            Console.WriteLine($"{"#",-4}{"Player",-22}{"Film",-20}{"Result",-6}");
            Console.WriteLine(new string('-', 52));

            int number = 1;

            foreach (GameRecord record in history.GetRecords())
            {
                Console.WriteLine($"{number,-4}{record.PlayerName,-22}{record.FilmTitle,-20}{record.Result,-6}");
                number++;
            }

            Console.WriteLine(new string('-', 52));
        }

        Console.WriteLine($"Total games played: {history.TotalPlayed}");
        Console.WriteLine($"Total games won: {history.TotalWon}");
        Console.WriteLine($"Total games lost: {history.TotalLost}");
        Console.WriteLine();
    }
}