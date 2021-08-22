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
    public partial class Form_Enter : Form
    {
        public Form_Enter()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-IP4RS08;Initial Catalog=EmployeeDatabase;Integrated Security=True");
        private void btn_enter_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From Table_Enter where UserName= @p1 and Password=@p2", connection);
            command.Parameters.AddWithValue("@p1", txt_name.Text);
            command.Parameters.AddWithValue("@p2", txt_password.Text);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect user name or password!");
            }

            connection.Close();
        }
    }
}
