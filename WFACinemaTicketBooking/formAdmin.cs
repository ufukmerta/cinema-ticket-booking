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
            using (formMain formMain = new()
            {
                adminPanel = false,
                isAuthorized = true
            })
            {
                Hide();
            formMain.ShowDialog();
                Show();
        }
        }

        private void btn_CreateSession_Click(object sender, EventArgs e)
        {
            using (formCreateSession formCreateSession = new())
            {
                Hide();
            formCreateSession.ShowDialog();
                Show();
        }
        }

        private void btn_InsertMovie_Click(object sender, EventArgs e)
        {
            using (formInsertMovie formInsertMovie = new())
            {
                Hide();
            formInsertMovie.ShowDialog();
                Show();
        }
        }

        private void btn_EditBookings_Click(object sender, EventArgs e)
        {
            using (formMain formMain = new()
            {
                adminPanel = true
            })
            {
                Hide();
            formMain.ShowDialog();
                Show();
            }
        }
    }
}