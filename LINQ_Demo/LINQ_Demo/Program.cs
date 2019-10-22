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
            #region Daten
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
            #endregion

            #region Variante ohne LINQ
            //// Anwendungsfall: Die Vornamen aller Personen in einem string[]
            //string[] alleVornamen = new string[personen.Count];
            //for (int i = 0; i < alleVornamen.Length; i++)
            //{
            //    alleVornamen[i] = personen[i].Vorname;
            //}

            //// Anwendungsfall: Die Vornamen aller Personen die Schulden haben in einer Liste
            //List<string> alleVornamenMitSchulden = new List<string>();
            //foreach (var item in personen)
            //{
            //    if (item.Kontostand < 0)
            //        alleVornamenMitSchulden.Add(item.Vorname);
            //}

            //// Anwendungsfall: Die Person mit den meisten Schulden
            //Person höchstenSchulden = null;
            //foreach (var item in personen)
            //{
            //    if (höchstenSchulden == null)
            //    {
            //        höchstenSchulden = item; // Erste Schleifendurchgang
            //        continue;
            //    }

            //    if (item.Kontostand < höchstenSchulden.Kontostand)
            //        höchstenSchulden = item;
            //}

            //// Anwendungsfall: Die Vornamen aller Personen die Schulden haben, Sortiert nach Alter absteigend in einer Liste
            //// usw..... 
            #endregion

            // Anwendungsfall: Die Vornamen aller Personen in einem string[]
            // Anwendungsfall: Die Vornamen aller Personen die Schulden haben in einer Liste
            // Anwendungsfall: Die Vornamen aller Personen die Schulden haben, Sortiert nach Alter absteigend in einer Liste
            // Anwendungsfall: Die Person mit den meisten Schulden

            // LINQ: 
            // SELECT -> Aus einer Auflistung Werte herausnehmen

            var result = personen.Select(x => x.Vorname)
                                 .ToArray();

            // WHERE -> Filtern mit einer Bedingung
            var result2 = personen.Where(x => x.Kontostand < 0)
                                  .Select(x => x.Vorname)
                                  .ToList();

            // ORDERBY, ORDERBYDESCENDING
            var result3 = personen.Where(x => x.Kontostand < 0)
                                  .OrderByDescending(x => x.Alter)
                                  .Select(x => x.Vorname)
                                  .ToArray();

            // FIRST, LAST   bzw FIRSTORDDEFAULT
            var result4 = personen.Where(x => x.Kontostand < 0)
                                  .OrderBy(x => x.Kontostand)
                                  .First();

            // TAKE, SKIP
            var result5 = personen.OrderByDescending(x => x.Alter)
                                  .Take(3); // Die ältesten 3

            var result6 = personen.OrderByDescending(x => x.Alter)
                                  .Skip(3); // Alle ausser die ältesten 3

            // ALL, ANY => Abfragen ob eines/alle eine bestimmte bedingung erfüllen

            if (personen.Any(x => x.Alter > 50)) // Wenn mindestens einer über 50 ist... führe IF aus ..
                ;

            int[] alleZahlen = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] ausnahme = { 3, 6, 9 };

            var result7 = alleZahlen.Except(ausnahme)
                                    .ToArray();

            // größter Kontostand
            decimal kontostand = personen.Max(x => x.Kontostand);
            // MIN, MAX, SUM, AVARAGE

            // SelectMany:

            Buch[] bücher = new Buch[]
            {
                new Buch{Title="Mein erstes Buch",Author=new string[]{"Michael","Josef"},Price=200},
                new Buch{Title="Das zweite Buch",Author=new string[]{"Peter"},Price=123},
                new Buch{Title="Küchen ABC",Author=new string[]{"Ana","Michael"},Price=250},
            };

            // Liste aller Autoren

            var result8 = bücher.Select(x => x.Author) // Array von Arrays
                                .ToArray();

            var result9 = bücher.SelectMany(x => x.Author) // Alle Arrays zusammenfassen
                                .ToArray();

            var result10 = bücher.SelectMany(x => x.Author) // Alle zusammenfassen aber ohne Doppelte
                                 .Distinct()
                                 .ToArray();

            // https://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b

            // Übungen:
            // Liste von Personen über 50 Jahre und positivem Kontostand
            // Die reichste Person unter 30
            // Die ärmsten 3 Personen
            // Die Gesamtsumme aller Schulden
            // Den Durchschnittskontostand aller Personen unter 50
            // Durchschnittsalter aller Personen mit Schulden


            Console.WriteLine("---ANFANG---");
            Console.ReadKey();
        }

        private static bool FilterFunktion(Person x) => x.Kontostand < 0;
        //{
            //if (x.Kontostand < 0)
            //    return true;
            //else
            //    return false;

            //return x.Kontostand < 0;
        //}

        private static string SelektorFunktion (Person x) => x.Vorname;
        //{
        //    return input.Vorname;
        //}

        public int Add(int z1, int z2) => z1 + z2;
        //{
        //    return z1 + z2;
        //}
    }
}
