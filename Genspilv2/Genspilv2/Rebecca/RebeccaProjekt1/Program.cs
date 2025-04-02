namespace RebeccaProjekt1
{
    internal class Program
    {
        class InventoryManagement
        {


            static void Main(string[] args)
            {
                List<Game> game = new List<Game> //laver en liste over spil på lageret 
            {
               new Game("Matador", 2, new List<string> { "Strategispil", "Familiespil" }),
                new Game("Ludo", 3, new List<string> { "Familiespil", "Børnespil" }),
                new Game("Scrabble", 1, new List<string> { "Ordspil" }),
                new Game("Bezzerwizzer", 1, new List<string> {"Quizspil"}),
                new Game("Skak", 4, new List<string> {"Strategispil"}),
                new Game("Stratego", 2, new List<string> {"Strategispil"}),
                new Game("Vildkatten", 1, new List<string> {"Familiespil", "Børnespil"}),
                new Game("Trivial pursuit", 5, new List<string> {"Quizspil"}),
                new Game("Børne Alfabet", 1, new List<string> {"Børnespil", "Ordspil"}),
            };


                Console.WriteLine("Vælg sortering af lagerlisten:");
                Console.WriteLine("1: Sortér efter titel");
                Console.WriteLine("2: Sortér efter genre");
                Console.Write("Indtast dit valg (1/2): ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    // Sortér efter titel
                    var sortedList = game.OrderBy(item => item.Title);
                    PrintTitles(sortedList);
                }
                else if (choice == "2")
                {
                    // Find alle unikke genrer
                    var allGenres = game.SelectMany(item => item.Genres).Distinct().OrderBy(g => g);

                    PrintByGenre(game, allGenres);
                }
                else
                {
                    Console.WriteLine("Ugyldigt valg. Prøv igen.");
                }
            }

            static void PrintTitles(IEnumerable<Game> list)
            {
                Console.WriteLine("\nLagerliste (sorteret efter titel):");
                foreach (var item in list)
                {
                    Console.WriteLine($"{item.Title} (Antal: {item.Quantity})");
                }
            }

            static void PrintByGenre(List<Game> itemList, IEnumerable<string> genres)
            {
                Console.WriteLine("\nLagerliste (sorteret efter genre):");
                foreach (var genre in genres)
                {
                    Console.WriteLine($"\nGenre: {genre}");
                    foreach (var item in itemList.Where(v => v.Genres.Contains(genre)).OrderBy(v => v.Title))
                    {
                        Console.WriteLine($"- {item.Title} (Antal: {item.Quantity})");
                    }
                }
            }
        }
    }
}






   
