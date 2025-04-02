using Genspilv2.Mia.GenSpilMia;
using MarianProjekt;

namespace GenSpilMia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game1 = new Game("Catan", Game.Genre.Strategi, 4, Game.State.God, 10, 100.00);
            Game game2 = new Game("BezzerWizzer", Game.Genre.Quiz, 4, Game.State.Brugt, 12, 80.00);
            Game game3 = new Game("Domino", Game    .Genre.Familie, 2, Game.State.Ny, 8, 50.00);
            Game game4 = new Game("Pandemic", Game.Genre.Strategi, 5, Game.State.Meget_Brugt, 9, 100.00);

            //new Spil { Title = "Catan", Genre = "Strategi", AntalSpillere = 4, Stand = "God", AntalSpil = 10, Pris = 100.00 };
            //new Spil { SpilNavn = "Bezzerwizzer", Genre = "Quiz", AntalSpillere = 4, Stand = "OK", AntalSpil = 8, Pris = 80.00 };

            Storage lager = new Storage();

            //{
            //    new Spil("Catan", "Strategi", 4, "God", 10, 100.00);
            //    new Spil("BezzerWizzer", "Quiz", 4, "OK", 12, 80.00);
            //};
            lager.AddGame(game1);
            lager.AddGame(game2);
            lager.AddGame(game3);


            lager.PrintGames();





            Console.ReadKey();
        }
    }
}
