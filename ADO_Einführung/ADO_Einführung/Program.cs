using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Provider für ADO.NET:
// using System.Data

using System.Data.SqlClient;

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
            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=True;";

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

            using(var con = new SqlConnection(connectionString))
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
                    // Man könnte hier zb mit der Liste weiterarbeiten
                }

            } // con.Close();



            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
