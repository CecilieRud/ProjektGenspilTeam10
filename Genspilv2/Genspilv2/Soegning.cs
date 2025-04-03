using Genspilv2;

public enum Genre { Strategi, Familie, Quiz, PartySpil }
public enum Stand { Ny, God, Brugt, MegetBrugt }
public enum LagerStatus { PaaLager, Reserveret, Forespurgt, IkkePaaLager }

public class Spil
{
    public string Title { get; set; }
    public Genre genre { get; set; }
    public State state { get; set; }
    public int Players { get; set; }
    public double Price { get; set; }
    public LagerStatus Lager { get; set; }
    public enum Genre
    {
        Strategi,
        Quiz,
        Familie,
        Ordspil,
        Børnespil
    }

    public enum State
    {
        Ny,
        God,
        Brugt,
        Meget_Brugt
    }

    public override string ToString()
    {
        return $"{Title} - {genre} - {state} - {Players} spillere - {Price} kr - {Lager}";
    }

    public static Spil FromString(string data)
    {
        string[] parts = data.Split(',');
        return new Spil
        {
            Title = parts[0],
            genre = Enum.Parse<Genre>(parts[1]),
            Players = int.Parse(parts[2]),
            state = Enum.Parse<State>(parts[3]),
            Price = double.Parse(parts[4]),
            Lager = Enum.Parse<LagerStatus>(parts[5]),
        };
    }

    public class Medarbejder
    {
        public string Navn { get; set; }
        public string Mail { get; set; }

        public List<Spil> SoegSpil(List<Spil> spilListe, string titel = null, Genre? genre = null, State? state = null, int? players = null, double? priceMin = null, double? priceMax = null, LagerStatus? lager = null)
        {
            return spilListe
                .Where(s => (string.IsNullOrEmpty(titel) || s.Title.Contains(titel, StringComparison.OrdinalIgnoreCase)) &&
                            (!genre.HasValue || s.genre == genre) &&
                            (!state.HasValue || s.state == state) &&
                            (!players.HasValue || s.Players == players) &&
                            (!priceMin.HasValue || s.Price >= priceMin) &&
                            (!priceMax.HasValue || s.Price <= priceMax) &&
                            (!lager.HasValue || s.Lager == lager))
                .ToList();
        }
    }
}

namespace Genspilv2
{
    internal class Soegning
    {
    }
}
