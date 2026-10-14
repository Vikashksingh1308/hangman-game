namespace Hangman;

/*
 * This controller manages the overall game flow.
 * It starts the application, runs each round, handles the menu,
 * and stores the final result in the history.
 */
public class GameController
{
    private readonly FilmRepository filmRepository;
    private readonly GameHistory history;
    private string playerName;

    public GameController()
    {
        filmRepository = new FilmRepository();
        history = new GameHistory();
        playerName = "";
    }

    public void Run()
    {
        ConsoleUI.ShowWelcome();
        playerName = InputHelper.ReadName();

        bool running = true;

        while (running)
        {
            PlayRound();
            bool inMenu = true;

            while (inMenu)
            {
                ConsoleUI.ShowMenu();
                int choice = InputHelper.ReadMenuChoice(1, 3);

                if (choice == 1)
                {
                    inMenu = false;
                }
                else if (choice == 2)
                {
                    ConsoleUI.ShowStatistics(history);
                }
                else
                {
                    running = false;
                    inMenu = false;
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine($"Thanks for playing, {playerName}! Bye.");
    }

    private void PlayRound()
    {
        string film = filmRepository.GetRandomFilm();
        HangmanGame game = new HangmanGame(film);
        string message = "";

        while (!game.IsGameOver())
        {
            ConsoleUI.ShowGameScreen(game, playerName, message);
            char letter = InputHelper.ReadLetter();

            if (game.HasBeenGuessed(letter))
            {
                message = $"You already guessed '{letter}'. Try different letter";
            }
            else if (game.GuessLetter(letter))
            {
                message = $"Correct! '{letter}' is in the title.";
            }
            else
            {
                message = $"Wrong! '{letter}' is not in the title.";
            }
        }

        ConsoleUI.ShowGameScreen(game, playerName, "");
        ConsoleUI.ShowGameResult(game, playerName);

        history.AddRecord(new GameRecord(playerName, film, game.IsWon()));
    }
}