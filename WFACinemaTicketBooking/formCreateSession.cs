using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WFACinemaTicketBooking.Data;
using WFACinemaTicketBooking.Models;

namespace WFACinemaTicketBooking
{
    public partial class formCreateSession : Form
    {
        public formCreateSession()
        {
            InitializeComponent();
        }
        string date;
        private void formCreateSession_Load(object sender, EventArgs e)
        {
            cb_Movie.SelectedIndex = -1;
            cb_Hall.Items.Clear();
            getAllSession();
            getMovies();
            dtp.MinDate = DateTime.Today;
            dtp.MaxDate = (DateTime.Today.AddDays(14));
        }

        private void getAllSession()
        {
            MovieTicketBookingContext dbContext = new MovieTicketBookingContext();
            var sessions = dbContext.Sessions.ToList();
            dgv_Sessions.DataSource = sessions;
        }
        void getMovies()
        {
            MovieTicketBookingContext dbContext = new MovieTicketBookingContext();
            var movies = dbContext.Movies.ToList();
            cb_Movie.DataSource = movies;
            cb_Movie.DisplayMember = "Name";
            cb_Movie.ValueMember = "MovieId";
            cleanSessionState();
            getHall();

        }

        bool firstOpen = true;
        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            if (firstOpen)
            {
                firstOpen = false;
            }
            cleanSessionState();
            getHall();
        }
        void cleanSessionState()
        {
            getAllSession();
        }
        void getHall()
        {
            if (firstOpen)
            {
                return;
            }
            date = dtp.Value.ToString("yyyy-MM-dd");           
            int count = 0;
            using (MovieTicketBookingContext dbContext = new())
            {
                count = dbContext.Halls.Where(x => x.MovieSessions.Any(x => x.MovieId == (int)cb_Movie.SelectedValue && x.Date == DateOnly.FromDateTime(dtp.Value))).Count();
            }
            if (count == 0)
            {
                using (MovieTicketBookingContext dbContext = new())
                {
                    var halls = dbContext.Halls.Where(x => x.MovieSessions.Any(x => x.Date != DateOnly.FromDateTime(dtp.Value))).OrderBy(x => x.Name).ToList();
                    cb_Hall.DataSource = halls;
                    cb_Hall.DisplayMember = "Name";
                    cb_Hall.ValueMember = "HallId";
                }
            }
            else
            {
                using (MovieTicketBookingContext dbContext = new())
                {
                    var halls = dbContext.Halls.Where(x =>
                        x.MovieSessions.Any(x => x.MovieId == (int)cb_Movie.SelectedValue && x.Date == DateOnly.FromDateTime(dtp.Value)) ||
                        x.MovieSessions.Any(x => x.Date != DateOnly.FromDateTime(dtp.Value)))
                        .OrderBy(x => x.Name).ToList();
                    cb_Hall.DataSource = halls;
                    cb_Hall.DisplayMember = "Name";
                    cb_Hall.ValueMember = "HallId";
                }
            }
            if (count != 0) getMovieSession();
        }
        void getMovieSession()
        {            
            using (MovieTicketBookingContext dbContext = new())
            {
                date = dtp.Value.ToString("yyyy-MM-dd");
                var movieSession = dbContext.MovieSessions.Where(x => x.MovieId == (int)cb_Movie.SelectedValue && x.Date == DateOnly.FromDateTime(dtp.Value)).ToList();
                var sessions = dbContext.Sessions.Where(x => x.MovieSessions.Any(x => x.MovieId == (int)cb_Movie.SelectedValue && x.Date == DateOnly.FromDateTime(dtp.Value))).ToList();
                if (sessions.Count >= 1)
                {
                    foreach (DataGridViewRow row in dgv_Sessions.Rows)
                    {
                        if (sessions.Any(x => x.Hour == row.Cells[2].Value.ToString()))
                        {
                            row.Cells[0].Value = true;
                            if (dbContext.MovieSessions.Where(x => x.Session.Hour == row.Cells[2].Value.ToString()).Count() != 0)
                            {
                                row.Cells[0].ReadOnly = true;
                                row.Cells[0].ToolTipText = "This session has at least one booking. The session cannot be canceled.";
                            }
                        }
                    }
                }                
            }
        }
        private void cb_Movie_SelectedValueChanged(object sender, EventArgs e)
        {
            cleanSessionState();
            getHall();
        }
        private void btn_InsertSessions_Click(object sender, EventArgs e)
        {
            bool sessionError = false;
            getMovieSession();//to make sure that the session is updated
            date = (dtp.Value).ToString("yyyy-MM-dd");
            foreach (DataGridViewRow row in dgv_Sessions.Rows)
            {
                //pass the session if it is already exist
                if ((bool)row.Cells[0].Value == true)
                {
                    int sessionID = Convert.ToInt32(row.Cells[1].Value);
                    using (MovieTicketBookingContext dbContext = new())
                    {
                        dbContext.MovieSessions.Add(new MovieSession
                        {
                            MovieId = (int)cb_Movie.SelectedValue,
                            HallId = (int)cb_Hall.SelectedValue,
                            Date = DateOnly.FromDateTime(dtp.Value),
                            SessionId = sessionID
                        });
                        dbContext.SaveChanges();
                    }
                }
                else
                {
                    if ((bool)row.Cells[0].Value == true)
                    {
                        int sessionID = Convert.ToInt32(row.Cells[1].Value); ;
                        using (MovieTicketBookingContext dbContext = new())
                        {
                            var ticketBookings = dbContext.TicketBookings.Where(x =>
                            x.MovieSession.MovieId == Convert.ToInt32(cb_Movie.SelectedValue) &&
                            x.MovieSession.HallId == Convert.ToInt32(cb_Hall.SelectedValue) &&
                            x.MovieSession.SessionId == sessionID &&
                            x.MovieSession.Date == DateOnly.FromDateTime(dtp.Value)).ToList();
                            if (ticketBookings.Count > 0)
                            {
                                MessageBox.Show("For " + cb_Movie.SelectedText + " movie, " +
                                    "" + date + " date, " +
                                    "" + row.Cells[2].Value.ToString() + "hour, at least there is one booking. The Session cannot be canceled.");
                                continue;
                            }
                            else
                            {
                                var movieSession = dbContext.MovieSessions.Where(x => x.MovieSessionId ==
                                ticketBookings.FirstOrDefault().MovieSessionId).FirstOrDefault();
                                dbContext.MovieSessions.Remove(movieSession);
                                int c = dbContext.SaveChanges();
                                if (c == 1)
                                {
                                    MessageBox.Show("For " + cb_Movie.Text + " movie, " +
                                    "" + date + " date, " +
                                    "" + row.Cells[2].Value.ToString() + " hour, the session is canceled.");
                                }
                            }
                        }
                    }
                }
                if (sessionError) MessageBox.Show("Not all selected session created. Created ones are selected.");
                else MessageBox.Show("All sessions are created.");
            }            
        }

        private void cb_Hall_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_Hall.SelectedValue == null)
            {
                return;
            }
            getMovieSession();
        }
    }
}
