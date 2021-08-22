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
    public partial class FormStatistics : Form
    {
        public FormStatistics()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-IP4RS08;Initial Catalog=EmployeeDatabase;Integrated Security=True");

        private void FormStatistics_Load(object sender, EventArgs e)
        {
            //total employee number
            connection.Open();
            SqlCommand command1 = new SqlCommand("Select Count(*) From Table_Employee ", connection);
            SqlDataReader dr1 = command1.ExecuteReader();
            while (dr1.Read())
            {
                lbl_totalemp.Text = dr1[0].ToString();
            }
            connection.Close();

            //married employee number
            connection.Open();
            SqlCommand command2 = new SqlCommand("Select Count(*) From Table_Employee where EmployeeSituation=1", connection);
            SqlDataReader dr2 = command2.ExecuteReader();
            while (dr2.Read())
            {
                lbl_married_employee.Text = dr2[0].ToString();
            }
            connection.Close();

            //single employee number
            connection.Open();
            SqlCommand command3 = new SqlCommand("Select Count(*) From Table_Employee where EmployeeSituation=0", connection);
            SqlDataReader dr3 = command3.ExecuteReader();
            while (dr3.Read())
            {
                lbl_single_employee.Text = dr3[0].ToString();
            }
            connection.Close();

            //different city number
            connection.Open();
            SqlCommand command4 = new SqlCommand("Select Count(distinct(EmployeeCity)) From Table_Employee", connection);
            SqlDataReader dr4 = command4.ExecuteReader();
            while (dr4.Read())
            {
                lbl_city_number.Text = dr4[0].ToString();
            }
            connection.Close();


            //total salary
            connection.Open();
            SqlCommand command5 = new SqlCommand("Select Sum(EmployeeSalary) From Table_Employee", connection);
            SqlDataReader dr5 = command5.ExecuteReader();
            while (dr5.Read())
            {
                lbl_total_salary.Text = dr5[0].ToString();

            }
            connection.Close();


            //average salary
            connection.Open();
            SqlCommand command6 = new SqlCommand("Select Avg(EmployeeSalary) From Table_Employee", connection);
            SqlDataReader dr6 = command6.ExecuteReader();
            while (dr6.Read())
            {
                lbl_average_salary.Text = dr6[0].ToString();
            }
            connection.Close();
        }



    }
}
