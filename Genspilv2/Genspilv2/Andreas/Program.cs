using System;
using System.Collections.Generic;

class Program
{
    static List<Reservation> reservations = new List<Reservation>();
    static List<Request> requests = new List<Request>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Foretag reservation");
            Console.WriteLine("2. Vis reservationer");
            Console.WriteLine("3. Foretag forespørgsel");
            Console.WriteLine("4. Vis forespørgsler");
            Console.WriteLine("5. Afslut");
            Console.Write("Vælg en mulighed: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    MakeReservation();
                    break;
                case "2":
                    ShowReservations();
                    break;
                case "3":
                    MakeRequest();
                    break;
                case "4":
                    ShowRequests();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Ugyldigt valg. Prøv igen.");
                    break;
            }
        }
    }

    static void MakeReservation()
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

    static void ShowReservations()
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

    static void MakeRequest()
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

    static void ShowRequests()
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