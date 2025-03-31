using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WFACinemaTicketBooking.Data;
using System.Linq;
using WFACinemaTicketBooking.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;


namespace WFACinemaTicketBooking
{
    public partial class formBooking : Form
    {
        public formBooking()
        {
            InitializeComponent();
        }
        private ArrayList seats = new();
        private ArrayList cancelSeats = new();
        internal int movieID = -1;
        internal int hallID = -1;
        internal string date = "";
        private DateTime sessionTime;
        internal int sessionID = -1;

        internal int userID = -1;
        internal string userName = "";
        internal bool isAuthorized = false;

        internal int movieSessionID = -1;
        int hallCapacity = 60;
        int price = 20;

        private void btn_Seat_Click(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.Lime)
            {
                ((Button)sender).BackColor = Color.Orange;
                seats.Add(Convert.ToInt32(((Button)sender).Text));
                seats.Sort();
                listChosenSeat(seats, txt_seatNo);

            }
            else if (((Button)sender).BackColor == Color.Orange)
            {
                ((Button)sender).BackColor = Color.Lime;
                seats.Remove(Convert.ToInt32(((Button)sender).Text));
                seats.Sort();
                listChosenSeat(seats, txt_seatNo);
            }
            else if (((Button)sender).BackColor == Color.DarkRed)
            {
                ((Button)sender).BackColor = Color.LightCoral;
                cancelSeats.Remove(Convert.ToInt32(((Button)sender).Text));
                cancelSeats.Sort();
                listChosenSeat(cancelSeats, txt_CancelSeatNo);
            }
            else if (((Button)sender).BackColor == Color.LightCoral)
            {
                ((Button)sender).BackColor = Color.DarkRed;
                cancelSeats.Add(Convert.ToInt32(((Button)sender).Text));
                cancelSeats.Sort();
                listChosenSeat(cancelSeats, txt_CancelSeatNo);
            }
        }
        void listChosenSeat(ArrayList seatArray, TextBox txtBox)
        {
            txtBox.Text = "";
            foreach (object seat in seatArray)
            {
                txtBox.Text += seat + ", ";
            }
            if (seatArray.Count >= 1)
                txtBox.Text = txtBox.Text[..^2];
        }

