using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Demo
{
    class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        public decimal Kontostand { get; set; }
    }

    class Buch
    {
        public string[] Author { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
