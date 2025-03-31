using System;
using System.Linq;
using System.Windows.Forms;
using WFACinemaTicketBooking.Data;
using WFACinemaTicketBooking.Models;

namespace WFACinemaTicketBooking
{
    public partial class formRegister : Form
    {
        public formRegister()
        {
            InitializeComponent();
        }
        internal bool isRegistered = false;

        private void btn_Register_Click(object sender, EventArgs e)
        {
            txt_PhoneNumber.Text = txt_PhoneNumber.Text.Replace("+", "");
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
            using (MovieTicketBookingContext dbContext = new())
            {
                int count = dbContext.Users.Where(x => x.PhoneNumber == txt_PhoneNumber.Text || x.Email == txt_Email.Text).Count();
                if (count != 0)
                {
                    MessageBox.Show("Typed phone number or email adress is already registered.");
                    return;
                }
            }
            using (MovieTicketBookingContext dbContext = new())
            {
                User user = new User
                {
                    Name = txt_Name.Text,
                    Surname = txt_Surname.Text,
                    Profession = txt_Profession.Text,
                    PhoneNumber = txt_PhoneNumber.Text,
                    Email = txt_Email.Text,
                    Password = txt_Password.Text
                };
                dbContext.Users.Add(user);                
                if (dbContext.SaveChanges() == 1)
                {
                    MessageBox.Show("You registered succesfully!");
                    isRegistered = true;
                }                
                Close();
            }
        }
    }
}