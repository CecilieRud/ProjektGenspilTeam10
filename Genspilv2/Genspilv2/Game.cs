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
        private string _genre = "";
        private int _players = 0;
        private string _state = ""; // Stand af spil
        private int _numberGames = 0;
        private double _price = 0.00;


        public string Genre { get => _genre; set => _genre = value; }
        public int Players { get => _players; set => _players = value; }
        public string State { get => _state; set => _state = value; }
        public int NumberGames { get => _numberGames; set => _numberGames = value; }
        public double Price { get => _price; set => _price = value; }
        public string Title { get => _title; set => _title = value; }


        // Constructor
        public Game(string title, string genre, int players, string state, int numberGames, double price)
        {
            Title = title;
            Genre = genre;
            Players = players;
            State = state;
            NumberGames = numberGames;
            Price = price;
        }

        // Default constructor
        public Game()
        {
            Title = "";
            Genre = "";
            Players = 0;
            State = "";
            NumberGames = 0;
            Price = 0.00;
        }

        public void PrintGameDetails()
        {
            Console.WriteLine($"Spilnavn: {Title}, Genre: {Genre}, Antal spillere: {Players}, Stand: {State}, Antal spil: {NumberGames}, Pris: {Price}");
        }

        //public void PrintAllGames()
        //{
        //    foreach (var spil in SpilListe)
        //    {
        //        spil.PrintGameDetails();
        //    }
        //}

        public override string ToString()
        {
            return $"Spilnavn: {Title}, Genre: {Genre}, Antal spillere: {Players}, Stand: {State}, Antal spil: {NumberGames}, Pris: {Price}";
        }


    }
}