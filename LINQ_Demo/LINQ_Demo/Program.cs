using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> personen = new List<Person>();
            personen.Add(new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 });
            personen.Add(new Person { Vorname = "Anna", Nachname = "Nass", Alter = 20, Kontostand = 200 });
            personen.Add(new Person { Vorname = "Peter", Nachname = "Silie", Alter = 30, Kontostand = 3000 });
            personen.Add(new Person { Vorname = "Franz", Nachname = "Ose", Alter = 40, Kontostand = -400 });
            personen.Add(new Person { Vorname = "Martha", Nachname = "Pfahl", Alter = 50, Kontostand = 500000 });
            personen.Add(new Person { Vorname = "Klara", Nachname = "Fall", Alter = 60, Kontostand = 6666 });
            personen.Add(new Person { Vorname = "Albert", Nachname = "Tross", Alter = 70, Kontostand = 1234567 });
            personen.Add(new Person { Vorname = "Anna", Nachname = "Bolika", Alter = 80, Kontostand = 987653 });
            personen.Add(new Person { Vorname = "Bill", Nachname = "Dung", Alter = 90, Kontostand = 326423234235234 });
            personen.Add(new Person { Vorname = "Axel", Nachname = "Schweiß", Alter = 100, Kontostand = -12312313100 });


            

            Console.WriteLine("---ANFANG---");
            Console.ReadKey();
        }
    }
}
