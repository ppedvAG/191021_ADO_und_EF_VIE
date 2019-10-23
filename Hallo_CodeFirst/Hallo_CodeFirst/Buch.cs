using System.Collections.Generic;

namespace Hallo_CodeFirst
{
    public class Buch : Entity
    {
        public string Titel { get; set; }
        public string Autor { get; set; }
        public int Seiten { get; set; }
        public decimal Preis { get; set; }

        public virtual HashSet<Buchgeschäft> Geschäfte { get; set; } = new HashSet<Buchgeschäft>();
    }

}
