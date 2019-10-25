using System;
using System.Collections.Generic;

namespace EFCodeFirstDatabaseFirst.Northwind5
{
    public partial class EmployeeTerritories
    {
        public short EmployeeId { get; set; }
        public string TerritoryId { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Territories Territory { get; set; }
    }
}
