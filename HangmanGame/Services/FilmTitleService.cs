using System;
using System.Collections.Generic;
public class FilmTitleService
{
    private List<FilmTitle> films;
    private Random random; //https://learn.microsoft.com/en-us/dotnet/api/system.random

    //Constructor 
    public FilmTitleService()
    {
        this.films = new List<FilmTitle>();
        this.random = new Random();
        InitializeFilms();
    }

    //File titles
    private void InitializeFilms()
    {
        films.Add(new FilmTitle("Forest Gump"));
        films.Add(new FilmTitle("The Mask"));
        films.Add(new FilmTitle("Scary Movie"));
        films.Add(new FilmTitle("Spider Man"));
        films.Add(new FilmTitle("Good Will Hunting"));
        films.Add(new FilmTitle("God Speed"));
        films.Add(new FilmTitle("Harry Potter"));
        films.Add(new FilmTitle("Avatar"));
        films.Add(new FilmTitle("Coco"));
        films.Add(new FilmTitle("Casino Royale"));
        films.Add(new FilmTitle("The Dark Knight"));
        films.Add(new FilmTitle("The Lord of the Rings"));
        films.Add(new FilmTitle("Star Wars"));
        films.Add(new FilmTitle("The Breakfast Club"));
        films.Add(new FilmTitle("Fight Club"));        
    }

    //Get random film title
    public FilmTitle GetRandomFilmTitle()
    {
        int randomIndex = random.Next(films.Count);
        return films[randomIndex];
    }

    //Get all film titles
    public List<FilmTitle> GetAllFilmTitles()
    {
        return films;
    }

    //get total number of film
    public int GetTotalFilms()
    {
        return films.Count;
    }

}