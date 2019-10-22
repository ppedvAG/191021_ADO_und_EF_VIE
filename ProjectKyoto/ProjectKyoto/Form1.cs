using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectKyoto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private DbConnection connection;
        private List<Customer> currentlyLodadedCustomers = new List<Customer>();

        private void RefreshDataGrid()
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT \"CustomerId\",\"CompanyName\",\"ContactName\",\"Phone\" FROM \"Customers\" WHERE \"CompanyName\" Like @suche";

                var parameter = command.CreateParameter();
                parameter.ParameterName = "@suche";
                parameter.Value = textBoxSuchtext.Text + "%";
                command.Parameters.Add(parameter);

                using (var reader = command.ExecuteReader())
                {
                    currentlyLodadedCustomers.Clear();
                    while (reader.Read())
                    {
                        Customer c = new Customer();

                        c.CustomerId = reader.GetString(reader.GetOrdinal("CustomerId"));
                        c.ContactName = (string)reader["ContactName"];
                        c.CompanyName = (string)reader["CompanyName"];
                        c.Phone = (string)reader["Phone"];

                        currentlyLodadedCustomers.Add(c);
                    }
                }
            }

            connection.Close();

            dataGridViewCustomers.DataSource = null;
            dataGridViewCustomers.Refresh();
            dataGridViewCustomers.DataSource = currentlyLodadedCustomers;
        }
        private void DeleteAllSelectedRowsFromDataGrid()
        {
            foreach (DataGridViewRow selectedRow in dataGridViewCustomers.SelectedRows)
            {
                Customer selectedCustomer = (Customer)selectedRow.DataBoundItem;
                DeleteCustomer(selectedCustomer);
            }
        }
        private void DeleteCustomer(Customer deleteMe)
        {

            connection.Open();
            // Alle Orders vom Customer X löschen:
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM \"Order Details\" WHERE \"OrderID\" in (SELECT \"OrderID\" FROM \"Orders\" WHERE \"CustomerID\" = @id)";

                var parameter = command.CreateParameter();
                parameter.ParameterName = "@id";
                parameter.Value = deleteMe.CustomerId;
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
            }

            // Alle Orders vom Customer X löschen:
            int deletedOrders = 0;
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM \"Orders\" WHERE \"CustomerID\" = @id";

                var parameter = command.CreateParameter();
                parameter.ParameterName = "@id";
                parameter.Value = deleteMe.CustomerId;
                command.Parameters.Add(parameter);

                deletedOrders = command.ExecuteNonQuery();
            }

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM \"Customers\" WHERE \"CustomerID\" = @id";

                var parameter = command.CreateParameter();
                parameter.ParameterName = "@id";
                parameter.Value = deleteMe.CustomerId;
                command.Parameters.Add(parameter);

                var deletedRows = command.ExecuteNonQuery();
                MessageBox.Show($"Es wurden {deletedRows} Einträge gelöscht mit insgesamt {deletedOrders} Orders");
            }
            connection.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void löschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count >= 1)
            {
                DeleteAllSelectedRowsFromDataGrid();
                RefreshDataGrid();
            }
        }
    }
}
