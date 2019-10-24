using ppedv.ProjectAli.Data.EF;
using System;
using System.Linq;

namespace ppedv.ProjectAli.UI.Konsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variante "ohne Tests"

            EFContext context = new EFContext();
            context.Database.EnsureCreated();

            var result = context.Flight.ToList();

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
