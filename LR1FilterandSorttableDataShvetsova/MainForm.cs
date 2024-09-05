using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using LR1FilterandSorttableDataShvetsova.DBContext;

namespace LR1FilterandSorttableDataShvetsova
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        Model1 model = new Model1();
        private void MainForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = model.Users.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAddUsers form = new FormAddUsers();
            form.ShowDialog();
            dataGridView1.DataSource = model.Users.ToList();
        }
    }
}
