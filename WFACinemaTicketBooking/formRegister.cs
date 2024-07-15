using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WFACinemaTicketBooking
{
    public partial class formRegister : Form
    {
        public formRegister()
        {
            InitializeComponent();
        }
        internal bool isRegistered = false;

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionStr"].ToString());
        private void btn_Register_Click(object sender, EventArgs e)
        {
            txt_PhoneNumber.Text = txt_PhoneNumber.Text.Replace("+9", "");
            if (!txt_PhoneNumber.Text.All(char.IsNumber) || txt_PhoneNumber.Text == "")
            {
                MessageBox.Show("Invalid phone number");
                return;
            }
            if (txt_Name.Text == "" || txt_Surname.Text == "" || txt_Profession.Text == "" || txt_Email.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("Please fill all the blanks.");
                return;
            }

            string sql1 = "SELECT COUNT(*) FROM tbl_User WHERE phoneNumber=@phoneNumber OR email=@email";
            SqlCommand cmdControl = new SqlCommand(sql1, connection);
            cmdControl.Parameters.AddWithValue("@phoneNumber", txt_PhoneNumber.Text);
            cmdControl.Parameters.AddWithValue("@email", txt_Email.Text);
            connection.Open();
            if ((int)cmdControl.ExecuteScalar() != 0)
            {
                MessageBox.Show("Typed phone number or email adress is already registered.");
                connection.Close();
                return;
            }
            connection.Close();
            connection.Open();
            string sql2 = "insert into tbl_User(name, surname, profession, phoneNumber, email, password, authorization) " +
                "values(@name, @surname, @profession, @phoneNumber, @email, @password, 'u')";
            SqlCommand cmd = new SqlCommand(sql2, connection);
            cmd.Parameters.AddWithValue("@name", txt_Name.Text);
            cmd.Parameters.AddWithValue("@surname", txt_Surname.Text);
            cmd.Parameters.AddWithValue("@profession", txt_Profession.Text);
            cmd.Parameters.AddWithValue("@phoneNumber", txt_PhoneNumber.Text);
            cmd.Parameters.AddWithValue("@email", txt_Email.Text);
            cmd.Parameters.AddWithValue("@password", txt_Password.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("You registered succesfully!");
                isRegistered = true;
            }
            connection.Close();
            this.Close();
        }

    }
}