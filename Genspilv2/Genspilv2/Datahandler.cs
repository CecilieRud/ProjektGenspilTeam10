using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspilv2
{
    public class Datahandler
    {
            public string FilePath { get; set; } // Sti til filen, der gemmer data

            public Datahandler(string filePath)
            {
                FilePath = filePath; // Sætter filstien ved oprettelse af Datahandler
            }

            // Metode til at gemme en liste af spil i en fil
            public void SaveGame(List<Game> games)
            {
                using (StreamWriter sw = new StreamWriter(FilePath)) // Åbner filen til skrivning
                {
                    foreach (var game in games)
                    {
                        
                            sw.WriteLine(game.ToString()); // Gemmer hvert spil som en linje i filen
                        
                    }
                }
            }

        // Metode til at indlæse en liste af spil fra en fil
        public List<Game> LoadGamesFromFile()
        {
            List<Game> games = new List<Game>();

            using (StreamReader sr = new StreamReader(FilePath)) // Åbner filen til læsning
            {
                string line;
                while ((line = sr.ReadLine()) != null) // Læser hver linje i filen
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        games.Add(Game.FromString(line)); // Opretter en Game fra linjen og tilføjer til listen
                    }
                }
            }

            return games; // Returnerer listen af spil
        }
    }
}

