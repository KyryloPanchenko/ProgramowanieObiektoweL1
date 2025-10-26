using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("To jest cwiczenie 1\n");

        Zwierze[] zwierzeta = new Zwierze[3];

        // Wczytywanie danych o 3 zwierzętach
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

        // Utworzenie klona (kopiowanie 2. zwierzęcia)
        Zwierze klon = new Zwierze(zwierzeta[1]);
        klon.SetNazwa("Klon_" + klon.GetNazwa());

        Console.WriteLine("\n=== Informacje o wszystkich zwierzętach ===");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"\nZwierzę {i + 1}:");
            Console.WriteLine($"Nazwa: {zwierzeta[i].GetNazwa()}");
            Console.WriteLine($"Gatunek: {zwierzeta[i].GetGatunek()}");
            Console.WriteLine($"Liczba nóg: {zwierzeta[i].GetLiczbaNog()}");
            zwierzeta[i].daj_glos();
        }

        // Wyświetlenie informacji o klonie
        Console.WriteLine("\nZwierzę 4 (klon):");
        Console.WriteLine($"Nazwa: {klon.GetNazwa()}");
        Console.WriteLine($"Gatunek: {klon.GetGatunek()}");
        Console.WriteLine($"Liczba nóg: {klon.GetLiczbaNog()}");
        klon.daj_glos();

        // Wyświetlenie liczby zwierząt
        Console.WriteLine($"\nŁączna liczba utworzonych zwierząt: {Zwierze.PodajLiczbeZwierzat()}");
    }
}

public class Zwierze
{
    // Pola prywatne
    private string nazwa;
    private string gatunek;
    private int liczbaNog;

    // Pole statyczne
    private static int liczbaZwierzat = 0;

    // Gettery
    public string GetNazwa() => nazwa;
    public string GetGatunek() => gatunek;
    public int GetLiczbaNog() => liczbaNog;

    // Setter dla nazwy
    public void SetNazwa(string nowaNazwa)
    {
        nazwa = nowaNazwa;
    }

    // Konstruktor bezparametrowy
    public Zwierze()
    {
        nazwa = "Rex";
        gatunek = "Pies";
        liczbaNog = 4;
        liczbaZwierzat++;
    }

    // Konstruktor z parametrami
    public Zwierze(string nazwa, string gatunek, int liczbaNog)
    {
        this.nazwa = nazwa;
        this.gatunek = gatunek;
        this.liczbaNog = liczbaNog;
        liczbaZwierzat++;
    }

    // Konstruktor kopiujący
    public Zwierze(Zwierze inne)
    {
        this.nazwa = inne.nazwa;
        this.gatunek = inne.gatunek;
        this.liczbaNog = inne.liczbaNog;
        liczbaZwierzat++;
    }

    // Metoda daj_glos()
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

    // Metoda statyczna zwracająca liczbę zwierząt
    public static int PodajLiczbeZwierzat()
    {
        return liczbaZwierzat;
    }
}
