using System;
using System.Collections.Generic;
using System.Linq;

public interface IModular
{
    double Module();
}

public class ComplexNumber :
    ICloneable,
    IEquatable<ComplexNumber>,
    IModular,
    IComparable<ComplexNumber>
{
    private double re;
    private double im;

    public double Re { get => re; set => re = value; }
    public double Im { get => im; set => im = value; }

    public ComplexNumber(double re, double im)
    {
        this.re = re;
        this.im = im;
    }

    public override string ToString()
    {
        string sign = im >= 0 ? "+" : "-";
        return $"{re} {sign} {Math.Abs(im)}i";
    }

    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        => new ComplexNumber(a.re + b.re, a.im + b.im);

    public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        => new ComplexNumber(a.re - b.re, a.im - b.im);

    public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        => new ComplexNumber(
            a.re * b.re - a.im * b.im,
            a.re * b.im + a.im * b.re
        );

    public static ComplexNumber operator -(ComplexNumber a)
        => new ComplexNumber(a.re, -a.im);

    public object Clone()
        => new ComplexNumber(re, im);

    public bool Equals(ComplexNumber other)
    {
        if (other is null) return false;
        return re == other.re && im == other.im;
    }

    public override bool Equals(object obj)
        => obj is ComplexNumber other && Equals(other);

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + re.GetHashCode();
            hash = hash * 23 + im.GetHashCode();
            return hash;
        }
    }

    public static bool operator ==(ComplexNumber a, ComplexNumber b)
        => a?.Equals(b) ?? b is null;

    public static bool operator !=(ComplexNumber a, ComplexNumber b)
        => !(a == b);

    public double Module()
        => Math.Sqrt(re * re + im * im);

    public int CompareTo(ComplexNumber other)
    {
        if (other is null) return 1;
        return this.Module().CompareTo(other.Module());
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("TABLICA");

        ComplexNumber[] array =
        {
            new ComplexNumber(3, 4),
            new ComplexNumber(1, -2),
            new ComplexNumber(-2, 3),
            new ComplexNumber(0, -5),
            new ComplexNumber(2, 1)
        };

        foreach (var z in array)
            Console.WriteLine(z);

        Array.Sort(array);

        Console.WriteLine("\nPo sortowaniu:");
        foreach (var z in array)
            Console.WriteLine(z);

        Console.WriteLine($"\nMin: {array.Min()}");
        Console.WriteLine($"Max: {array.Max()}");

        Console.WriteLine("\nFiltrowanie (Im >= 0):");
        foreach (var z in array.Where(z => z.Im >= 0))
            Console.WriteLine(z);




        Console.WriteLine("\nLISTA");

        List<ComplexNumber> list = new List<ComplexNumber>(array);

        list.RemoveAt(1);
        Console.WriteLine("\nPo usunięciu 2. elementu:");
        list.ForEach(Console.WriteLine);

        list.Remove(list.Min());
        Console.WriteLine("\nPo usunięciu minimum:");
        list.ForEach(Console.WriteLine);

        list.Clear();
        Console.WriteLine("\nPo wyczyszczeniu listy:");
        Console.WriteLine(list.Count == 0 ? "Lista pusta" : "Błąd");



        Console.WriteLine("\nHASHSET");

        HashSet<ComplexNumber> set = new HashSet<ComplexNumber>
        {
            new ComplexNumber(6, 7),
            new ComplexNumber(1, 2),
            new ComplexNumber(6, 7),
            new ComplexNumber(1, -2),
            new ComplexNumber(-5, 9)
        };

        Console.WriteLine("Zawartość zbioru:");
        foreach (var z in set)
            Console.WriteLine(z);

        Console.WriteLine($"\nMin: {set.Min()}");
        Console.WriteLine($"Max: {set.Max()}");

        Console.WriteLine("\nSortowanie zbioru:");
        set.ToList().ForEach(Console.WriteLine);

        Console.WriteLine("\nFiltrowanie (Im < 0):");
        foreach (var z in set.Where(z => z.Im < 0))
            Console.WriteLine(z);




        Console.WriteLine("\nSŁOWNIK");

        Dictionary<string, ComplexNumber> dict =
            new Dictionary<string, ComplexNumber>
        {
            { "z1", new ComplexNumber(6, 7) },
            { "z2", new ComplexNumber(1, 2) },
            { "z3", new ComplexNumber(6, 7) },
            { "z4", new ComplexNumber(1, -2) },
            { "z5", new ComplexNumber(-5, 9) }
        };


        Console.WriteLine("a) Elementy słownika (klucz, wartość):");
        foreach (var pair in dict)
            Console.WriteLine($"({pair.Key}, {pair.Value})");


        Console.WriteLine("\nb) Klucze:");
        foreach (var key in dict.Keys)
            Console.WriteLine(key);

        Console.WriteLine("\nWartości:");
        foreach (var value in dict.Values)
            Console.WriteLine(value);


        Console.WriteLine("\nc) Czy istnieje klucz \"z6\"?");
        Console.WriteLine(dict.ContainsKey("z6") ? "TAK" : "NIE");


        Console.WriteLine("\nd) Operacje jak w zadaniu 2:");


        ComplexNumber minValue = dict.Values.Min();
        Console.WriteLine($"Minimum (wartości): {minValue}");


        Console.WriteLine("Wartości z ujemną częścią urojoną:");
        foreach (var z in dict.Values.Where(z => z.Im < 0))
            Console.WriteLine(z);


        dict.Remove("z3");
        Console.WriteLine("\ne) Po usunięciu klucza \"z3\":");
        foreach (var pair in dict)
            Console.WriteLine($"({pair.Key}, {pair.Value})");


        string secondKey = dict.Keys.ElementAt(1);
        dict.Remove(secondKey);

        Console.WriteLine("\nf) Po usunięciu drugiego elementu:");
        foreach (var pair in dict)
            Console.WriteLine($"({pair.Key}, {pair.Value})");


        dict.Clear();
        Console.WriteLine("\ng) Po wyczyszczeniu słownika:");
        Console.WriteLine(dict.Count == 0 ? "Słownik pusty" : "Błąd");
    }
}
