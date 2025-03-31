using System;
using System.Data;
using System.Windows.Forms;
using WFACinemaTicketBooking.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Collections.Generic;
using WFACinemaTicketBooking.Models;

namespace WFACinemaTicketBooking
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }
        internal int userID = -1;
        internal string userName = "";
        internal string password = "";
        internal bool adminPanel = false;
        internal bool isAuthorized = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            if (adminPanel)
            {
                btn_OpenBooking.Text = "Show/Edit Bookings";
            }
            getMovies();
        }

        private void cb_Movie_Click(object sender, EventArgs e)
        {
            getMovies();
        }

        private void getMovies()
        {
            btn_MovieDetails.Visible = true;
            cb_Date.DataSource = null;
            cb_Hall.DataSource = null;
            cb_Session.DataSource = null;
            using (MovieTicketBookingContext dbContext = new())
            {
                var movies = dbContext.Movies
                    .Where(x => x.MovieSessions.Any(x => x.Date.CompareTo(DateOnly.FromDateTime(DateTime.Now.Date)) > 0))
                    .ToList();
                var moviesofToday = dbContext.MovieSessions.Include(ms => ms.Movie)
                    .Where(x => x.Date.CompareTo(DateOnly.FromDateTime(DateTime.Now.Date)) == 0)
                    .ToList();
                //cannot translate into LINQ Query if moviesofToday's and moviesofTodayList's where conditions are used together on the moviesofToday
                List<MovieSession> moviesofTodayList = moviesofToday
                    .Where(x => DateTime.ParseExact(x.Session.Hour, "HH:mm", CultureInfo.InvariantCulture) > DateTime.Now)
                    .ToList();
                if (movies.Count == 0 && moviesofTodayList.Count == 0)
                {
                    MessageBox.Show("No movies are showcasing for now!");
                }
                else if (movies.Count != 0 && moviesofTodayList.Count != 0)
                {
                    var allMovies = movies.Concat(moviesofTodayList.Select(x => x.Movie)).ToList();
                    cb_Movie.DataSource = allMovies;
                    cb_Movie.DisplayMember = "Name";
                    cb_Movie.ValueMember = "MovieId";
                }
                else if (movies.Count != 0 && moviesofTodayList.Count == 0)
                {
                    cb_Movie.DataSource = movies;
                    cb_Movie.DisplayMember = "Name";
                    cb_Movie.ValueMember = "MovieId";
                }
                else if (movies.Count == 0 && moviesofTodayList.Count != 0)
                {
                    cb_Movie.DataSource = moviesofToday;
                    cb_Movie.DisplayMember = "Name";
                    cb_Movie.ValueMember = "MovieId";
                }
                if (cb_Movie.Items.Count == 0)
                {
                    btn_MovieDetails.Visible = false;
                }
            }
        }

        private void cb_Date_Click(object sender, EventArgs e)
        {
            getDates();
        }

        private void getDates()
        {
            if (cb_Movie.SelectedIndex != -1)
            {
                cb_Date.DataSource = null;
                cb_Hall.DataSource = null;
                cb_Session.DataSource = null;
                using (MovieTicketBookingContext dbContext = new())
                {
                    var datesExcludeToday = dbContext.MovieSessions
                        .Where(x => x.Date.CompareTo(DateOnly.FromDateTime(DateTime.Now)) > 0)
                        .Where(x => x.MovieId == (int)cb_Movie.SelectedValue)
                        .GroupBy(x => x.Date).ToList();
                    var sessionofToday = dbContext.MovieSessions.Include(ms => ms.Session)
                        .Where(x => x.Date.CompareTo(DateOnly.FromDateTime(DateTime.Now)) == 0)
                        .Where(x => x.MovieId == (int)cb_Movie.SelectedValue)
                        .ToList();
                    sessionofToday = sessionofToday
                        .Where(x => DateTime.ParseExact(x.Session.Hour, "HH:mm", CultureInfo.InvariantCulture) > DateTime.Now)
                        .ToList();
                    if (datesExcludeToday.Count == 0 && sessionofToday.Count == 0)
                    {
                        MessageBox.Show("This movie isn't showcasing for now! Trying to load available movies...");
                        getMovies();
                    }
                    else if (datesExcludeToday.Count != 0 && sessionofToday.Count != 0)
                    {
                        var allDates = datesExcludeToday.Concat(sessionofToday.GroupBy(x => x.Date));
                        cb_Date.DataSource = allDates.Select(d => d.Key.ToString("dd-MM-yyyy"));
                        cb_Date.DisplayMember = "Date";
                    }
                    else if (datesExcludeToday.Count != 0 && sessionofToday.Count == 0)
                    {
                        cb_Date.DataSource = datesExcludeToday.Select(d => d.Key.ToString("dd-MM-yyyy")).ToList();
                        cb_Date.Invalidate();
                    }
                    else if (datesExcludeToday.Count == 0 && sessionofToday.Count != 0)
                    {
                        cb_Date.DataSource = sessionofToday.GroupBy(x => x.Date).Select(d => d.Key.ToString("dd-MM-yyyy"));
                        cb_Date.DisplayMember = "Date";
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choose the movie!");
            }
        }

        private void cb_Hall_Click(object sender, EventArgs e)
        {
            getHalls();
        }

        private void getHalls()
        {
            if (cb_Movie.SelectedIndex != -1 && cb_Date.SelectedIndex != -1)
            {
                cb_Hall.DataSource = null;
                cb_Session.DataSource = null;
                using (MovieTicketBookingContext dbContext = new())
                {
                    if (DateTime.Parse(cb_Date.Text) == DateTime.Now.Date)
                    {
                        var sessionofToday = dbContext.MovieSessions.Include(ms => ms.Session)
                            .Where(x => x.Date.CompareTo(DateOnly.FromDateTime(DateTime.Now)) == 0)
                            .Where(x => x.MovieId == (int)cb_Movie.SelectedValue)
                            .ToList();
                        sessionofToday = sessionofToday
                            .Where(x => DateTime.ParseExact(x.Session.Hour, "HH:mm", CultureInfo.InvariantCulture) > DateTime.Now)
                            .ToList();
                        if (sessionofToday.Count > 0)
                        {
                            cb_Hall.DataSource = sessionofToday.Select(x => x.Hall);
                            cb_Hall.DisplayMember = "Name";
                            cb_Hall.ValueMember = "HallId";
                        }
                        else
                        {
                            MessageBox.Show("This movie isn't showcasing for chosen date! Trying to load different dates...");
                            getDates();
                        }
                    }
                    else
                    {
                        var halls = dbContext.Halls
                            .Where(x => x.MovieSessions.Any(x => x.MovieId == (int)cb_Movie.SelectedValue && x.Date == DateOnly.Parse(cb_Date.Text)))
                            .ToList();
                        if (halls.Count > 0)
                        {
                            cb_Hall.DataSource = halls;
                            cb_Hall.DisplayMember = "Name";
                            cb_Hall.ValueMember = "HallId";
                        }
                        else
                        {
                            MessageBox.Show("This movie isn't showcasing for chosen date! Trying to load different dates...");
                            getDates();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choose the movie and date!");
            }
        }

        private void cb_Session_Click(object sender, EventArgs e)
        {
            getSessions();
        }

        private void getSessions()
        {
            if (cb_Movie.SelectedIndex != -1 && cb_Hall.SelectedIndex != -1 && cb_Date.SelectedIndex != -1)
            {
                cb_Session.DataSource = null;
                using (MovieTicketBookingContext dbContext = new())
                {
                    var sessions = dbContext.Sessions
                        .Where(x =>
                            x.MovieSessions.Any(x =>
                                x.MovieId == (int)cb_Movie.SelectedValue &&
                                x.HallId == (int)cb_Hall.SelectedValue &&
                                x.Date == DateOnly.Parse(cb_Date.Text)))
                        .ToList();
                    if (DateTime.Parse(cb_Date.Text) == DateTime.Now.Date)
                    {
                        sessions = sessions
                            .Where(x => DateTime.ParseExact(x.Hour, "HH:mm", CultureInfo.InvariantCulture) > DateTime.Now)
                            .ToList();
                        if (sessions.Count() > 0)
                        {
                            cb_Session.DataSource = sessions.Select(x => new { x.Hour, x.SessionId }).ToList();
                            cb_Session.DisplayMember = "Hour";
                            cb_Session.ValueMember = "SessionId";
                        }
                        else
                        {
                            MessageBox.Show("This movie isn't showcasing at this hall! Trying to load available halls...");
                            getHalls();
                        }
                    }
                    else
                    {
                        if (sessions.Count > 0)
                        {
                            cb_Session.DataSource = sessions;
                            cb_Session.DisplayMember = "Hour";
                            cb_Session.ValueMember = "SessionId";
                        }
                        else
                        {
                            MessageBox.Show("This movie isn't showcasing at this hall! Trying to load available halls...");
                            getHalls();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choose the movie, date and hall!");
            }
        }

        private void btn_OpenBooking_Click(object sender, EventArgs e)
        {
            if (cb_Movie.SelectedIndex == -1 || cb_Hall.SelectedIndex == -1 || cb_Date.Text == "" || cb_Session.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose the movie, date, hall and session!");
                return;
            }
            Hide();
            if (adminPanel)
            {
                using (formBookingAdmin formBookingAdmin = new()
                {
                    movieID = Convert.ToInt32(cb_Movie.SelectedValue),
                    date = cb_Date.Text,
                    hallID = Convert.ToInt32(cb_Hall.SelectedValue),
                    sessionID = Convert.ToInt32(cb_Session.SelectedValue)
                })
                {
                    formBookingAdmin.ShowDialog();
                    if (formBookingAdmin.movieSessionID == -1)
                    {
                        getMovies();
                    }
                }
            }
            else
            {
                using (formBooking formBooking = new()
                {
                    movieID = Convert.ToInt32(cb_Movie.SelectedValue),
                    date = cb_Date.Text,
                    hallID = Convert.ToInt32(cb_Hall.SelectedValue),
                    sessionID = Convert.ToInt32(cb_Session.SelectedValue),
                    userID = userID,
                    userName = userName,
                    isAuthorized = isAuthorized,
                })
                {
                    formBooking.ShowDialog();
                    if (formBooking.movieSessionID==-1)
                    {
                        getMovies();
                    }
                }
            }
            Show();

        }

        private void btn_MovieDetails_Click(object sender, EventArgs e)
        {
            if (cb_Movie.SelectedIndex != -1)
            {
                using (formMovieDetail formMovieDetail = new formMovieDetail())
                {
                    formMovieDetail.movieID = Convert.ToInt32(cb_Movie.SelectedValue);
                    formMovieDetail.ShowDialog();
                }
            }
        }
    }
}
