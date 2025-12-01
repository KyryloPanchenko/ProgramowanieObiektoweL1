using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "dane.txt";

        int liczbaPytan = 5;

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < liczbaPytan; i++)
            {
                Console.WriteLine($"Podaj tekst #{i + 1}:");
                string input = Console.ReadLine();
                writer.WriteLine(input);
            }
        }

        Console.WriteLine($"Wszystkie dane zostały zapisane do pliku: {filePath}");
    }
}
