using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;

namespace WFACinemaTicketBooking
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void txt_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login.PerformClick();
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {            
            SqlConnection connection = new SqlConnection(@"Data Source =(LocalDB)\MSSQLLocalDB;Initial Catalog=MovieTicketBookingDB;AttachDBFilename=|DataDirectory|\App_Data\MovieTicketBookingDB.mdf;Integrated Security = True;");
            connection.Open();
            string sql = "select userID, name, surname, isAuthorized from tbl_User where email=@email and password=@password";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@email", txt_Email.Text);
            cmd.Parameters.AddWithValue("@password", txt_Password.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string userName = dr[1].ToString() + " " + dr[2].ToString();
                bool isAuthorized = dr[3] != DBNull.Value && (bool)dr[3];
                if (userName == "admin ")
                {
                    formAdmin formAdmin = new formAdmin();
                    this.Hide();
                    formAdmin.ShowDialog();
                    this.Close();
                }
                else
                {
                    formMain formMain = new formMain();
                    formMain.userID = Convert.ToInt32(dr[0]);
                    formMain.userName = userName.Trim();
                    formMain.isAuthorized = isAuthorized;
                    this.Hide();
                    formMain.ShowDialog();
                    this.Close();
                }
                Application.Exit();

            }
            else
            {
                MessageBox.Show("Email or password is incorrect");
            }
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            formRegister formRegister = new formRegister();
            this.Hide();
            formRegister.ShowDialog();
            if (formRegister.isRegistered)
            {
                txt_Email.Text = formRegister.txt_Email.Text;
                txt_Password.Text = formRegister.txt_Password.Text;
            }
            this.Show();
        }
    }
}
