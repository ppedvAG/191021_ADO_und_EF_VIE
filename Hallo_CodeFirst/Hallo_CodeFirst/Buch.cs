using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hallo_CodeFirst
{
    // [Table("Bücher", Schema = "buc")]
    public class Buch : Entity
    {
        public string Titel { get; set; }
        public string Autor { get; set; }
        public int Seiten { get; set; }
        public decimal Preis { get; set; }

        public virtual HashSet<Buchgeschäft> Geschäfte { get; set; } = new HashSet<Buchgeschäft>();
    }

}
