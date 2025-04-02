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
            3) ReservationForespørgsel
            4) Lagerliste
            5) Afslut programmet
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
                            Lagerliste();
                            return true;
                        case "5":
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

    class Reservation
    {
        public string CustomerName { get; }
        public string CustomerEmail { get; }
        public string GameTitle { get; }

        public Reservation(string customerName, string customerEmail, string gameTitle)
        {
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            GameTitle = gameTitle;
        }
    }

    class Request
    {
        public string CustomerName { get; }
        public string CustomerEmail { get; }
        public string GameTitle { get; }

        public Request(string customerName, string customerEmail, string gameTitle)
        {
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            GameTitle = gameTitle;
        }
    }


        //Case 4, Lagerliste,
        private static void Lagerliste()
        {
           
        }

        //Case 5, Afslut
        private static void Afslut()
        {
            Console.WriteLine($"\r\nTryk Enter for at Afslutte");
            Console.ReadLine();
        }
    }
}
