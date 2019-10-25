﻿using System;
using System.Collections.Generic;

namespace EFCodeFirstDatabaseFirst.Northwind5
{
    public partial class Region
    {
        public Region()
        {
            Territories = new HashSet<Territories>();
        }

        public short RegionId { get; set; }
        public string RegionDescription { get; set; }

        public virtual ICollection<Territories> Territories { get; set; }
    }
}
