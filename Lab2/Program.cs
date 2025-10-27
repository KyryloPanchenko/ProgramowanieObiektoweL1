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

            powiedz_cos(z1);
            powiedz_cos(p1);
        }
    }
}
