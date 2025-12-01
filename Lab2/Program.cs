using System;

namespace Lab2
{
    class Zwierze
    {
        protected string nazwa;

        public Zwierze(string nazwa)
        {
            this.nazwa = nazwa;
        }

        public virtual void daj_glos()
        {
            Console.WriteLine("...");
        }
    }

    class Pies : Zwierze
    {
        public Pies(string nazwa) : base(nazwa)
        {
        }

        public override void daj_glos()
        {
            Console.WriteLine($"{nazwa} robi woof woof!");
        }
    }

    class Kot : Zwierze
    {
        public Kot(string nazwa) : base(nazwa)
        {
        }

        public override void daj_glos()
        {
            Console.WriteLine($"{nazwa} robi miau miau!");
        }
    }

    class Waz : Zwierze
    {
        public Waz(string nazwa) : base(nazwa)
        {
        }

        public override void daj_glos()
        {
            Console.WriteLine($"{nazwa} robi ssssssss!");
        }
    }

    public abstract class Pracownik
    {
        public abstract void Pracuj();
    }

    public class Piekarz : Pracownik
    {
        public override void Pracuj()
        {
            Console.WriteLine("Trwa pieczenie...");
        }
    }

    class A
    {
        public A()
        {
            Console.WriteLine("To jest konstruktor A");
        }
    }

    class B : A
    {
        public B() : base()
        {
            Console.WriteLine("To jest konstruktor B");
        }
    }

    class C : B
    {
        public C() : base()
        {
            Console.WriteLine("To jest konstruktor C");
        }
    }

    class Program
    {
        public static void powiedz_cos(Zwierze z)
        {
            z.daj_glos();
        }

        static void Main(string[] args)
        {
            Zwierze z1 = new Zwierze("Nieznane");
            Pies p1 = new Pies("Rex");
            Kot k1 = new Kot("Mruczek");
            Waz w1 = new Waz("Zielony");

            powiedz_cos(z1);
            Console.WriteLine($"Typ obiektu z1: {z1.GetType()}");

            powiedz_cos(p1);
            Console.WriteLine($"Typ obiektu p1: {p1.GetType()}");

            powiedz_cos(k1);
            Console.WriteLine($"Typ obiektu k1: {k1.GetType()}");

            powiedz_cos(w1);
            Console.WriteLine($"Typ obiektu w1: {w1.GetType()}");

            Piekarz piekarz = new Piekarz();
            piekarz.Pracuj();

            Console.WriteLine("\nTworzenie obiektu klasy A:");
            A obiektA = new A();

            Console.WriteLine("\nTworzenie obiektu klasy B:");
            B obiektB = new B();

            Console.WriteLine("\nTworzenie obiektu klasy C:");
            C obiektC = new C();
        }
    }
}
