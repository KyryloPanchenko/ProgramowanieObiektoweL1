using System;

public interface IModular
{
    double Module();
}

public class ComplexNumber : ICloneable, IEquatable<ComplexNumber>, IModular
{
    private double re;
    private double im;

    public double Re
    {
        get { return re; }
        set { re = value; }
    }

    public double Im
    {
        get { return im; }
        set { im = value; }
    }
i
    public ComplexNumber(double real, double imaginary)
    {
        re = real;
        im = imaginary;
    }

    public override string ToString()
    {
        if (im >= 0)
        {
            return $"{re} + {im}i";
        }
        else
        {
            return $"{re} - {Math.Abs(im)}i";
        }
    }

    public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
    {
        return new ComplexNumber(c1.Re + c2.Re, c1.Im + c2.Im);
    }

    public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
    {
        return new ComplexNumber(c1.Re - c2.Re, c1.Im - c2.Im);
    }

    public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
    {
        double realPart = c1.Re * c2.Re - c1.Im * c2.Im;
        double imaginaryPart = c1.Re * c2.Im + c1.Im * c2.Re;
        return new ComplexNumber(realPart, imaginaryPart);
    }

    public object Clone()
    {
        return new ComplexNumber(this.Re, this.Im);
    }

    public bool Equals(ComplexNumber other)
    {
        if (other == null)
            return false;
        return this.Re == other.Re && this.Im == other.Im;
    }

    public static bool operator ==(ComplexNumber c1, ComplexNumber c2)
    {
        if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
            return false;
        return c1.Equals(c2);
    }

    public static bool operator !=(ComplexNumber c1, ComplexNumber c2)
    {
        return !(c1 == c2);
    }

    public static ComplexNumber operator -(ComplexNumber c)
    {
        return new ComplexNumber(c.Re, -c.Im);
    }

    public override int GetHashCode()
    {
        return (Re, Im).GetHashCode();
    }

    public double Module()
    {
        return Math.Sqrt(Re * Re + Im * Im);
    }
}

class Program
{
    public static void Main(string[] args)
    {
        ComplexNumber c1 = new ComplexNumber(3, 4);
        ComplexNumber c2 = new ComplexNumber(1, -2);
        ComplexNumber c3 = new ComplexNumber(5, 6);
        ComplexNumber c4 = new ComplexNumber(-2, 3);

        Console.WriteLine($"Liczba c1: {c1}");
        Console.WriteLine($"Liczba c2: {c2}");
        Console.WriteLine($"Liczba c3: {c3}");
        Console.WriteLine($"Liczba c4: {c4}");
        Console.WriteLine();

        Console.WriteLine($"Moduł c1: {c1.Module()}");
        Console.WriteLine($"Moduł c2: {c2.Module()}");
        Console.WriteLine($"Moduł c3: {c3.Module()}");
        Console.WriteLine($"Moduł c4: {c4.Module()}");
        Console.WriteLine();

        ComplexNumber sum = c1 + c2;
        Console.WriteLine($"c1 + c2 = {sum}");

        ComplexNumber difference = c1 - c2;
        Console.WriteLine($"c1 - c2 = {difference}");

        ComplexNumber product = c1 * c2;
        Console.WriteLine($"c1 * c2 = {product}");
        Console.WriteLine();

        ComplexNumber conjugateC1 = -c1;
        Console.WriteLine($"Sprzężenie c1: {conjugateC1}");

        Console.WriteLine($"c1 == c2: {c1 == c2}");
        Console.WriteLine($"c1 != c2: {c1 != c2}");
        Console.WriteLine($"c3 == c4: {c3 == c4}");
        Console.WriteLine();

        ComplexNumber c1Clone = (ComplexNumber)c1.Clone();
        Console.WriteLine($"Klon c1: {c1Clone}");
    }
}
