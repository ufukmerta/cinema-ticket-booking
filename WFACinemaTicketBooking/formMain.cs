﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WFACinemaTicketBooking
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }
        internal int userID = 0;
        internal string userName = "";
        internal string password = "";
        string strDate = "";
        internal bool adminPanel = false;
        internal bool isAuthorized = false;

        SqlConnection connection = new SqlConnection(@"Data Source =(LocalDB)\MSSQLLocalDB;Initial Catalog=MovieTicketBookingDB;AttachDBFilename=|DataDirectory|\App_Data\MovieTicketBookingDB.mdf;Integrated Security = True;");
        void connect()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            else
            {
                connection.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (adminPanel)
            {
                btn_OpenBooking.Text = "Show/Edit Bookings";
            }
        }

        private void cb_Movie_Click(object sender, EventArgs e)
        {
            btn_MovieDetails.Visible = true;
            cb_Date.Items.Clear();
            cb_Date.Text = null;
            cb_Hall.DataSource = null;
            cb_Session.DataSource = null;
            connect();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_Movie where movieID in(select movieID from tbl_MovieSession)", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cb_Movie.DataSource = dt;
            cb_Movie.DisplayMember = "name";
            cb_Movie.ValueMember = "movieID";
            connect();
        }

        private void cb_Date_Click(object sender, EventArgs e)
        {
            if (cb_Movie.SelectedIndex != -1)
            {
                cb_Date.Items.Clear();
                cb_Hall.SelectedIndex = -1;
                cb_Hall.DataSource = null;
                cb_Session.SelectedIndex = -1;
                cb_Session.DataSource = null;
                connect();
                SqlCommand cmd = new SqlCommand("select date from tbl_MovieSession where movieID=@movieID group by date", connection);
                cmd.Parameters.AddWithValue("@movieID", cb_Movie.SelectedValue);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    strDate = Convert.ToDateTime(dr["date"]).ToString("yyyy-MM-dd");
                    cb_Date.Items.Add(strDate.ToString());
                }
                if (cb_Date.Items.Count >= 0)
                {
                    cb_Date.SelectedIndex = 0;
                }
                connect();
            }
            else
            {
                MessageBox.Show("Please choose the movie!");
            }
        }

        private void cb_Hall_Click(object sender, EventArgs e)
        {
            if (cb_Movie.SelectedIndex != -1 && cb_Date.SelectedIndex != -1)
            {
                cb_Session.SelectedIndex = -1;
                cb_Session.DataSource = null;
                connect();
                SqlCommand cmd = new SqlCommand("select * from tbl_Hall where hallID " +
                    "IN(select hallID from tbl_MovieSession where movieID=@movieID and date=@date)", connection);
                cmd.Parameters.AddWithValue("@movieID", cb_Movie.SelectedValue);
                cmd.Parameters.AddWithValue("@date", cb_Date.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cb_Hall.DataSource = dt;
                cb_Hall.DisplayMember = "name";
                cb_Hall.ValueMember = "hallID";
                connect();
            }
            else
            {
                MessageBox.Show("Please choose the movie and date!");
            }
        }

        private void cb_Session_Click(object sender, EventArgs e)
        {
            if (cb_Movie.SelectedIndex != -1 && cb_Hall.SelectedIndex != -1 && cb_Date.SelectedIndex != -1)
            {
                connect();

                SqlCommand cmd = new SqlCommand("select * from tbl_Session where sessionID IN " +
                    "(select sessionID from tbl_MovieSession where movieID=@movieID and hallID=@hallID and date=@date)", connection);
                cmd.Parameters.AddWithValue("@movieID", cb_Movie.SelectedValue);
                cmd.Parameters.AddWithValue("@hallID", cb_Hall.SelectedValue);
                cmd.Parameters.AddWithValue("@date", cb_Date.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cb_Session.DataSource = dt;
                cb_Session.DisplayMember = "hour";
                cb_Session.ValueMember = "sessionID";
                connect();
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
            this.Hide();
            if (adminPanel)
            {
                formBookingAdmin formBookingAdmin = new formBookingAdmin();
                formBookingAdmin.movieID = Convert.ToInt32(cb_Movie.SelectedValue);
                formBookingAdmin.date = cb_Date.Text;
                formBookingAdmin.hallID = Convert.ToInt32(cb_Hall.SelectedValue);
                formBookingAdmin.sessionID = Convert.ToInt32(cb_Session.SelectedValue);
                formBookingAdmin.ShowDialog();
            }
            else
            {
                formBooking formBooking = new formBooking();
                formBooking.movieID = Convert.ToInt32(cb_Movie.SelectedValue);
                formBooking.date = cb_Date.Text;
                formBooking.hallID = Convert.ToInt32(cb_Hall.SelectedValue);
                formBooking.sessionID = Convert.ToInt32(cb_Session.SelectedValue);
                formBooking.userID = userID;
                formBooking.userName = userName;
                formBooking.isAuthorized = isAuthorized;
                formBooking.ShowDialog();
            }
            this.Show();

        }

        private void btn_MovieDetails_Click(object sender, EventArgs e)
        {
            if (cb_Movie.SelectedIndex != -1)
            {
                connect();
                SqlCommand cmd = new SqlCommand("select name, director, genre, description from tbl_Movie" +
                    " INNER JOIN tbl_MovieGenre ON tbl_Movie.genreID=tbl_MovieGenre.genreID where movieID=@movieID", connection);
                cmd.Parameters.AddWithValue("movieID", cb_Movie.SelectedValue);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Director: " + dr["director"] + "\nGenre: " + dr["genre"] + "\n" + dr["description"],
                        dr["name"] + " Movie Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                connect();
            }
        }
    }
}