using System.Collections.Generic;

namespace Hallo_CodeFirst
{
    public class Buchgeschäft : Entity
    {
        public string Name { get; set; }
        public string Adresse { get; set; }

        public virtual HashSet<Buch> Bücher { get; set; } = new HashSet<Buch>();
    }

}
