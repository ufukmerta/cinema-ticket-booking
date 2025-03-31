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

        private void btn_BookTicket_Click(object sender, EventArgs e)
        {
            formMain formMain = new formMain
            {
                adminPanel = false,
                isAuthorized = true
            };
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

        private void btn_EditBookings_Click(object sender, EventArgs e)
        {
            formMain formMain = new formMain
            {
                adminPanel = true
            };
            this.Hide();
            formMain.ShowDialog();
            this.Show();
        }
    }
}