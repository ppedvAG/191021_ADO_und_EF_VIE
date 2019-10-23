using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hallo_CodeFirst
{
    // Data Annotations
    // [Table("AlleBuchgeschäfte")]
    // [Table("Buchgeschäft",Schema ="ges")]
    public class Buchgeschäft : Entity
    {
        // [Column("Buchgeschäftsname")]
        // [MaxLength(15)]
        public string Name { get; set; }
        public string Adresse { get; set; }

        public virtual HashSet<Buch> Bücher { get; set; } = new HashSet<Buch>();
    }

}
