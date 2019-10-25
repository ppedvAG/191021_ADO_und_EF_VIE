using System;

namespace EFCodeFirstDatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");
            // PM> Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=ProjectAli_Test;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir ModelsProjectAli
            // PM> Scaffold-DbContext "Host=localhost;Username=postgres;Password=12345678;Database=northwind" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Northwind5

        }
    }
}
