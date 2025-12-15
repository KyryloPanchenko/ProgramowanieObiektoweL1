using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Newtonsoft.Json;

public class Student
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public List<int> Oceny { get; set; }
}

class Program
{
    static void Main()
    {
        string tekstFile = "dane.txt";
        string jsonFile = "studenci.json";

        // ZADANIE 2 – zapis użytkownika do pliku
        WriteUserInputToFile(tekstFile);

        // ZADANIE 3 – odczyt z pliku
        ReadFileLineByLine(tekstFile);


        // ZADANIE 4 – dopisywanie do pliku
        AppendUserInputToFile(tekstFile);
        ReadFileLineByLine(tekstFile);

        // ZADANIE 6 – zapis studentów do JSON
        SaveStudentsToJson(jsonFile);

        // ZADANIE 7 – odczyt studentów z JSON
        LoadStudentsFromJson(jsonFile);
    }

    // ZADANIE 2
    static void WriteUserInputToFile(string filePath)
    {
        Console.WriteLine("Podaj tekst (pusta linia kończy wprowadzanie):");

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) break;
                writer.WriteLine(input);
            }
        }

        Console.WriteLine("Dane zapisane do pliku.\n");
    }

    // ZADANIE 3
    static void ReadFileLineByLine(string filePath)
    {
        Console.WriteLine("Odczyt danych z pliku:");

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Plik nie istnieje.\n");
            return;
        }

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

        Console.WriteLine();
    }

    // ZADANIE 4
    static void AppendUserInputToFile(string filePath)
    {
        Console.WriteLine("Dodaj kolejne linie do pliku (pusta linia kończy):");

        using (StreamWriter writer = new StreamWriter(filePath, append: true))
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) break;
                writer.WriteLine(input);
            }
        }

        Console.WriteLine("Nowe dane dopisane do pliku.\n");
    }

    // ZADANIE 6 – zapis studentów do JSON
    static void SaveStudentsToJson(string filePath)
    {
        List<Student> students = new List<Student>
        {
            new Student { Imie = "Jan", Nazwisko = "Kowalski", Oceny = new List<int>{5,4,3} },
            new Student { Imie = "Anna", Nazwisko = "Nowak", Oceny = new List<int>{4,4,5} },
            new Student { Imie = "Piotr", Nazwisko = "Zieliński", Oceny = new List<int>{3,3,4} }
        };

        string json = JsonConvert.SerializeObject(students, Formatting.Indented);
        File.WriteAllText(filePath, json);

        Console.WriteLine("Lista studentów zapisana do pliku JSON.\n");
    }

    // ZADANIE 7 – odczyt studentów z JSON
    static void LoadStudentsFromJson(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Plik JSON nie istnieje.\n");
            return;
        }

        string json = File.ReadAllText(filePath);
        List<Student> students = JsonConvert.DeserializeObject<List<Student>>(json);

        Console.WriteLine("Odczytani studenci:\n");

        foreach (var student in students)
        {
            Console.WriteLine($"Imię: {student.Imie}");
            Console.WriteLine($"Nazwisko: {student.Nazwisko}");
            Console.WriteLine("Oceny:");
            foreach (var ocena in student.Oceny)
            {
                Console.WriteLine(ocena);
            }
            Console.WriteLine();
        }
    }
}
