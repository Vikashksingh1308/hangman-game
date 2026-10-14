namespace Hangman;

/*
 * Film titles repository.
 * Also chooses a random film for each new round.
 * Random.Next() Documentation: 
 * https://learn.microsoft.com/en-us/dotnet/api/system.random.next?view=netframework-4.7.2
 */
public class FilmRepository
{
    private readonly List<string> films;
    private readonly Random random;

    public FilmRepository()
    {
        films = new List<string>
        {
            "Cars",
            "Avatar",
            "Dune",
            "Inception",
            "Good Will Hunting",
            "Forrest Gump"
        };

        random = new Random();
    }

    public string GetRandomFilm()
    {
        int index = random.Next(films.Count);
        return films[index];
    }
}