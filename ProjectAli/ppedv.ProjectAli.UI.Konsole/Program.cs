using ppedv.ProjectAli.Data.EF;
using ppedv.ProjectAli.Domain;
using ppedv.ProjectAli.Logic;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ppedv.ProjectAli.UI.Konsole
{
    class Program
    {
        static async Task Main(string[] args)
        {

            #region Selbst aufrufen
            //Core core = new Core(new EFRepository());
            //core.GenerateDemoData();

            //// var result = .....

            //var allAircrafts = core.GetAllAircraft();

            //AircraftType airbus = allAircrafts.First(x => x.Model == "Airbus 380");

            //var allAirportsForAirbus = core.GetAllAirportsFor(airbus);
            //foreach (var item in allAirportsForAirbus)
            //{
            //    Console.WriteLine($"{item.Iata} supports Airbus 380");
            //} 
            #endregion

            #region ASP - API konsumieren

            Console.WriteLine("Klick für Start:");
            Console.ReadKey();

            string data = string.Empty;
            Airport[] result = null;
            using (HttpClient client = new HttpClient())
            {
                data = await client.GetStringAsync("https://localhost:44377/api/AirportAPI");
                var xmlStream = await client.GetStreamAsync("https://localhost:44377/api/AirportAPI");

                // <--- Objekte erstellen: Deserialisieren
                XmlSerializer serializer = new XmlSerializer(typeof(Airport[]));
                result = (Airport[])serializer.Deserialize(xmlStream);
            }

            Console.WriteLine("----- Heruntergeladenes XML: --------");
            Console.WriteLine(data); // reines XML
            Console.WriteLine("-------------------------------------");


            Console.WriteLine("----- Deserialisierten Daten --------");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.ID}: {item.Decode}");
            }
            Console.WriteLine("-------------------------------------");
            Console.ReadKey();
            #endregion
        }
    }
}
