using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspilv2
{
    public class Game
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
        private int _quantity;
        private List<string> _genres;



        public Genre GenreList { get => _genre; set => _genre = value; }
        public int Players { get => _players; set => _players = value; }
        public State StateCondition { get => _state; set => _state = value; }
        public int NumberGames { get => _numberGames; set => _numberGames = value; }
        public double Price { get => _price; set => _price = value; }
        public string Title { get => _title; set => _title = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public List<string> Genres { get => _genres; set => _genres = value; }


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

        public Game(string v1, int v2, List<string> list)
        {
        }

        public Game(string v1, string v2, int v3, string v4, int v5, double v6)
        {
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

        public static Game FromString(string data)
        {
            string[] parts = data.Split(',');
            return new Game
            {
                Title = parts[0],
                _genre = Enum.Parse<Genre>(parts[1]),
                Players = int.Parse(parts[2]),
                _state = Enum.Parse<State>(parts[3]),
                NumberGames = int.Parse(parts[4]),
                Price = int.Parse(parts[5]),
            };


        }
    }
}
