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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-IP4RS08;Initial Catalog=EmployeeDatabase;Integrated Security=True");

        void clear()
        {
            textBox_ID.Text = " ";
            textBox_Name.Text = " ";
            textBox_Surname.Text = " ";
            textBox_Job.Text = " ";
            maskedTextBox_Salary.Text = " ";
            comboBox_City.Text = " ";
            radioButton_Married.Checked = false;
            radioButton_Single.Checked = false;
            textBox_Name.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'employeeDatabaseDataSet.Table_Employee' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.table_EmployeeTableAdapter.Fill(this.employeeDatabaseDataSet.Table_Employee);
            txt_ID.Focus();
        }

        private void btn_record_Click(object sender, EventArgs e)
        {
            connection.Open();

            SqlCommand command1 = new SqlCommand("insert into Table_Employee(EmployeeName,EmployeeSurname,EmployeeCity,EmployeeSalary,EmployeeJob,EmployeeSituation)values (@p1,@p2,@p3,@p4,@p5,@p6)", connection);
            command1.Parameters.AddWithValue("@p1", textBox_Name.Text);
            command1.Parameters.AddWithValue("@p2", textBox_Surname.Text);
            command1.Parameters.AddWithValue("@p3", comboBox_City.Text);
            command1.Parameters.AddWithValue("@p4", maskedTextBox_Salary.Text);
            command1.Parameters.AddWithValue("@p5", textBox_Job.Text);
            command1.Parameters.AddWithValue("@p6", label1.Text);
            command1.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Employee Added");
        }

        private void btn_lists_Click(object sender, EventArgs e)
        {
            this.table_EmployeeTableAdapter.Fill(this.employeeDatabaseDataSet.Table_Employee);
        }

        private void radioButton_Single_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton_Single.Checked == true)
            {
                label1.Text = "True";
            }
            
        }

        private void radioButton_Married_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton_Married.Checked == true)
            {
                label1.Text = "False";
            }
            
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;

            textBox_ID.Text = dataGridView1.Rows[selected].Cells[0].Value.ToString();
            textBox_Name.Text = dataGridView1.Rows[selected].Cells[1].Value.ToString();
            textBox_Surname.Text = dataGridView1.Rows[selected].Cells[2].Value.ToString();
            comboBox_City.Text = dataGridView1.Rows[selected].Cells[3].Value.ToString();
            maskedTextBox_Salary.Text = dataGridView1.Rows[selected].Cells[4].Value.ToString();
            label1.Text = dataGridView1.Rows[selected].Cells[5].Value.ToString();
            textBox_Job.Text = dataGridView1.Rows[selected].Cells[6].Value.ToString();
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            if(label1.Text == "True")
            {
                radioButton_Single.Checked = true;
            }
            else
            {
                radioButton_Married.Checked = true;
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand commandelete = new SqlCommand("Delete From Table_Employee Where EmployeeID = @k1", connection);
            commandelete.Parameters.AddWithValue("@k1", textBox_ID.Text);
            commandelete.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Record is deleted");
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand commandupdate = new SqlCommand("Update Table_Employee Set EmployeeName = @a1,EmployeeSurname = @a2,EmployeeCity = @a3,EmployeeSalary = @a4,EmployeeSituation = @a5,EmployeeJob = @a6 where EmployeeID = @a7", connection);
            commandupdate.Parameters.AddWithValue("@a1", textBox_Name.Text);
            commandupdate.Parameters.AddWithValue("@a2", textBox_Surname.Text);
            commandupdate.Parameters.AddWithValue("@a3", comboBox_City.Text);
            commandupdate.Parameters.AddWithValue("@a4", maskedTextBox_Salary.Text);
            commandupdate.Parameters.AddWithValue("@a5", label1.Text);
            commandupdate.Parameters.AddWithValue("@a6", textBox_Job.Text);
            commandupdate.Parameters.AddWithValue("@a7", textBox_ID.Text);
            commandupdate.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Recording update.");

        }

        private void btn_statistics_Click(object sender, EventArgs e)
        {
            FormStatistics fr = new FormStatistics();
            fr.Show();
        }

        private void btn_graphs_Click(object sender, EventArgs e)
        {
            Form_Graphs frg = new Form_Graphs();
            frg.Show();
        }
    }
}
