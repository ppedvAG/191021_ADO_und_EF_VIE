using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hallo_EF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // EntityFramwork für Person
            context = new ModelFirst_Container();
        }
        private ModelFirst_Container context;


        private void DemoDaten_Click(object sender, RoutedEventArgs e)
        {
            //context.PersonSet.Add(new Mitarbeiter { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 });
            //context.PersonSet.Add(new Mitarbeiter { Vorname = "Anna", Nachname = "Nass", Alter = 20, Kontostand = 200 });
            //context.PersonSet.Add(new Mitarbeiter { Vorname = "Peter", Nachname = "Silie", Alter = 30, Kontostand = 3000 });
            //context.PersonSet.Add(new Mitarbeiter { Vorname = "Franz", Nachname = "Ose", Alter = 40, Kontostand = -400 });
            //context.PersonSet.Add(new Mitarbeiter { Vorname = "Martha", Nachname = "Pfahl", Alter = 50, Kontostand = 500000 });
            //context.PersonSet.Add(new Mitarbeiter { Vorname = "Klara", Nachname = "Fall", Alter = 60, Kontostand = 6666 });
            //context.PersonSet.Add(new Mitarbeiter { Vorname = "Albert", Nachname = "Tross", Alter = 70, Kontostand = 1234567 });
            //context.PersonSet.Add(new Mitarbeiter { Vorname = "Anna", Nachname = "Bolika", Alter = 80, Kontostand = 987653 });
            //context.PersonSet.Add(new Mitarbeiter { Vorname = "Bill", Nachname = "Dung", Alter = 90, Kontostand = 326423234235234 });
            //context.PersonSet.Add(new Mitarbeiter { Vorname = "Axel", Nachname = "Schweiß", Alter = 100, Kontostand = -12312313100 });

            Mitarbeiter d1 = new Mitarbeiter { Beruf="Genderbeauftragen", Vorname = "Peter", Nachname = "Silie", Alter = 30, Kontostand = 3000 };
            Mitarbeiter d2 = new Mitarbeiter { Beruf = "Raumlüfter", Vorname = "Albert", Nachname = "Tross", Alter = 70, Kontostand = 1234567 };

            Abteilung a1 = new Abteilung();
            a1.Bezeichnung = "HR";
            a1.Mitarbeiter.Add(new Mitarbeiter { Beruf = "Textilveredler", Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 });
            a1.Mitarbeiter.Add(new Mitarbeiter { Beruf = "Feel Good Manager", Vorname = "Anna", Nachname = "Nass", Alter = 20, Kontostand = 200 });
            a1.Mitarbeiter.Add(d1);

            Abteilung a2 = new Abteilung();
            a2.Bezeichnung = "Finance";
            a2.Mitarbeiter.Add(d1);
            a2.Mitarbeiter.Add(new Mitarbeiter { Beruf = "Controller", Vorname = "Martha", Nachname = "Pfahl", Alter = 50, Kontostand = 500000 });
            a2.Mitarbeiter.Add(new Mitarbeiter { Beruf = "Brieföffner", Vorname = "Klara", Nachname = "Fall", Alter = 60, Kontostand = 6666 });
            a2.Mitarbeiter.Add(d2);

            Abteilung a3 = new Abteilung();
            a3.Bezeichnung = "IT";
            a3.Mitarbeiter.Add(d2);
            a3.Mitarbeiter.Add(new Mitarbeiter { Beruf = "Programmierer", Vorname = "Anna", Nachname = "Bolika", Alter = 80, Kontostand = 987653 });
            a3.Mitarbeiter.Add(new Mitarbeiter { Beruf = "Datenbank-Admin", Vorname = "Bill", Nachname = "Dung", Alter = 90, Kontostand = 326423234235234 });
            a3.Mitarbeiter.Add(new Mitarbeiter { Beruf = "Datenträger", Vorname = "Axel", Nachname = "Schweiß", Alter = 100, Kontostand = -12312313100 });

            context.AbteilungSet.Add(a1);
            context.AbteilungSet.Add(a2);
            context.AbteilungSet.Add(a3);

            // Daten in der DB speichern:
            context.SaveChanges();
        }

        private void Löschen_Click(object sender, RoutedEventArgs e)
        {
            int id = ((Person)myDataGrid.SelectedItem).Id;
            var loadedItem = context.PersonSet.Find(id); // Ist es noch in der DB vorhanden
            if (loadedItem != null)
                context.PersonSet.Remove(loadedItem);

            // ToDo: Redraw DataGrid -> Laden() aufrufen
            Speichern_Click(sender, e);
            Laden_Click(sender, e);
        }

        private void Neu_Click(object sender, RoutedEventArgs e)
        {
            // Fassung ohne Changetracker
            Person p1 = new Person { Vorname = "Max", Nachname = "Mustermann" };
            context.PersonSet.Add(p1);

            // Fassung mit Changetracker
            Person p2 = context.PersonSet.Create();
        }

        private void Speichern_Click(object sender, RoutedEventArgs e)
        {
            // context.ChangeTracker.DetectChanges(); // Rollback

            context.SaveChanges(); // Änderungen Commiten
        }

        private void Laden_Click(object sender, RoutedEventArgs e)
        {
            //var query = context.PersonSet.Where(x => x.Kontostand > 0 && x.Vorname.StartsWith("A"))
            //                             .OrderByDescending(x => x.Alter);

            // Bei großen Listen: Stück für Stück nachladen
            // .Skip(meineListe.Count).Take(100); // <-- meineListe ist quasi der Cache
            var query = context.PersonSet;

            MessageBox.Show(query.ToString());
            var result =  query.ToArray(); // Befehl ausführen
            myDataGrid.ItemsSource = result;
        }

        private void myDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int id = 1; // Ohne laden: 1
            if(myDataGrid.ItemsSource != null) // Mit laden: gewähltes Element
                id = ((Person)myDataGrid.SelectedItem).Id;

            // var loadedItem = context.PersonSet.Find(id);             // Nimmt, wenn vorhanden, aus dem Cache
             var loadedItem = context.PersonSet.AsNoTracking() /// <-- KEIN CACHE !
                                               .First(x => x.Id == id);  // Macht mit dem Find somit 100%ig eine Abfrage an die DB

            MessageBox.Show($"{loadedItem.Vorname} {loadedItem.Nachname}");

            // Gewählter Datensatz im Datagrid anzeigen:
            myDataGrid.ItemsSource = new Person[] { loadedItem };
        }
    }
}
