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
            2) Reservation af spil
            3) Søge på spil
            4) Efterspørgelse af spil
            5) Prissættelse af spil
            6) Lagerliste
            7) Afslut programmet
            """);

            //Debug sikring for at sikre sig, at man er hvor man ønsker
            string? valg = Console.ReadLine();
            Console.WriteLine(valg);

            //cases på menuen
            switch (valg)
            {
                case "1":
                    Overblik();
                    return true;
                case "2":
                    Reservation();
                    return true;
                case "3":
                    Soegning();
                    return true;
                case "4":
                    Efterspoergelse();
                    return true;
                case "5":
                    Prissaettelse();
                    return true;
                case "6":
                    Lagerliste();
                    return true;
                case "7":
                    Afslut();
                    return false;
                default:
                    return true;
            }
        }
        //Case 1 Overblik
        private static void Overblik()
        {
            Console.WriteLine("Her er Overblik");
        }

        //Case 2 Reservation
        private static void Reservation()
        {
            Console.WriteLine("Her er Reservation");
        }

        //Case 3 Søge
        private static void Soegning()
        {
            Console.WriteLine("Her er Søge");
        }

        //Case 4, Efterspørgelse
        private static void Efterspoergelse()
        {
            Console.WriteLine("Her er Efterspørgelse");
        }

        //Case 5, Prissættelse
        private static void Prissaettelse()
        {
            Console.WriteLine("Her er Prissættelse");
        }

        //Case 6, Lagerliste,
        private static void Lagerliste()
        {
            Console.WriteLine("Her er Lagerlisten");
        }

        //Case 7, Afslut
        private static void Afslut()
        {
            Console.WriteLine($"\r\nTryk Enter for at Afslutte");
            Console.ReadLine();
        }
    }
}
