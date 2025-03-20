using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace WFACinemaTicketBooking
{
    public partial class formInsertMovie : Form
    {
        public formInsertMovie()
        {
            InitializeComponent();
        }
        readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionStr"].ToString());
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

        private void formInsertMovie_Load(object sender, System.EventArgs e)
        {
            connect();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_MovieGenre", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cb_MovieGenre.DataSource = dt;
            cb_MovieGenre.DisplayMember = "genre";
            cb_MovieGenre.ValueMember = "genreID";
            connect();
        }

        private void btnInsert_Click(object sender, System.EventArgs e)
        {
            connect();
            SqlCommand cmd = new SqlCommand("insert into tbl_Movie(name, director, genreID, description,imageUrl) values(@name,@director,@genreID,@description,@imageUrl)", connection);
            cmd.Parameters.AddWithValue("@name", txt_Movie.Text);
            cmd.Parameters.AddWithValue("@director", txt_Director.Text);
            cmd.Parameters.AddWithValue("@genreID", cb_MovieGenre.SelectedValue);
            cmd.Parameters.AddWithValue("@imageUrl", txt_ImgUrl.Text);
            cmd.Parameters.AddWithValue("@description", rTxt_Description.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Movie inserted succesfully!");
                txt_Movie.Text = "";
                txt_Director.Text = "";
                cb_MovieGenre.SelectedIndex = 0;
                txt_ImgUrl.Text = "";
                rTxt_Description.Text = "";               
            }
            connect();
        }
    }
}
