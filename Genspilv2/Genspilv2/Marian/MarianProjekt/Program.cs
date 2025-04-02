namespace MarianProjekt
{


public enum Genre { Strategi, Familie, Quiz, PartySpil }
        public enum Stand { Ny, God, Brugt, MegetBrugt }
        public enum LagerStatus { PaaLager, Reserveret, Forespurgt, IkkePaaLager }

        public class Spil
        {
            public string Titel { get; set; }
            public Genre Genre { get; set; }
            public Stand Stand { get; set; }
            public int Spillere { get; set; }
            public double Pris { get; set; }
            public LagerStatus Lager { get; set; }

            public override string ToString()
            {
                return $"{Titel} - {Genre} - {Stand} - {Spillere} spillere - {Pris} kr - {Lager}";
            }
        }

        public class Medarbejder
        {
            public string Navn { get; set; }
            public string Mail { get; set; }

            public List<Spil> SoegSpil(List<Spil> spilListe, string titel = null, Genre? genre = null, Stand? stand = null, int? spillere = null, double? prisMin = null, double? prisMax = null, LagerStatus? lager = null)
            {
                return spilListe
                    .Where(s => (string.IsNullOrEmpty(titel) || s.Titel.Contains(titel, StringComparison.OrdinalIgnoreCase)) &&
                                (!genre.HasValue || s.Genre == genre) &&
                                (!stand.HasValue || s.Stand == stand) &&
                                (!spillere.HasValue || s.Spillere == spillere) &&
                                (!prisMin.HasValue || s.Pris >= prisMin) &&
                                (!prisMax.HasValue || s.Pris <= prisMax) &&
                                (!lager.HasValue || s.Lager == lager))
                    .ToList();
            }
        }

        class Program
        {
            static void Main()
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
        }

