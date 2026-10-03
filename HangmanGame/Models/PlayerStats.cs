public class PlayerStats
{
    private string playerName;
    private string filmTitle;
    private string gameResult;

    //Constructor
    public PlayerStats(string playerName, string filmTitle, string gameResult)
    {
        this.playerName = playerName;
        this.filmTitle = filmTitle;
        this.gameResult = gameResult;
    }

    //Getters
    public string GetPlayerName() {return playerName;}
    public string GetFilmTitle() {return filmTitle;}
    public string GetGameResult() {return gameResult;}

    //Setters
    public void SetPlayerName(string playerName) {this.playerName = playerName;}
    public void SetFilmTitle(string filmTitle) {this.filmTitle = filmTitle;}
    public void SetGameResult(string gameResult) {this.gameResult = gameResult;}

    public override string ToString()
    {
        return $"Player: {playerName}, Film: {filmTitle}, Result: {gameResult}";
    }
}