using Microsoft.EntityFrameworkCore;
using ppedv.ProjectAli.Data.EF;
using ppedv.ProjectAli.Domain;
using ppedv.ProjectAli.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ppedv.ProjectAli.UI.WPF
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
            core = new Core(new EFRepository());
            comboBoxFlugzeug.ItemsSource = core.GetAllAircraft();
        }
        private Core core;
        private ObservableCollection<AircraftType> loadedAircrafts = new ObservableCollection<AircraftType>();
        private ObservableCollection<Airport> loadedAirports = new ObservableCollection<Airport>();
        private Type currentlyLoadedType;

        private void LadeFlugzeuge_Click(object sender, RoutedEventArgs e)
        {
            loadedAircrafts.Clear();
            foreach (var item in core.GetAllAircraft())
            {
                loadedAircrafts.Add(item);
            }
            myDataGrid.ItemsSource = loadedAircrafts;
            currentlyLoadedType = typeof(AircraftType);
        }

        private void LadeFlughäfen_Click(object sender, RoutedEventArgs e)
        {
            loadedAirports.Clear();
            foreach (var item in core.GetAllAirports())
            {
                loadedAirports.Add(item);
            }
            myDataGrid.ItemsSource = loadedAirports;
            currentlyLoadedType = typeof(Airport);

        }

        private void LadeFlughäfenFürSelektiertesFlugzeug(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxFlugzeug.SelectedItem == null)
                return;
            myDataGrid.ItemsSource = core.GetAllAirportsFor((AircraftType)comboBoxFlugzeug.SelectedItem);
        }



        private void LöscheFlugzeug_Click(object sender, RoutedEventArgs e)
        {

        }

        private void myDataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            if (currentlyLoadedType == typeof(AircraftType))
            {
                var newAircraft = new AircraftType
                {
                    Code = string.Empty,
                    Model = string.Empty,
                    Manufacturer = string.Empty,
                    WTC = WTC.L,
                    CreationDate = DateTime.Now
                };
                e.NewItem = newAircraft;

                core.Repository.Add(newAircraft);
            }
            else if (currentlyLoadedType == typeof(Airport))
            {
                var newAirport = new Airport
                {
                    LocInt = string.Empty,
                    Decode = string.Empty,
                    Iata = string.Empty,
                    CreationDate = DateTime.Now
                };
                e.NewItem = newAirport;

                core.Repository.Add(newAirport);
            }
            else
            {
                throw new InvalidOperationException("Das Hinzufügen von neuen Items wird für diesen Datentypen nicht unterstützt");
            }

            core.Repository.Save();
        }

        private void myDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            // ----- Hack -----
            // Wenn man nur Repository.Save() aufruft, wird der "letzte" Zustang gespeichert, die neuen Daten sind dann noch nicht in der DB
            // Lösung: UI-Thread das Hinzufügen der Objekte beenden lassen und danach (2 sek später) erst in die DB Updaten
            // Grund: RowEditEnding hat die Daten noch nicht "Commited" -> Sind nicht für den EF-Changetracker sichtbar und somit "Keine neue Änderung"
            
            Task.Run(async () =>
            {
               await Task.Delay(2000);
                try
                {
                    core.Repository.Save();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    
                    // User-Dialog: "Wollen Sie DB-Version oder Meine-Version ?
                    // Msgbox 
                    // -> Auswahl speichern
                    // -> Datagrid wieder aktualisieren

                    throw;
                }
            });

            //// ToDo: dasda testen:
            //myDataGrid.CommitEdit();
            //core.Repository.Save();
        }
    }
}
