
namespace ppedv.ProjectAli.Domain
{
    public class Airport : Entity
    {
        public string LocInt { get; set; }
        public string Decode { get; set; }
        public string Iata { get; set; }

        // ToDo: Class oder Struct für Geolocation entwerfen
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Elevation { get; set; }
    }

}
