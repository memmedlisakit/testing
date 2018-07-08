using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; 
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Data.Sql;

namespace DrivingSchoolApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string connection  = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+getPath()+ @"App_Data\Database1.mdf;Integrated Security=True";
        //string connection = "Data Source="+getPath()+@"App_Data\SqlDB.db;Version=3;";

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var surname = textBox2.Text;

            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string sql = "INSERT INTO [Table](name, surname) VALUES('" + name + "', '" + surname + "')";

            SqlCommand com = new SqlCommand(sql, con);
            int effected = com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(effected + "");
            this.fillAll();
        }


        public static string getPath()
        {
            string path = Application.StartupPath;

            List<string> splited = Regex.Split(path, "bin").ToList();

            return splited[0];

        }


        public void fillAll()
        {
            this.textBox3.Text = "";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM [Table]";
            SqlConnection con = new SqlConnection(connection);
            SqlCommand com = new SqlCommand(sql, con);
            da.SelectCommand = com;
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                this.textBox3.Text += item["name"] + " -- " + item["surname"] + "\r\n";
            }
        }

    }
}
