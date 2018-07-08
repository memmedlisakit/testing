using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace DrivingSchoolApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var surname = textBox2.Text;
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+getPath()+@"App_Data\Database1.mdf;Integrated Security=True";

            SqlConnection con = new SqlConnection(connection);
            string sql = "INSERT INTO [Table](name, surname) VALUES('" + name + "', '" + surname + "')";

            SqlCommand com = new SqlCommand(sql, con);
            con.Open();
            int effected = com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(effected + "");

        }


        public string getPath()
        {
            string path = Application.StartupPath;

            List<string> splited = Regex.Split(path, "bin").ToList();

            return splited[0];

        }

    }
}
