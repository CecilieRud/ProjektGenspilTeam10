namespace Genspilv2.Mia.GenSpilMia
{
    internal class Game
    {
        private string _title = "";
        private Genre _genre = Genre.Quiz;
        private int _players = 0;
        private State _state = State.God; // Stand af spil
        private int _numberGames = 0;
        private double _price = 0.00;
        public enum Genre
        {
            Strategi,
            Quiz,
            Familie,
            Ordspil,
            Børnespil
        }

        public enum State
        {
            Ny,
            God,
            Brugt,
            Meget_Brugt
        }


        public Genre GenreList { get => _genre; set => _genre = value; }
        public int Players { get => _players; set => _players = value; }
        public State StateCondition { get => _state; set => _state = value; }
        public int NumberGames { get => _numberGames; set => _numberGames = value; }
        public double Price { get => _price; set => _price = value; }
        public string Title { get => _title; set => _title = value; }


        // Constructor
        public Game(string title, Genre genre, int players, State state, int numberGames, double price)
        {
            Title = title;
            GenreList = genre;
            Players = players;
            StateCondition = state;
            NumberGames = numberGames;
            Price = price;
        }

        // Default constructor
        public Game()
        {
            Title = "";
            GenreList = Genre.Quiz;
            Players = 0;
            StateCondition = State.God;
            NumberGames = 0;
            Price = 0.00;
        }

        public void PrintGameDetails()
        {
            Console.WriteLine($"Spilnavn: {Title}, Genre: {_genre}, Antal spillere: {Players}, Stand: {_state}, Antal spil: {NumberGames}, Pris: {Price}");
        }

        //public void PrintAllGames()
        //{
        //    foreach (var spil in SpilListe)
        //    {
        //        spil.PrintGameDetails();
        //    }
        //}

        // For at kunne udprinte objektet er der tilføjet en tostring metode
        public override string ToString()
        {
            return $"Spilnavn: {Title}, Genre: {_genre}, Antal spillere: {Players}, Stand: {_state}, Antal spil: {NumberGames}, Pris: {Price}";
        }
    }
}
