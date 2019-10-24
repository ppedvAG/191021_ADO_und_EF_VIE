using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.ProjectAli.Domain
{
    public abstract class Entity
    {
        public int ID { get; set; }
        public bool IsDeleted { get; set; } // Soft Delete
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime DeletedDate { get; set; }
    }

}
