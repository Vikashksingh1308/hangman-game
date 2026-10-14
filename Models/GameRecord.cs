namespace Hangman;

/*
 * This class stores the result of a single completed hangman round.
 * It keeps track of the player's name, the film that was guessed
 */
public class GameRecord
{
    public string PlayerName { get; set; }
    public string FilmTitle { get; set; }
    public bool Won { get; set; }

    public GameRecord(string playerName, string filmTitle, bool won)
    {
        PlayerName = playerName;
        FilmTitle = filmTitle;
        Won = won;
    }

    public string Result
    {
        get { return Won ? "Won" : "Lost"; }
    }
}