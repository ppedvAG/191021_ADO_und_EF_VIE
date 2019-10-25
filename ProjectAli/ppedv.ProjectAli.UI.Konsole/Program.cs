using Newtonsoft.Json;
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

            Console.WriteLine("Bitte wählen Sie die Art des Ergebnisses: XML(1) oder JSON(2)");
            char erg = Console.ReadKey().KeyChar;

            string data = string.Empty;
            Airport[] result = null;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                if(erg == '1') // JSON
                {
                    client.DefaultRequestHeaders.Accept.ParseAdd("text/xml");
                    data = await client.GetStringAsync("https://localhost:44377/api/AirportAPI");
                    var xmlStream = await client.GetStreamAsync("https://localhost:44377/api/AirportAPI");

                    // <--- Objekte erstellen: Deserialisieren
                    XmlSerializer serializer = new XmlSerializer(typeof(Airport[]));
                    result = (Airport[])serializer.Deserialize(xmlStream);
                }
                else 
                {
                    // Alternative:
                    client.DefaultRequestHeaders.Accept.ParseAdd("text/json");
                    data = await client.GetStringAsync("https://localhost:44377/api/AirportAPI");
                    result = JsonConvert.DeserializeObject<Airport[]>(data);
                }

            }

            Console.WriteLine("----- Heruntergeladenen Daten: --------");
            Console.WriteLine(data); // XML oder JSON
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
