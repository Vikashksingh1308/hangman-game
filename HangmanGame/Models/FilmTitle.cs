namespace HangmanGame.Models
{
    public class FilmTitle
    {
        private string title;

        //Constructor
        public FilmTitle(string title)
        {
            this.title = title.ToUpper();
        }

        //Getter
        public string GetTitle()
        {
            return title;
        }

        //Setter
        public void SetTitle(string title)
        {
            this.title = title.ToUpper();
        }

        public override string ToString()
        {
            return title;
        }

    }   
}