        private void formBooking_Load(object sender, EventArgs e)
        {
            if (!isAuthorized)
            {
                txt_UserName.Text = userName;
                txt_PhoneNumber.Visible = false;
                label11.Visible = false;
                btn_BookTicket.Enabled = true;
                btn_CancelTicket.Enabled = true;
                btn_FindCustomer.Visible = false;
            }
            movieSessionID = getmovieSession();
            if (movieSessionID == -1)
            {
                MessageBox.Show("We are sorry. This movie session cannot be found. Please try again or look at different session.");
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
                    .Select(x => new { x.MovieSessionId, MovieName = x.Movie.Name, HallName = x.Hall.Name, x.Hall.HallCapacity, x.Date, x.Session.Hour }).FirstOrDefault();
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
        private void getTicket()
        {
            for (int i = 1; i <= hallCapacity; i++)
            {
                Controls.Find("btn" + i, true)[0].BackColor = Color.Lime;
                Controls.Find("btn" + i, true)[0].Enabled = Enabled;
            }
            gb_CancelSeat.Visible = false;
            using (MovieTicketBookingContext dbContext = new())
            {
                var tickets = dbContext.TicketBookings.Include(x => x.User).Where(x =>
                x.MovieSessionId == movieSessionID).ToList();
                foreach (var ticket in tickets)
                {
                    ToolTip tool = new();
                    Button btn = (Button)Controls.Find("btn" + Convert.ToInt32(ticket.SeatNo), true)[0];
                    tool.SetToolTip(btn, ticket.User.Name + " " + ticket.User.Surname);
                    if (userID != Convert.ToInt32(ticket.User.UserId))
                    {
                        btn.BackColor = Color.Red;
                        Controls.Find("btn" + Convert.ToInt32(ticket.SeatNo), true)[0].Enabled = false;
                    }
                    else
                    {
                        Controls.Find("btn" + Convert.ToInt32(ticket.SeatNo), true)[0].BackColor = Color.LightCoral;
                        Controls.Find("btn" + Convert.ToInt32(ticket.SeatNo), true)[0].Enabled = Enabled;
                        gb_CancelSeat.Visible = true;
                    }
                }
            }
            for (int i = hallCapacity + 1; i <= 60; i++)
            {
                Controls.Find("btn" + i, true)[0].BackColor = Color.Red;
                Controls.Find("btn" + i, true)[0].Enabled = false;
            }
        }

        bool validityCheck(string chosenTicket)
        {
            if (chosenTicket != "")
            {
                if (userID != -1)
                {
                    if (sessionTime <= DateTime.Now)
                    {
                        MessageBox.Show("This session is already passed. You cannot book/cancel a ticket for this session.");
                        movieSessionID = -1;
                        Close();
                        return false;
                    }
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Seat number isn't chosen!");
            }
            return false;
        }

        private void btn_BookTicket_Click(object sender, EventArgs e)
        {
            if (validityCheck(txt_seatNo.Text))
            {
                bookTicket();
            }
        }

        void bookTicket()
        {
            using (MovieTicketBookingContext dbContext = new())
            {
                for (int i = 0; i < seats.Count; i++)
                {
                    dbContext.TicketBookings.Add(new TicketBooking
                    {
                        MovieSessionId = movieSessionID,
                        UserId = userID,
                        SeatNo = Convert.ToInt32(seats[i]),
                        Price = price
                    });
                    Controls.Find("btn" + seats[i].ToString(), true)[0].BackColor = Color.LightCoral;
                }
                int c = dbContext.SaveChanges();
                if (c == seats.Count)
                {
                    if (txt_seatNo.TextLength <= 2 && isAuthorized)
                        MessageBox.Show("Number " + txt_seatNo.Text + " seat is booked by " + txt_UserName.Text);
                    else if (txt_seatNo.TextLength > 2 && isAuthorized)
                        MessageBox.Show("Number " + txt_seatNo.Text + " seats are booked by " + txt_UserName.Text);
                    else if (txt_seatNo.TextLength <= 2 && !isAuthorized)
                        MessageBox.Show("You (" + txt_UserName.Text + ") booked number " + txt_seatNo.Text + " seat.");
                    else if (txt_seatNo.TextLength > 2 && !isAuthorized)
                        MessageBox.Show("You (" + txt_UserName.Text + ") booked number " + txt_seatNo.Text + " seats.");
                    seats.Clear();

                }
                else
                {
                    MessageBox.Show("One or more ticket(s) couldn't be booked successfully.");
                }
            }
            txt_seatNo.Text = "";
            getTicket();//make sure that the tickets are shown correctly because of the error(s) or another client edited the tickets.
        }

        private void txt_PhoneNumber_TextChanged(object sender, EventArgs e)
        {
            userID = -1;
            txt_UserName.Text = "";
            btn_BookTicket.Enabled = btn_CancelTicket.Enabled = false;
        }

        private void rb_TicketType_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Young.Checked == true)
                price = 16;
            else
                price = 20;
        }

        private void btn_FindCustomer_Click(object sender, EventArgs e)
        {
            if (txt_PhoneNumber.Text != "")
            {
                findCustomer();
            }
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
                    btn_BookTicket.Enabled = btn_CancelTicket.Enabled = true;
                }
                else
                {
                    userID = -1;
                    MessageBox.Show("Customer cannot be found with given phone number!");
                    btn_BookTicket.Enabled = btn_CancelTicket.Enabled = false;
                }
            }
            getTicket();
        }

        private void btn_CancelTicket_Click(object sender, EventArgs e)
        {
            if (validityCheck(txt_CancelSeatNo.Text))
            {
                cancelTicket();
            }
        }

        private void cancelTicket()
        {
            using (MovieTicketBookingContext dbContext = new())
            {
                for (int i = 0; i < cancelSeats.Count; i++)
                {
                    var ticket = dbContext.TicketBookings
                        .Where(x =>
                            x.SeatNo == Convert.ToInt32(cancelSeats[i]) &&
                            x.UserId == userID &&
                            x.MovieSessionId == movieSessionID)
                        .FirstOrDefault();
                    dbContext.TicketBookings.Remove(ticket);
                    Controls.Find("btn" + cancelSeats[i].ToString(), true)[0].BackColor = Color.Lime;
                }
                int c = dbContext.SaveChanges();
                if (c == cancelSeats.Count)
                {
                    if (txt_CancelSeatNo.TextLength <= 2 && isAuthorized)
                        MessageBox.Show("Number " + txt_CancelSeatNo.Text + " seat of " + txt_UserName.Text + " customer's booked ticket is canceled.");
                    else if (txt_CancelSeatNo.TextLength > 2 && isAuthorized)
                        MessageBox.Show("Number " + txt_CancelSeatNo.Text + " seats of " + txt_UserName.Text + " customer's booked tickets are canceled.");
                    else if (txt_CancelSeatNo.TextLength <= 2 && !isAuthorized)
                        MessageBox.Show("You (" + txt_UserName.Text + ") canceled your booked number " + txt_CancelSeatNo.Text + " seat.");
                    else if (txt_CancelSeatNo.TextLength > 2 && !isAuthorized)
                        MessageBox.Show("You (" + txt_UserName.Text + ") canceled your booked number " + txt_CancelSeatNo.Text + " seats.");
                }
                else
                {
                    MessageBox.Show("One or more booked ticket of customer couldn't be canceled successfully.");
                }
                cancelSeats.Clear();
                txt_CancelSeatNo.Text = "";
            }
            getTicket();//make sure that the tickets are shown correctly because of the error(s) or another client edited the tickets 
        }
    }
}
