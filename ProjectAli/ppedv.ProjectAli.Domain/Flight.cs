using System;

namespace ppedv.ProjectAli.Domain
{
    public class Flight
    {
        public virtual Airport Departure { get; set; }
        public virtual Airport Destination { get; set; }
        public TimeSpan Duration { get; set; }
        public string AircraftID { get; set; }
        public virtual AircraftType AircraftType { get; set; }
    }

}
