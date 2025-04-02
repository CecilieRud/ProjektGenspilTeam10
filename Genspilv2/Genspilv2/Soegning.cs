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

namespace Genspilv2
{
    internal class Soegning
    {
    }
}
