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

namespace Hallo_CodeFirst
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
        EFContext context;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context = new EFContext();
        }

        private void Laden_Click(object sender, RoutedEventArgs e)
        {
            myDataGrid.ItemsSource = context.Buch.ToList();
        }

        private void DemoDaten_Click(object sender, RoutedEventArgs e)
        {
            context.Buch.Add(new Buch { Titel = "Mein kleiner Garten", Autor = "Peter Silie", Seiten = 33, Preis = 35m });
            context.Buch.Add(new Buch { Titel = "Reiseführer Paris", Autor = "Franz Ose", Seiten = 120, Preis = 15.90m });
            context.Buch.Add(new Buch { Titel = "Kindererziehung leicht gemacht", Autor = "Bill Dung", Seiten = 2800, Preis = 248.40m });
            context.Buch.Add(new Buch { Titel = "Frauen verstehen Band 3 von 293", Autor = "Anna Bolika", Seiten = 800, Preis = 9.99m });
            context.Buch.Add(new Buch { Titel = "Vogelkunde", Autor = "Albert Tross", Seiten = 50, Preis = 19m });

            context.Buchgeschäft.Add(new Buchgeschäft { Name = "Thalia", Adresse = "Thaliastraße 100" });
            context.Buchgeschäft.Add(new Buchgeschäft { Name = "Morawa", Adresse = "SCS 123456" });
            context.Buchgeschäft.Add(new Buchgeschäft { Name = "Tante Emmas Bücherkiste", Adresse = "Daham 12" });

            context.SaveChanges();
        }


    }
}
