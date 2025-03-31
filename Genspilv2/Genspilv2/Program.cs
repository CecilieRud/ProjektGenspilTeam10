namespace Genspilv2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Indsættelse af variabler der kan kaldes på i alle menuerne


            //Menu i Main
            
                bool showMenu = true;
                while (showMenu)
                {
                    showMenu = MainMenu();
                }
            
        }

        private static bool MainMenu()
        {
            Console.WriteLine("""
            Vælg punkt: 
            1) Overblik over spil
            2) Søge på spil
            3) Lagerliste
            4) Afslut programmet
            """);

            //Debug sikring for at sikre sig, at man er hvor man ønsker
            string? valg = Console.ReadLine();
            Console.WriteLine(valg);

            //cases på menuen
            switch (valg)
            {
                case "1":
                    Lagerstyring();
                    return true;
                case "2":
                    Soegning();
                    return true;
                case "3":
                    Lagerliste();
                    return true;
                case "4":
                    Afslut();
                    return false;
                default:
                    return true;
            }
        }
        //Case 1 Overblik
        private static void Lagerstyring()
        {
            {
                Game game1 = new Game("Catan", "Strategi", 4, "God", 10, 100.00);
                Game game2 = new Game("BezzerWizzer", "Quiz", 4, "OK", 12, 80.00);
                Game game3 = new Game("Domino", "Klassisk", 2, "Som ny", 8, 50.00);

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

        //Case 2 Søge
        private static void Soegning()
        {
            Console.WriteLine("Her er Søge");
        }

        //Case 3, Lagerliste,
        private static void Lagerliste()
        {
           
        }

        //Case 7, Afslut
        private static void Afslut()
        {
            Console.WriteLine($"\r\nTryk Enter for at Afslutte");
            Console.ReadLine();
        }
    }
}
