using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Sql;
using System.Data.Common;
using System.Data.SqlClient;
using Npgsql;

namespace ADO_Unabhängig
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = null;
            DbProviderFactory factory = null;

            Console.WriteLine("Welches DB-System wollen Sie verwenden ? SQL(1) oder PostgreSQL(2)");
            char input = Console.ReadKey().KeyChar;
            if(input == '1')
            {
                Console.WriteLine("Es wurde SQL gewählt:");
                connectionString = @"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=True;";
                factory = SqlClientFactory.Instance;
            }
            else
            {
                Console.WriteLine("Es wurde PostgreSQL gewählt:");
                connectionString = @"Host=localhost;Username=postgres;Password=12345678;Database=postgres";
                factory = NpgsqlFactory.Instance;
            }

            using(var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    Console.WriteLine("Bitte geben Sie den Nachnamen ein:");
                    string suchtext = Console.ReadLine();

                    if (input == '1')
                        command.CommandText = $"SELECT * FROM Employees WHERE LastName LIKE @suche";
                    else
                        command.CommandText = $"SELECT * FROM information_schema.\"Employees\" WHERE \"LastName\" LIKE @suche";
                    // command.Parameters.AddWithValue("@suche", suchtext); /// <--- Geht leider nicht :(

                    // Lange Fassung
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@suche";
                    parameter.Value = suchtext + "%";
                    command.Parameters.Add(parameter);

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var firstName = (string)reader["FirstName"]; // Mit Indexer auf die Spalte direkt zugreifen
                        var lastName = (string)reader["LastName"];
                        var birthDate = (DateTime)reader["BirthDate"];

                        Console.WriteLine($"Name: {firstName} {lastName}\tBirth:{birthDate:d}");
                    }
                    reader.Close();
                }
            }


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
