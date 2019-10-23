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
            context.PersonSet.Add(new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 });
            context.PersonSet.Add(new Person { Vorname = "Anna", Nachname = "Nass", Alter = 20, Kontostand = 200 });
            context.PersonSet.Add(new Person { Vorname = "Peter", Nachname = "Silie", Alter = 30, Kontostand = 3000 });
            context.PersonSet.Add(new Person { Vorname = "Franz", Nachname = "Ose", Alter = 40, Kontostand = -400 });
            context.PersonSet.Add(new Person { Vorname = "Martha", Nachname = "Pfahl", Alter = 50, Kontostand = 500000 });
            context.PersonSet.Add(new Person { Vorname = "Klara", Nachname = "Fall", Alter = 60, Kontostand = 6666 });
            context.PersonSet.Add(new Person { Vorname = "Albert", Nachname = "Tross", Alter = 70, Kontostand = 1234567 });
            context.PersonSet.Add(new Person { Vorname = "Anna", Nachname = "Bolika", Alter = 80, Kontostand = 987653 });
            context.PersonSet.Add(new Person { Vorname = "Bill", Nachname = "Dung", Alter = 90, Kontostand = 326423234235234 });
            context.PersonSet.Add(new Person { Vorname = "Axel", Nachname = "Schweiß", Alter = 100, Kontostand = -12312313100 });

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

            var query = context.PersonSet;

            MessageBox.Show(query.ToString());
            myDataGrid.ItemsSource = query.ToArray(); // Befehl ausführen
        }


    }
}
