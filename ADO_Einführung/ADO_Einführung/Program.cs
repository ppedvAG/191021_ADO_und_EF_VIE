using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Provider für ADO.NET:
// using System.Data

using System.Data.SqlClient;
using System.Configuration;

namespace ADO_Einführung
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hallo Datenbank");

            // Verbindung zu einer DB aufbauen

            // Connectionstrings:
            // https://www.connectionstrings.com/

            // Northwind-DB aufbauen:
            // https://raw.githubusercontent.com/microsoft/sql-server-samples/master/samples/databases/northwind-pubs/instnwnd.sql

            // ConnectionString für TN-PCs
            // string connectionString = @"Server=.;Database=Northwind;Trusted_Connection=True;";
            // string connectionStringAlt = @"Data Source=.;Inital Catalog=Northwind;Integrated Security=true";
            // ConnectionString für Trainer-PC:
            //string connectionString = @"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=True;";
            string connectionString = "defaultConnection";

            // ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            // var firstString = settings[1];

            // Verschlüsseln:
            // https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/connection-strings-and-configuration-files
            // System.Configuration

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSection section = config.GetSection("connectionStrings");
            section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            config.Save(); // Ab hier verschlüsselt !

            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            var firstString = settings[1];

            // Variante 1)
            #region Variante 1 ohne using
            //var con = new SqlConnection(connectionString);

            //con.Open();
            //Console.WriteLine("Yeah !");

            //var command = new SqlCommand();
            //command.Connection = con;
            //command.CommandText = "SELECT count(*) FROM Employees";

            //// command.ExecuteNonQuery // <--- Befehl absetzen, ohne Ergebnis (z.B. Stored Proc, INSERT usw...)
            //// command.ExecuteReader // <--- Mehrere Ergebnisse
            //int result = (int)command.ExecuteScalar(); // <--- Ein einzelnes Feld/Ergebnis

            //Console.WriteLine($"Es gibt {result} Employees in der DB");
            //con.Close(); // Verbindung wieder schließen
            #endregion
            // Variante 2)

            using (var con = new SqlConnection(firstString.ConnectionString))
            {
                con.Open();
                // Alternativer Aufbau eines Commands:
                using(var command = con.CreateCommand()) // Setzt das Connection-Property automatisch
                {
                    command.CommandText = "SELECT * FROM Employees";
                    var reader = command.ExecuteReader();
                    List<Employee> employees = new List<Employee>();
                    while(reader.Read())
                    {
                        // DTO -> Data Transfer Object
                        Employee emp = new Employee();
                        emp.ID = reader.GetInt32(reader.GetOrdinal("EmployeeID")); // GetOrdinal ermittelt die Spaltennummer aus dem Namen
                        emp.FirstName = (string)reader["FirstName"]; // Mit Indexer auf die Spalte direkt zugreifen
                        emp.LastName = reader.GetString(1);
                        emp.BirthDate = reader.GetDateTime(5);
                        emp.HireDate = reader.GetDateTime(reader.GetOrdinal("HireDate"));

                        employees.Add(emp);
                        Console.WriteLine($"Name: {emp.LastName}\tBirth:{emp.BirthDate:d}\tHire:{emp.HireDate:d}");
                    }
                    reader.Close();
                    // Man könnte hier zb mit der Liste weiterarbeiten
                }

                // Übung:
                // In der Konsole kann man einen Nachnamen eingeben
                // -> Alle Personen, die den Nachnamen haben
                // Beispiel:
                // >"Bitte geben Sie den Suchbegriff ein:"
                // >D
                // > --- Alle Personen, deren Nachname mit D anfängt

                using (var command = con.CreateCommand())
                {
                    Console.WriteLine("Bitte geben Sie den Nachnamen ein:");
                    string suchtext = Console.ReadLine();

                    command.CommandText = $"SELECT * FROM Employees WHERE LastName Like @suche+'%'";
                    command.Parameters.AddWithValue("@suche", suchtext);

                    
                    var reader = command.ExecuteReader();
                    
                    // SQLInjection mit : 'D%'; Create Database HACKED --
                    // oder:                 0; Create Database HACKED --

                    while (reader.Read())
                    {
                        // DTO -> Data Transfer Object
                        var firstName = (string)reader["FirstName"]; // Mit Indexer auf die Spalte direkt zugreifen
                        var lastName = (string)reader["LastName"];
                        var birthDate = (DateTime)reader["BirthDate"];

                        Console.WriteLine($"Name: {firstName} {lastName}\tBirth:{birthDate:d}");
                    }
                }

            } // con.Close();



            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
