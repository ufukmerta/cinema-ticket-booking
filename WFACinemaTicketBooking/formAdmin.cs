using System;
using System.Windows.Forms;

namespace WFACinemaTicketBooking
{
    public partial class formAdmin : Form
    {
        public formAdmin()
        {
            InitializeComponent();
        }

        private void btn_Booking_Click(object sender, EventArgs e)
        {
            formMain formMain = new formMain();
            formMain.adminPanel = false;
            formMain.isAuthorized = true;
            this.Hide();
            formMain.ShowDialog();
            this.Show();
        }
        private void btn_CreateSession_Click(object sender, EventArgs e)
        {
            formCreateSession formCreateSession = new formCreateSession();
            this.Hide();
            formCreateSession.ShowDialog();
            this.Show();
        }

        private void btn_InsertMovie_Click(object sender, EventArgs e)
        {
            formInsertMovie formInsertMovie = new formInsertMovie();
            this.Hide();
            formInsertMovie.ShowDialog();
            this.Show();
        }
        private void btn_BookingAdmin_Click(object sender, EventArgs e)
        {
            formMain formMain = new formMain();
            formMain.adminPanel = true;
            this.Hide();
            formMain.ShowDialog();
            this.Show();
        }
    }
}
