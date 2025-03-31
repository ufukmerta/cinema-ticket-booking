using System;
using System.Windows.Forms;
using WFACinemaTicketBooking.Data;
using System.Linq;
using WFACinemaTicketBooking.Models;

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
        //User types: u, a, s. u is an user. a is an admin. s is a ticket seller.
        //if isAuthorized sets true, the user can access everywhere but admin forms.
        //the user can book or cancel booked tickets of customers.
        //to access admin panels, user's auth must be a.
        //Register form only registers users. So, admin user and ticket seller user need to be register on database or
        //user's auth needs to set a for admin and s for ticket seller.
        private void btn_Login_Click(object sender, EventArgs e)
        {
            using (MovieTicketBookingContext dbContext = new())
            {
                User user = dbContext.Users.Where(x => x.Email == txt_Email.Text && x.Password == txt_Password.Text).FirstOrDefault();
                if (user != null)
                {
                    string userName = user.Name + " " + user.Surname;
                    bool isAuthorized = false;
                    char authorization = Convert.ToChar(user.Auth);
                    if (authorization == 'a' || authorization == 's')//a is the admin user, s is the ticket seller user.
                        isAuthorized = true;
                    if (authorization == 'u' || authorization == 's')//u is the normal user.
                    {
                        formMain formMain = new formMain();
                        formMain.userID = Convert.ToInt32(user.UserId);
                        formMain.userName = userName.Trim();
                        formMain.isAuthorized = isAuthorized;
                        this.Hide();
                        formMain.ShowDialog();
                        this.Close();
                    }
                    if (authorization == 'a')
                    {
                        formAdmin formAdmin = new formAdmin();
                        this.Hide();
                        formAdmin.ShowDialog();
                        this.Close();
                    }
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Email or password is incorrect");
                }
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

        private void formLogin_Load(object sender, EventArgs e)
        {
            
        }
    }
}
