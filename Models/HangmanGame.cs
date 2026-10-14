namespace Hangman;

/*
 * This class represents one active game of hangman.
 * It stores the hidden film title, keeps track of guessed letters,
 * updates the wrong guess count and checks whether the player has won or lost.
 */
public class HangmanGame
{
    public string FilmTitle { get; private set; }
    public int WrongGuesses { get; private set; }
    public int MaxWrongGuesses { get; }
    public List<char> GuessedLetters { get; private set; }

    public HangmanGame(string filmTitle)
    {
        FilmTitle = filmTitle;
        WrongGuesses = 0;
        MaxWrongGuesses = 6;
        GuessedLetters = new List<char>();
    }

    // Checks whether the player has already guessed this letter before.
    public bool HasBeenGuessed(char letter)
    {
        return GuessedLetters.Contains(char.ToUpper(letter));
    }

    /* 
    * Save the guessed letter and checks if the film title contains it.
    * If matches, returns true. If there is no match then increment WrongGuessess value.
    */
    public bool GuessLetter(char letter)
    {
        letter = char.ToUpper(letter);

        if (!GuessedLetters.Contains(letter))
        {
            GuessedLetters.Add(letter);
        }

        if (FilmTitle.ToUpper().Contains(letter))
        {
            return true;
        }

        WrongGuesses++;
        return false;
    }

    /*
    * Purpose: This creates the hidden word the player sees on screen.
    * Logic: This loop goes through every character in the film title.
    * If the character is a letter:
    * - show it if it has already been guessed
    * - otherwise show an underscore
    * If any character is a space, keep it visible.
    */
    public string GetMaskedWord()
    {
        string result = "";

        foreach (char c in FilmTitle)
        {
            if (char.IsLetter(c))
            {
                if (GuessedLetters.Contains(char.ToUpper(c)))
                {
                    result += c + " ";
                }
                else
                {
                    result += "_ ";
                }
            }
            else
            {
                result += c + " ";
            }
        }

        return result.Trim();
    }

    // Checks if all letters in the film title have been guessed correctly
    public bool IsWon()
    {
        foreach (char c in FilmTitle)
        {
            if (char.IsLetter(c) && !GuessedLetters.Contains(char.ToUpper(c)))
            {
                return false;
            }
        }

        return true;
    }

    // Checks if the player has used up the maximum number of allowed wrong guesses
    public bool IsLost()
    {
        return WrongGuesses >= MaxWrongGuesses;
    }

    // Returns true when the round is finished
    public bool IsGameOver()
    {
        return IsWon() || IsLost();
    }
}