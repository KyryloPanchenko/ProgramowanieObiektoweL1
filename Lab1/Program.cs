using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("To jest cwiczenie 1\n");

        Zwierze[] zwierzeta = new Zwierze[3];

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Podaj dane dla zwierzęcia nr {i + 1}:");

            Console.Write("Nazwa: ");
            string nazwa = Console.ReadLine();

            Console.Write("Gatunek: ");
            string gatunek = Console.ReadLine();

            Console.Write("Liczba nóg: ");
            int liczbaNog;
            while (!int.TryParse(Console.ReadLine(), out liczbaNog) || liczbaNog < 0)
            {
                Console.Write("Błędna wartość. Podaj ponownie liczbę nóg: ");
            }

            zwierzeta[i] = new Zwierze(nazwa, gatunek, liczbaNog);
            Console.WriteLine();
        }

        Zwierze klon = new Zwierze(zwierzeta[1]);
        klon.Nazwa = "Klon_" + klon.Nazwa; 

        Console.WriteLine("\n=== Informacje o wszystkich zwierzętach ===");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"\nZwierzę {i + 1}:");
            Console.WriteLine($"Nazwa: {zwierzeta[i].Nazwa}");
            Console.WriteLine($"Gatunek: {zwierzeta[i].GetGatunek()}");
            Console.WriteLine($"Liczba nóg: {zwierzeta[i].GetLiczbaNog()}");
            zwierzeta[i].daj_glos();
        }

        Console.WriteLine("\nZwierzę 4 (klon):");
        Console.WriteLine($"Nazwa: {klon.Nazwa}");
        Console.WriteLine($"Gatunek: {klon.GetGatunek()}");
        Console.WriteLine($"Liczba nóg: {klon.GetLiczbaNog()}");
        klon.daj_glos();

        Console.WriteLine($"\nŁączna liczba utworzonych zwierząt: {Zwierze.PodajLiczbeZwierzat()}");
    }
}

public class Zwierze
{
    private string nazwa;
    private string gatunek;
    private int liczbaNog;

    private static int liczbaZwierzat = 0;

    public string Nazwa
    {
        get { return nazwa; }
        set { nazwa = value; }
    }

    public string GetGatunek() => gatunek;
    public int GetLiczbaNog() => liczbaNog;

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
