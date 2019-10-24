namespace ppedv.ProjectAli.Domain
{
    public class Airport : Entity
    {
        public string LocInt { get; set; }
        public string Decode { get; set; }
        public string Iata { get; set; }
        public Geolocation Location { get; set; }
    }

}
