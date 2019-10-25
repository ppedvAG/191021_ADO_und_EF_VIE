using System;
using System.Collections.Generic;

namespace EFCodeFirstDatabaseFirst.ModelsProjectAli
{
    public partial class Airport
    {
        public Airport()
        {
            FlightDeparture = new HashSet<Flight>();
            FlightDestination = new HashSet<Flight>();
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public string LocInt { get; set; }
        public string Decode { get; set; }
        public string Iata { get; set; }
        public double Elevation { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int SupportedWtc { get; set; }

        public virtual ICollection<Flight> FlightDeparture { get; set; }
        public virtual ICollection<Flight> FlightDestination { get; set; }
    }
}
