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
        private State currentState;
        private double price;

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
            MegetBrugt
        }
        private int _quantity;
        private List<string> _genres;
        private int v;

        public Genre GenreList { get => _genre; set => _genre = value; }
        public int Players { get => _players; set => _players = value; }
        public State StateCondition { get => _state; set => _state = value; }
        public int NumberGames { get => _numberGames; set => _numberGames = value; } 
        public string Title { get => _title; set => _title = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public List<string> Genres { get => _genres; set => _genres = value; }
        public State CurrentState { get => currentState; set => currentState = value; }
        public double Price { get => price; set => price = value; }


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
        public Game(State ny)
        {
            Title = "";
            GenreList = Genre.Quiz;
            Players = 0;
            StateCondition = State.God;
            NumberGames = 0;
            Price = 0.00;

        }

        public Game()
        {

        }

        public Game(string v1, int v2, List<string> list)
        {
        }

        public Game(string v1, string v2, int v3, string v4, int v5, double v6)
        {
        }

        public Game(State ny, int v) : this(ny)
        {
            this.v = v;
        }

        public double GetPrice(Game item)
        {
            if (item._state == State.Ny)
                return item.Price * 0.9;
            if (item._state == State.God)
                return item.Price * 0.8;
            if (item._state == State.Brugt)
                return item.Price * 0.6;
            if (item._state == State.MegetBrugt)
                return item.Price * 0.4;
            return 0.0;
            // return CurrentState switch
            //{
            //    State.Ny => Price * 0.9,
            //    State.God => Price * 0.8,
            //    State.Brugt => Price * 0.6,
            //    State.MegetBrugt => Price * 0.4,
            //    _ => throw new Exception(),
            //};
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
                Price = double.Parse(parts[5]),
            };


        }
    }
}
