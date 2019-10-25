using System;
using System.Collections.Generic;

namespace EFCodeFirstDatabaseFirst.ModelsProjectAli
{
    public partial class AircraftType
    {
        public AircraftType()
        {
            Flight = new HashSet<Flight>();
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public string Code { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int Wtc { get; set; }

        public virtual ICollection<Flight> Flight { get; set; }
    }
}
