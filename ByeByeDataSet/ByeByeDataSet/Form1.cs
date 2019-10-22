using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ByeByeDataSet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void employeesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.meinDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'meinDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.meinDataSet.Employees);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            employeesTableAdapter.ClearBeforeFill = true;

            this.employeesTableAdapter.InsertMaxMustermann();
            this.employeesTableAdapter.Fill(this.meinDataSet.Employees);

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.meinDataSet.Employees.Rows[2][2] = "LALALA";
            // Werte in die DB updaten:
            employeesTableAdapter.Update(this.meinDataSet.Employees);
        }
    }
}
