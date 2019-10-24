using ppedv.ProjectAli.Data.EF;
using ppedv.ProjectAli.Domain;
using ppedv.ProjectAli.Logic;
using System;
using System.Linq;

namespace ppedv.ProjectAli.UI.Konsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variante "ohne Tests"

            Core core = new Core(new EFRepository());
            core.GenerateDemoData();

            // var result = .....

            var allAircrafts = core.GetAllAircraft();

            AircraftType airbus = allAircrafts.First(x => x.Model == "Airbus 380");

            var allAirportsForAirbus = core.GetAllAirportsFor(airbus);
            foreach (var item in allAirportsForAirbus)
            {
                Console.WriteLine($"{item.Iata} supports Airbus 380");
            }
        }
    }
}
