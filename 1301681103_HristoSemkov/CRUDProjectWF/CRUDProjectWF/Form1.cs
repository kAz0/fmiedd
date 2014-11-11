using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CRUDProjectWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Users.mdb");
            conn.Open();
            string username = tbUsername.Text;
            string passwrod = tbPassword.Text;
            string email = tbEmail.Text;
            OleDbCommand aCommand = new OleDbCommand("INSERT INTO Users (username,`password`,email) VALUES ('" + username + "','" + passwrod + "','" + email + "')", conn);
            aCommand.ExecuteNonQuery();
            conn.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbEmail.Clear();
            tbPassword.Clear();
            tbUsername.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
