using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EmployeeRecordProgram
{
    public partial class Form_Graphs : Form
    {
        public Form_Graphs()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-IP4RS08;Initial Catalog=EmployeeDatabase;Integrated Security=True");
        private void Form_Graphs_Load(object sender, EventArgs e)
        {
            //Graph1
            connection.Open();
            SqlCommand commandg1 = new SqlCommand("Select EmployeeCity,Count(*) From Table_Employee Group By EmployeeCity", connection);
            SqlDataReader dr1 = commandg1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Cities"].Points.AddXY(dr1[0], dr1[1]);
            }
            connection.Close();

            //Graph2
            connection.Open();
            SqlCommand commandg2 = new SqlCommand("Select EmployeeJob,Avg(EmployeeSalary) From Table_Employee Group By EmployeeJob", connection);
            SqlDataReader dr2 = commandg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Job-Salary"].Points.AddXY(dr2[0], dr2[1]);

            }
            connection.Close();
        }
    }
}
