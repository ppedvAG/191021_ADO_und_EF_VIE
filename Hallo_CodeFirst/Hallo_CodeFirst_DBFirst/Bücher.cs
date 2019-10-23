namespace Hallo_CodeFirst_DBFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bu.Bücher")]
    public partial class Bücher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bücher()
        {
            Buchgeschäft = new HashSet<Buchgeschäft>();
        }

        public int ID { get; set; }

        public string Titel { get; set; }

        public string Autor { get; set; }

        public int Seiten { get; set; }

        [Column(TypeName = "money")]
        public decimal kaChing { get; set; }

        public decimal Preisbindung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Buchgeschäft> Buchgeschäft { get; set; }
    }
}
