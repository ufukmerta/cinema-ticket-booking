using System;
using System.Windows.Forms;
using WFACinemaTicketBooking.Data;
using System.Linq;
using WFACinemaTicketBooking.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace WFACinemaTicketBooking
{
    public partial class formMovieDetail : Form
    {
        public formMovieDetail()
        {
            InitializeComponent();
        }
        internal int movieID = -1;
        private void formMovieDetail_Load(object sender, EventArgs e)
        {
            Movie movie = new();
            using (MovieTicketBookingContext dbContext = new())
            {
                movie = dbContext.Movies.Include(x => x.Genres).Include(x => x.Directors).FirstOrDefault(m => m.MovieId == movieID);
                if (movie == null)
                {
                    MessageBox.Show("Cannot find movie details", "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }
                else
                {
                    lbl_MovieName.Text += movie.Name;
                    lbl_Detail.Text += movie.Description;
                    pcBox_Movie.LoadAsync(movie.ImageUrl);
                    if (movie.Genres != null)
                    {
                        foreach (var genre in movie.Genres)
                        {
                            lbl_Genre.Text += genre.Name + " ,";
                        }
                        lbl_Genre.Text = lbl_Genre.Text[..^1];
                    }
                    if (movie.Directors != null)
                    {
                        foreach (var director in movie.Directors)
                        {
                            lbl_Director.Text += director.Name + " ,";
                        }
                        lbl_Director.Text = lbl_Director.Text[..^1];
                    }
                }
            }
        }

        private void formMovieDetail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void formMovieDetail_SizeChanged(object sender, EventArgs e)
        {
            Size = new Size(Size.Width, Size.Width / 2);
        }
    }
}
