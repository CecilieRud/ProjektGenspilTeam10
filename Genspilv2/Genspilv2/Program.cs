﻿namespace Genspilv2
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
            3) ReservationForespørgsel
            4) Stand og Pris
            5) Lagerliste
            6) Afslut programmet
            """);

            string valg = Console.ReadLine();
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
                    ReservationForespoergelsel();
                    return true;
                case "4":
                    StandPris();
                    return true;
                case "5":
                    Lagerliste();
                    return true;
                case "6":
                    Afslut();
                    return false;
                default:
                    return true;

            }
        }

        //Case 1 Overblik
        private static void Lagerstyring()
        {
            Game game1 = new Game("Catan", Game.Genre.Strategi, 4, Game.State.God, 10, 100.00);
            Game game2 = new Game("BezzerWizzer", Game.Genre.Quiz, 4, Game.State.Brugt, 12, 80.00);
            Game game3 = new Game("Domino", Game.Genre.Familie, 2, Game.State.Ny, 8, 50.00);
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


        //Case 2 Søge
        private static void Soegning()
        {
            List<Spil> spilListe = new List<Spil>
        {
            new Spil { Titel = "Sequence", Genre = Genre.Strategi, Stand = Stand.God, Spillere = 2, Pris = 200, Lager = LagerStatus.PaaLager },
            new Spil { Titel = "Ticket to Ride", Genre = Genre.Familie, Stand = Stand.Ny, Spillere = 4, Pris = 300, Lager = LagerStatus.PaaLager },
            new Spil { Titel = "7 Wonders", Genre = Genre.Strategi, Stand = Stand.Brugt, Spillere = 4, Pris = 200, Lager = LagerStatus.Reserveret },
            new Spil { Titel = "Alverdens", Genre = Genre.Quiz, Stand = Stand.God, Spillere = 4, Pris = 180, Lager = LagerStatus.PaaLager },
            new Spil { Titel = "A la Carte: Dessert", Genre = Genre.PartySpil, Stand = Stand.MegetBrugt, Spillere = 2, Pris = 100, Lager = LagerStatus.Forespurgt },
            new Spil { Titel = "Bad People", Genre = Genre.PartySpil, Stand = Stand.God, Spillere = 6, Pris = 250, Lager = LagerStatus.PaaLager }
        };

            Medarbejder medarbejder = new Medarbejder { Navn = "Jamal", Mail = "jamal@genspil.dk" };

            Console.WriteLine("Indtast søgekriterier (tryk Enter for at springe over et kriterium)");
            Console.Write("Titel: ");
            string titel = Console.ReadLine();

            Console.Write("Genre (Strategi, Familie, Quiz, PartySpil): ");
            Genre? genre = Enum.TryParse(Console.ReadLine(), true, out Genre g) ? g : (Genre?)null;

            Console.Write("Stand (Ny, God, Brugt, MegetBrugt): ");
            Stand? stand = Enum.TryParse(Console.ReadLine(), true, out Stand s) ? s : (Stand?)null;

            Console.Write("Antal spillere: ");
            int? spillere = int.TryParse(Console.ReadLine(), out int sp) ? sp : (int?)null;

            Console.Write("Minimumspris: ");
            double? prisMin = double.TryParse(Console.ReadLine(), out double pMin) ? pMin : (double?)null;

            Console.Write("Maksimumspris: ");
            double? prisMax = double.TryParse(Console.ReadLine(), out double pMax) ? pMax : (double?)null;

            Console.Write("Lagerstatus (PaaLager, Reserveret, Forespurgt, IkkePaaLager - tryk Enter for alle): ");
            LagerStatus? lager = Enum.TryParse(Console.ReadLine(), true, out LagerStatus l) ? l : (LagerStatus?)null;

            var resultater = medarbejder.SoegSpil(spilListe, titel, genre, stand, spillere, prisMin, prisMax, lager);

            Console.WriteLine("\nFundne spil:");
            foreach (var spil in resultater)
            {
                Console.WriteLine(spil);
            }
        }


        //Case 3, Reservation,
        private static void ReservationForespoergelsel()
        {
            List<Reservation> reservations = new List<Reservation>();
            List<Request> requests = new List<Request>();

            static void ReservationsMenu(List<Reservation> reservations, List<Request> requests)
            {
                while (true)
                {
                    Console.WriteLine("A. Foretag reservation");
                    Console.WriteLine("B. Vis reservationer");
                    Console.WriteLine("C. Foretag forespørgsel");
                    Console.WriteLine("D. Vis forespørgsler");
                    Console.WriteLine("E. Afslut");
                    Console.Write("Vælg en mulighed: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "A":
                            MakeReservation(reservations);
                            break;
                        case "B":
                            ShowReservations(reservations);
                            break;
                        case "C":
                            MakeRequest(requests);
                            break;
                        case "D":
                            ShowRequests(requests);
                            break;
                        case "E":
                            return;
                        default:
                            Console.WriteLine("Ugyldigt valg. Prøv igen.");
                            break;
                    }
                }
            }

            static void MakeReservation(List<Reservation> reservations)
            {
                Console.Write("Indtast kundens navn: ");
                string customerName = Console.ReadLine();

                Console.Write("Indtast kundens email: ");
                string customerEmail = Console.ReadLine();

                Console.Write("Indtast spillets titel: ");
                string gameTitle = Console.ReadLine();

                reservations.Add(new Reservation(customerName, customerEmail, gameTitle));
                Console.WriteLine("Reservation gennemført!");
            }

            static void ShowReservations(List<Reservation> reservations)
            {
                Console.WriteLine("Nuværende reservationer:");
                if (reservations.Count == 0)
                {
                    Console.WriteLine("Ingen reservationer");
                    return;
                }

                foreach (var reservation in reservations)
                {
                    Console.WriteLine($"Kunde: {reservation.CustomerName}, Email: {reservation.CustomerEmail}, Spil: {reservation.GameTitle}");
                }
                Console.WriteLine();
            }

            static void MakeRequest(List<Request> requests)
            {
                Console.Write("Indtast kundens navn: ");
                string customerName = Console.ReadLine();

                Console.Write("Indtast kundens email: ");
                string customerEmail = Console.ReadLine();

                Console.Write("Indtast  spillets titel: ");
                string gameTitle = Console.ReadLine();

                requests.Add(new Request(customerName, customerEmail, gameTitle));
                Console.WriteLine("Forespørgsel er registreret\n");
            }

            static void ShowRequests(List<Request> requests)
            {
                Console.WriteLine("\nEksisterende forespørgsler:");
                if (requests.Count == 0)
                {
                    Console.WriteLine("Ingen forespørgsler");
                    return;
                }

                foreach (var request in requests)
                {
                    Console.WriteLine($"Kunde: {request.CustomerName}, Email: {request.CustomerEmail}, Ønsket spil: {request.GameTitle}");
                }
                Console.WriteLine();
            }
        }
        

        
        
        

        //Case 4 Overblik

        private static void StandPris()
        {


            Console.WriteLine("Hvad er original prisen for spillet? ");
            double TotalPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("Hvad er spillets stand? Ny, God, Brugt, MegetBrugt");
            var State = Console.ReadLine()?.ToLower() ?? "";


            Console.WriteLine($"Spillets original pris er: {TotalPrice}.\nSpillets stand er {State}.\nSpillets pris efter stand er {Price.CurrentState} kr.");
            }
            
        

        //Case 5, Lagerliste,
        private static void Lagerliste()
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

        //Case 6, Afslut
        private static void Afslut()
        {
            Console.WriteLine($"\r\nTryk Enter for at Afslutte");
            Console.ReadLine();
        }
    }
}
