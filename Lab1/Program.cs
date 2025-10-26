using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("To jest cwiczenie 1");

        Zwierze z1 = new Zwierze();
        Zwierze z2 = new Zwierze("Mruczek", "Kot", 4); 
        Zwierze z3 = new Zwierze(z2);

        z1.daj_glos();
        z2.daj_glos();
        z3.daj_glos();

        Console.WriteLine($"Liczba zwierzat: {Zwierze.PodajLiczbeZwierzat()}");
    }
}

public class Zwierze
{
    private string nazwa;
    private string gatunek;
    private int liczbaNog;

    private static int liczbaZwierzat = 0;

    public string GetNazwa() => nazwa;
    public string GetGatunek() => gatunek;
    public int GetLiczbaNog() => liczbaNog;

    public void SetNazwa(string nowaNazwa)
    {
        nazwa = nowaNazwa;
    }

    public Zwierze()
    {
        nazwa = "Rex";
        gatunek = "Pies";
        liczbaNog = 4;
        liczbaZwierzat++;
    }

    public Zwierze(string nazwa, string gatunek, int liczbaNog)
    {
        this.nazwa = nazwa;
        this.gatunek = gatunek;
        this.liczbaNog = liczbaNog;
        liczbaZwierzat++;
    }

    public Zwierze(Zwierze inne)
    {
        this.nazwa = inne.nazwa;
        this.gatunek = inne.gatunek;
        this.liczbaNog = inne.liczbaNog;
        liczbaZwierzat++;
    }

    public void daj_glos()
    {
        switch (gatunek.ToLower())
        {
            case "kot":
                Console.WriteLine($"{nazwa} mówi: Miau!");
                break;
            case "pies":
                Console.WriteLine($"{nazwa} mówi: Hau hau!");
                break;
            case "krowa":
                Console.WriteLine($"{nazwa} mówi: Muuu!");
                break;
            default:
                Console.WriteLine($"{nazwa} wydaje nieokreślony dźwięk.");
                break;
        }
    }
    public static int PodajLiczbeZwierzat()
    {
        return liczbaZwierzat;
    }
}
