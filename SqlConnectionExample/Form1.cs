using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlConnectionExample
{
    public partial class Form1 : Form
    {
        SqlConnection connection;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection("Data Source=BABEGT;Initial Catalog=AdventureWorks2012;Integrated Security=True");

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            connection.Open();

            GetAllEmployee(string.Empty);
        }

        private void GetAllEmployee(string personelId)
        {
            var sql = "select * from Person.Person order by BusinessEntityID desc;";

            if (!string.IsNullOrEmpty(personelId))
            {
                sql = "select * from Person.Person where BusinessEntityId = "  + personelId + " order by BusinessEntityID desc";
            }

            
            SqlCommand sqlCommand = new SqlCommand(sql, connection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable table = new DataTable();

            sqlDataAdapter.Fill(table);

            dataGridPersonel.DataSource = table;
        }

        private void btnPersonelAra_Click(object sender, EventArgs e)
        {
            var personelId = txtPersonelId.Text;
            GetAllEmployee(personelId);

            //SqlCommand command = new SqlCommand("select FirstName, LastName from Person.Person where BusinessEntityID = " + personelId, connection);

            //SqlDataReader reader = command.ExecuteReader();

            //if (reader.Read())
            //{
            //    txtPersonelAdi.Text = reader["FirstName"].ToString();
            //    txtPersonelSoyadi.Text = reader.GetString(1);
            //}

            //reader.Close();
        }
    }
}
