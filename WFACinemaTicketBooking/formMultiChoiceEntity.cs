using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WFACinemaTicketBooking.Data;
using WFACinemaTicketBooking.Models;

namespace WFACinemaTicketBooking
{
    public partial class formMultiChoiceEntity : Form
    {
        static DataGridViewColumn[] SetDgvDirectorChoices()
        {
            DataGridViewCheckBoxColumn cb_choice = new()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
                HeaderText = "Choosen",
                Name = "cb_Director",
                Width = 60
            };
            DataGridViewTextBoxColumn director_id = new()
            {
                DataPropertyName = "DirectorId",
                HeaderText = "Director ID",
                Name = "director_id",
                ReadOnly = true,
                Visible = false
            };
            DataGridViewTextBoxColumn director_name = new()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "Name",
                HeaderText = "Director Name",
                Name = "director_name",
                ReadOnly = true
            };

            DataGridViewColumn[] columns =
            [
              cb_choice,
              director_id,
              director_name,
            ];
            return columns;
        }
        static DataGridViewColumn[] SetDgvGenreChoices()
        {
            DataGridViewCheckBoxColumn cb_choice = new()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
                HeaderText = "Choosen",
                Name = "cb_Genre",
                Width = 60
            };
            DataGridViewTextBoxColumn genre_id = new()
            {
                DataPropertyName = "GenreId",
                HeaderText = "Genre ID",
                Name = "genre_id",
                ReadOnly = true,
                Visible = false
            };
            DataGridViewTextBoxColumn genre_name = new()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "Name",
                HeaderText = "Genre Name",
                Name = "genre_name",
                ReadOnly = true
            };

            DataGridViewColumn[] columns =
            [
              cb_choice,
              genre_id,
              genre_name,
            ];
            return columns;
        }
        internal List<Genre> chosenGenres;
        internal List<Director> chosenDirectors;
        internal bool genre = false;
        internal bool director = false;
        public formMultiChoiceEntity()
        {
            InitializeComponent();
        }
        internal bool passEntities = false;
        internal string txt = "";
        private void btn_PassChosenEntities_Click(object sender, EventArgs e)
        {
            passEntities = true;
            if (genre)
            {
                chosenGenres = new List<Genre>();
                using (MovieTicketBookingContext dbContext = new())
                {
                    foreach (DataGridViewRow row in dgv_Choices.Rows)
                    {
                        if (row.Cells[0].Value == null)
                        {
                            continue;
                        }
                        if ((bool)row.Cells[0].Value == true)
                        {
                            Genre genre = dbContext.Genres.Find(Convert.ToInt32(row.Cells[1].Value));
                            chosenGenres.Add(genre);
                        }
                    }
                }
            }
            else if (director)
            {
                chosenDirectors = new List<Director>();
                using (MovieTicketBookingContext dbContext = new())
                {
                    foreach (DataGridViewRow row in dgv_Choices.Rows)
                    {
                        if (row.Cells[0].Value == null)
                        {
                            continue;
                        }
                        if ((bool)row.Cells[0].Value == true)
                        {
                            Director director = dbContext.Directors.Find(Convert.ToInt32(row.Cells[1].Value));
                            
                            chosenDirectors.Add(director);
                        }
                    }
                }
            }
            Close();
        }

        private void formMultiChoiceEntity_Load(object sender, EventArgs e)
        {
            if (genre)
            {
                DataGridViewColumn[] columns = SetDgvGenreChoices();
                dgv_Choices.Columns.AddRange([columns[0], columns[1], columns[2]]);
                using (MovieTicketBookingContext dbContext = new())
                {
                    var genres = dbContext.Genres.Select(x => new { x.GenreId, x.Name }).OrderBy(x => x.Name).ToList();
                    dgv_Choices.DataSource = genres;
                }
            }
            else if (director)
            {
                DataGridViewColumn[] columns = SetDgvDirectorChoices();
                dgv_Choices.Columns.AddRange([columns[0], columns[1], columns[2]]);
                using (MovieTicketBookingContext dbContext = new())
                {
                    var directors = dbContext.Directors.Select(x => new { x.DirectorId, x.Name }).OrderBy(x => x.Name).ToList();
                    dgv_Choices.DataSource = directors;
                }
            }
            else
            {
                Close();
            }
        }
    }
}
