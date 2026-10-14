namespace Hangman;

/*
 * Class to keep a record of all finished games.
 * It stores the match results and calculates total wins, losses and games played.
 */
public class GameHistory
{
    private readonly List<GameRecord> records;

    public GameHistory()
    {
        records = new List<GameRecord>();
    }

    public void AddRecord(GameRecord record)
    {
        records.Add(record);
    }

    public List<GameRecord> GetRecords()
    {
        return records;
    }

    public int TotalPlayed
    {
        get { return records.Count; }
    }

    public int TotalWon
    {
        get
        {
            int count = 0;
            foreach (GameRecord record in records)
            {
                if (record.Won)
                {
                    count++;
                }
            }
            return count;
        }
    }

    public int TotalLost
    {
        get { return TotalPlayed - TotalWon; }
    }
}