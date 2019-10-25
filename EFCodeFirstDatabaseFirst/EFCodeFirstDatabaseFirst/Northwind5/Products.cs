﻿using System;
using System.Collections.Generic;

namespace EFCodeFirstDatabaseFirst.Northwind5
{
    public partial class Products
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public short ProductId { get; set; }
        public string ProductName { get; set; }
        public short? SupplierId { get; set; }
        public short? CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public float? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public int Discontinued { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Suppliers Supplier { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
