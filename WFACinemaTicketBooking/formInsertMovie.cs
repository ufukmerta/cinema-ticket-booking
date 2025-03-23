using System.Windows.Forms;
using WFACinemaTicketBooking.Data;
using System.Linq;
using WFACinemaTicketBooking.Models;
using System;
using System.Collections.Generic;

namespace WFACinemaTicketBooking
{
    public partial class formInsertMovie : Form
    {
        public formInsertMovie()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, System.EventArgs e)
        {
            using (MovieTicketBookingContext dbContext = new())
            {
                dbContext.Directors.AttachRange(chosenDirectors);
                dbContext.Genres.AttachRange(chosenGenres);
                Movie movie = new()
                {
                    Name = txt_Movie.Text,
                    Directors = chosenDirectors,
                    Genres = chosenGenres,
                    ImageUrl = txt_ImgUrl.Text,
                    Description = rTxt_Description.Text,
                };
                dbContext.Movies.Add(movie);
                int c = dbContext.SaveChanges();
                c -= chosenDirectors.Count + chosenGenres.Count;
                if (c == 1)
                {
                    MessageBox.Show("Movie inserted succesfully!");
                    txt_Movie.Text = "";
                    chosenDirectors.Clear();
                    txt_Director.Text = "";
                    chosenGenres.Clear();
                    txt_Genre.Text = "";
                    txt_ImgUrl.Text = "";
                    rTxt_Description.Text = "";
                }
            }
        }
        List<Director> chosenDirectors;
        private void btn_ChooseDirectors_Click(object sender, EventArgs e)
        {
            using (formMultiChoiceEntity formMultiChoiceEntity = new())
            {
                txt_Director.Text = "";
                formMultiChoiceEntity.director = true;
                formMultiChoiceEntity.Text = "Choose Directors";
                formMultiChoiceEntity.btn_PassChosenEntities.Text = "Pass the Chosen Director(s)";
                formMultiChoiceEntity.ShowDialog();
                chosenDirectors = formMultiChoiceEntity.chosenDirectors;
                if (chosenDirectors != null)
                {
                    chosenDirectors.ToList().ForEach(x => { txt_Director.Text += x.Name + ", "; });
                    txt_Director.Text = txt_Director.Text[..^2];
                }
            }
        }
        List<Genre> chosenGenres;
        private void btn_ChooseGenres_Click(object sender, EventArgs e)
        {
            using (formMultiChoiceEntity formMultiChoiceEntity = new())
            {
                txt_Genre.Text = "";
                formMultiChoiceEntity.genre = true;
                formMultiChoiceEntity.Text = "Choose Genres";
                formMultiChoiceEntity.btn_PassChosenEntities.Text = "Pass the Chosen Genre(s)";
                formMultiChoiceEntity.ShowDialog();
                chosenGenres = formMultiChoiceEntity.chosenGenres;
                if (chosenGenres != null)
                {
                    chosenGenres.ToList().ForEach(x => { txt_Genre.Text += x.Name + ", "; });
                    txt_Genre.Text = txt_Genre.Text[..^2];
                }
            }
        }
    }
}