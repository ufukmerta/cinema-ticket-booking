using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace WFACinemaTicketBooking
{
    public partial class formMovieDetail : Form
    {
        public formMovieDetail()
        {
            InitializeComponent();
        }
        readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionStr"].ToString());
        internal int movieID = 0;
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
        private void formMovieDetail_Load(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("select name, description, imageUrl from tbl_Movie where movieID=@movieID", connection))
            {
                connect();
                cmd.Parameters.AddWithValue("@movieID", movieID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lbl_MovieName.Text += dr["name"];
                    lbl_Detail.Text += dr["description"];
                    pcBox_Movie.LoadAsync(dr["imageUrl"].ToString());
                }
                connect();
            }
            using (SqlCommand cmd = new SqlCommand("select genre from tbl_Genre left join tbl_MovieGenre on tbl_Genre.genreID=tbl_MovieGenre.genreID where tbl_MovieGenre.movieID=@movieID", connection))
            {
                connect();
                cmd.Parameters.AddWithValue("@movieID", movieID);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lbl_Genre.Text += dr["genre"] + " ,";
                }
                lbl_Genre.Text = lbl_Genre.Text.Substring(0, lbl_Genre.Text.Length - 1);
                connect();
            }
            using (SqlCommand cmd = new SqlCommand("select name from tbl_Director left join tbl_MovieDirector on tbl_Director.directorID=tbl_MovieDirector.directorID where tbl_MovieDirector.movieID=@movieID", connection))
            {
                connect();
                cmd.Parameters.AddWithValue("@movieID", movieID);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lbl_Director.Text += dr["name"] + " ,";
                }
                lbl_Director.Text = lbl_Director.Text.Substring(0, lbl_Director.Text.Length - 1);
                connect();
            }
        }

        private void formMovieDetail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
