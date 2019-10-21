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

            var con = new SqlConnection(connectionString);

            con.Open();
            Console.WriteLine("Yeah !");

            var command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "SELECT count(*) FROM Employees";

            // command.ExecuteNonQuery // <--- Befehl absetzen, ohne Ergebnis (z.B. Stored Proc, INSERT usw...)
            // command.ExecuteReader // <--- Mehrere Ergebnisse
            int result = (int)command.ExecuteScalar(); // <--- Ein einzelnes Feld/Ergebnis

            Console.WriteLine($"Es gibt {result} Employees in der DB");


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
