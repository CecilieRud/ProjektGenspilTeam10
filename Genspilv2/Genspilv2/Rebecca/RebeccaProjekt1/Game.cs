using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebeccaProjekt1
{
    internal class Game
    {
        private string _title;
        private int _quantity;
        private List<string> _genres;

        public Game(string title, int quantity, List<string> genres)
        {
            Title = title;
            Quantity = quantity;
            Genres = genres;

        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public int Quantity
        {
            get => _quantity;
            set => _quantity = value;
        }

        public List<string> Genres
        {
            get => _genres;
            set => _genres = value;
        }


    }
}
