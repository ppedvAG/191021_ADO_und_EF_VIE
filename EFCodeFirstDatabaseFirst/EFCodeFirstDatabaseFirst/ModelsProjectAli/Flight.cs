using System;
using System.Collections.Generic;

namespace EFCodeFirstDatabaseFirst.ModelsProjectAli
{
    public partial class Flight
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public int? DepartureId { get; set; }
        public int? DestinationId { get; set; }
        public TimeSpan Duration { get; set; }
        public string AircraftId { get; set; }
        public int? AircraftTypeId { get; set; }

        public virtual AircraftType AircraftType { get; set; }
        public virtual Airport Departure { get; set; }
        public virtual Airport Destination { get; set; }
    }
}
