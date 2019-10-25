using System;
using System.Collections.Generic;

namespace EFCodeFirstDatabaseFirst.Northwind5
{
    public partial class UsStates
    {
        public short StateId { get; set; }
        public string StateName { get; set; }
        public string StateAbbr { get; set; }
        public string StateRegion { get; set; }
    }
}
