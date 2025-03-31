using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspilv2
{
    internal class Storage
    {
        List<Game> gameList = new List<Game>();

        // Property der returnerer hvor mange spil der er
        public int TotalNumberOfGames { get => gameList.Count; }

        public void DeleteGame(string title)
        {
            // ved Find metoden loopes der igennem gamelisten for at finde det spil med matchende titel man gerne vil slette
            Game? gameToRemove = gameList.Find(game => game.Title == title);
            if (gameToRemove != null)
            {
                gameList.Remove(gameToRemove);
            }
        }

        public void AddGame(Game game)
        {
            gameList.Add(game);
        }

        // Metode der returnerer hvor mange spil der er, men TotalNumberOfGames skal bruges i stedet 
        //public int NumberOfGames() 
        //{
        //    return gameList.Count;
        //}

        public void PrintGames()
        {
            Console.WriteLine($"Der er disse spil i butikken: ");
            foreach (var game in gameList)
            {
                // Kan kun udprinte objektet, da der er lavet en Tostring metode i Spil klassen
                Console.WriteLine(game);
            }
        }
    }
}
