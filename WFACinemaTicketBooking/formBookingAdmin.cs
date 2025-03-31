using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using ToolTip = System.Windows.Forms.ToolTip;
using WFACinemaTicketBooking.Data;
using System.Linq;
using WFACinemaTicketBooking.Models;
using System.Globalization;


namespace WFACinemaTicketBooking
{
    public partial class formBookingAdmin : Form
    {
        public formBookingAdmin()
        {
            InitializeComponent();
        }
        private ArrayList cancelSeats = new();
        internal int movieID = -1;
        internal int hallID = -1;
        internal string date = "";
        private DateTime sessionTime;
        internal int sessionID = -1;
        internal int movieSessionID = -1;
        int hallCapacity = 60;

        int userID = -1;

        private void btn_Seat_Click(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.DarkRed)
            {
                ((Button)sender).BackColor = Color.LightCoral;
                cancelSeats.Remove(Convert.ToInt32(((Button)sender).Text));
                cancelSeats.Sort();
                listCancelSeats();
            }
            else if (((Button)sender).BackColor == Color.LightCoral)
            {
                ((Button)sender).BackColor = Color.DarkRed;
                cancelSeats.Add(Convert.ToInt32(((Button)sender).Text));
                cancelSeats.Sort();
                listCancelSeats();
            }
            else if (((Button)sender).BackColor == Color.Red)
            {
                if (txt_PhoneNumber.Text != ((Button)sender).Tag.ToString())
                {
                    cancelSeats.Clear();
                    txt_CancelSeatNo.Text = "";
                    txt_PhoneNumber.Text = ((Button)sender).Tag.ToString();
                    findCustomer();
                }
            }
        }
        void listCancelSeats()
        {
            txt_CancelSeatNo.Text = "";
            foreach (object seat in cancelSeats)
            {
                txt_CancelSeatNo.Text += seat + ", ";
            }
            if (cancelSeats.Count >= 1)
                txt_CancelSeatNo.Text = txt_CancelSeatNo.Text[..^2];
        }
        void findCustomer()
        {
            using (MovieTicketBookingContext dbContext = new())
            {
                var user = dbContext.Users.Where(x => x.PhoneNumber == txt_PhoneNumber.Text).FirstOrDefault();
                if (user != null)
                {
                    userID = user.UserId;
                    txt_UserName.Text = user.Name + " " + user.Surname;
                    btn_CancelTicket.Enabled = true;
                }
                else
                {
                    userID = -1;
                    MessageBox.Show("Customer cannot be found with given phone number!");
                    btn_CancelTicket.Enabled = false;
                }
            }
            getTicket();
        }

        private void FormBookingAdmin_Load(object sender, EventArgs e)
        {
            movieSessionID = getmovieSession();
            if (movieSessionID == -1)
            {
                MessageBox.Show("This movie session cannot be found.");
                Close();
            }
            getTicket();
        }

        private int getmovieSession()
        {
            int id = -1;
            using (MovieTicketBookingContext dbContext = new())
            {
                var movieSession = dbContext.MovieSessions
                    .Where(x => x.MovieId == movieID && x.HallId == hallID && x.Date == DateOnly.FromDateTime(DateTime.Parse(date)) && x.SessionId == sessionID)
                    .Select(x => new { x.MovieSessionId, MovieName = x.Movie.Name, HallName = x.Hall.Name, x.Hall.HallCapacity, x.Date, x.Session.Hour })
                    .FirstOrDefault();
                if (movieSession != null)
                {
                    id = movieSession.MovieSessionId;
                    lbl_MovieName.Text = movieSession.MovieName;
                    lbl_MovieSession.Text = movieSession.HallName + " / " + movieSession.Date + " / " + movieSession.Hour;
                    hallCapacity = movieSession.HallCapacity;
                    sessionTime = DateTime.ParseExact(movieSession.Date + " " + movieSession.Hour, "yyyy-MM-dd hh:mm", CultureInfo.InvariantCulture);
                }
            }
            return id;
        }

        ToolTip[] myToolTip = new ToolTip[60];
        private void getTicket()
        {
            for (int i = 1; i <= hallCapacity; i++)
            {
                Controls.Find("btn" + i, true)[0].BackColor = Color.Lime;
                Controls.Find("btn" + i, true)[0].Enabled = Enabled;
            }
            using (MovieTicketBookingContext dbContext = new())
            {
                var tickets = dbContext.TicketBookings
                    .Where(x => x.MovieSessionId == movieSessionID)
                    .ToList();
                int i = 0;
                foreach (var ticket in tickets)
                {
                    ToolTip tool = new ToolTip();
                    Button btn = (Button)Controls.Find("btn" + Convert.ToInt32(ticket.SeatNo), true)[0];
                    tool.SetToolTip(btn, ticket.User.Name + " " + ticket.User.Surname);
                    myToolTip[i++] = tool;
                    btn.Tag = ticket.User.PhoneNumber;
                    if (userID != Convert.ToInt32(ticket.User.UserId))
                    {
                        btn.BackColor = Color.Red;
                    }
                    else
                    {
                        btn.BackColor = Color.LightCoral;
                    }
                }
            }
            for (int j = hallCapacity + 1; j <= 60; j++)
            {
                Controls.Find("btn" + j, true)[0].BackColor = Color.Red;
                Controls.Find("btn" + j, true)[0].Enabled = false;
            }
        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            userID = -1;
            txt_UserName.Text = "";
            btn_CancelTicket.Enabled = false;
        }

        private void cancelTicket()
        {
            using (MovieTicketBookingContext dbContext = new())
            {
                for (int i = 0; i < cancelSeats.Count; i++)
                {
                    dbContext.TicketBookings.Remove(new TicketBooking
                    {
                        MovieSessionId = movieSessionID,
                        SeatNo = Convert.ToInt32(cancelSeats[i])
                    });
                    Controls.Find("btn" + cancelSeats[i].ToString(), true)[0].BackColor = Color.Lime;
                }
                int c = dbContext.SaveChanges();
                if (c == cancelSeats.Count)
                {
                    if (txt_CancelSeatNo.TextLength <= 2)
                        MessageBox.Show("Number " + txt_CancelSeatNo.Text + " seat of " + txt_UserName.Text + " customer's booked ticket is canceled.");
                    else if (txt_CancelSeatNo.TextLength > 2)
                        MessageBox.Show("Number " + txt_CancelSeatNo.Text + " seats of " + txt_UserName.Text + " customer's booked tickets are canceled.");
                }
                else
                {
                    MessageBox.Show("One or more booked ticket of customer couldn't be canceled successfully.");

                }
                cancelSeats.Clear();
            }
            getTicket();//make sure that the tickets are shown correctly because of the error(s) or another client edited the tickets 
        }

        private void btn_FindCustomer_Click(object sender, EventArgs e)
        {
            if (txt_PhoneNumber.Text != "")
            {
                findCustomer();
            }
        }

        private void btn_CancelTicket_Click(object sender, EventArgs e)
        {
            if (txt_CancelSeatNo.Text != "")
            {
                if (userID != -1)
                {
                    if (sessionTime <= DateTime.Now)
                    {
                        MessageBox.Show("This session is already passed. You cannot cancel a ticket for this session.");
                        movieSessionID = -1;
                        Close();
                    }
                    else
                    {
                        cancelTicket();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seat number isn't chosen!");
            }
        }
    }
}
