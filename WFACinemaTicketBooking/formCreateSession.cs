using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WFACinemaTicketBooking
{
    public partial class formCreateSession : Form
    {
        public formCreateSession()
        {
            InitializeComponent();
        }
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
            allSession.Clear();
            connect();
            SqlCommand cmd = new SqlCommand("select * from tbl_Session", connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                allSession.Add(Convert.ToInt32(dr["sessionID"]), dr["hour"].ToString().Substring(0, 2));
            }
            connect();
        }
        void getMovies()
        {
            connect();
            SqlDataAdapter da = new SqlDataAdapter("select movieID, name from tbl_Movie", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cb_Movie.DataSource = dt;
            cb_Movie.DisplayMember = "name";
            cb_Movie.ValueMember = "movieID";
            connect();
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
            cb_Session10.Checked = cb_Session12.Checked = cb_Session14.Checked = cb_Session16.Checked = cb_Session18.Checked = false;
        }
        void getHall()
        {
            if (firstOpen)
            {
                return;
            }
            date = (dtp.Value).ToString("yyyy-MM-dd");
            connect();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbl_Hall WHERE hallID " +
                "IN (SELECT hallID FROM tbl_MovieSession WHERE movieID=@movieID and date=@date)", connection);
            cmd.Parameters.AddWithValue("@movieID", cb_Movie.SelectedValue);
            cmd.Parameters.AddWithValue("@date", date);
            int count = (int)cmd.ExecuteScalar();
            string sql = "";
            if (count == 0)
            {
                sql = "SELECT * FROM tbl_Hall WHERE hallID NOT IN " +
                               "(SELECT hallID FROM tbl_MovieSession WHERE date='" + date + "') ORDER BY name";
            }
            else
            {
                sql = "SELECT * FROM tbl_Hall WHERE hallID NOT IN " +
                               "(SELECT hallID FROM tbl_MovieSession WHERE date='" + date + "') OR hallID IN" +
                               "(SELECT hallID FROM tbl_MovieSession WHERE movieID=" + cb_Movie.SelectedValue + " and date='" + date + "') ORDER BY name";
            }
            SqlDataAdapter da = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cb_Hall.DataSource = dt;
            cb_Hall.DisplayMember = "name";
            cb_Hall.ValueMember = "hallID";
            connect();
            if (count != 0) getMovieSession();
        }
        void getMovieSession()
        {
            connect();
            SqlCommand cmd = new SqlCommand("select * from tbl_Session where sessionID " +
                "IN (SELECT sessionID FROM tbl_MovieSession WHERE movieID=@movieID and date=@date)", connection);
            cmd.Parameters.AddWithValue("@movieID", cb_Movie.SelectedValue);
            cmd.Parameters.AddWithValue("@date", date);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int hour = Convert.ToInt32(dr["hour"].ToString().Substring(0, 2));
                try
                {
                    (Controls.Find("cb_Session" + hour, true)[0] as CheckBox).Checked = true;
                    Controls.Find("cb_Session" + hour, true)[0].Tag = true;
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Error occured on session times. Update is required. Inform your manager!");
                }
            }
            connect();
        }
        private void cb_Movie_SelectedValueChanged(object sender, EventArgs e)
        {
            cleanSessionState();
            getHall();
        }
        Dictionary<int, string> allSession = new Dictionary<int, string>();
        int findSessionID(int i)
        {
            foreach (int sessionID in allSession.Keys)
            {
                if (allSession[sessionID] == i.ToString())
                {
                    return sessionID;
                }
            }
            return -1;
        }
        private void btn_InsertSessions_Click(object sender, EventArgs e)
        {
            bool sessionError = false;
            getMovieSession();
            date = (dtp.Value).ToString("yyyy-MM-dd");
            for (int i = 10; i <= 20; i += 2)
            {
                if ((Controls.Find("cb_Session" + i, true)[0] as CheckBox).Checked == true)
                {
                    //varolan seansı tekrar ekleme
                    if (Convert.ToBoolean(Controls.Find("cb_Session" + i, true)[0].Tag) == true)
                        continue;
                    int sessionID = findSessionID(i);
                    if (sessionID == -1)
                    {
                        sessionError = true;
                        this.Controls.Find("cb_Session" + i, true)[0].Enabled = false;
                        return;
                    }
                    connect();
                    SqlCommand cmd = new SqlCommand("INSERT INTO tbl_MovieSession(movieID,hallID,date,sessionID) " +
                        "values(@movieID,@hallID,@date,@sessionID)", connection);
                    cmd.Parameters.AddWithValue("@movieID", Convert.ToInt32(cb_Movie.SelectedValue));
                    cmd.Parameters.AddWithValue("@hallID", Convert.ToInt32(cb_Hall.SelectedValue));
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@sessionID", sessionID);
                    cmd.ExecuteNonQuery();
                    connect();
                }
                else
                {
                    if (Convert.ToBoolean(Controls.Find("cb_Session" + i, true)[0].Tag) == true)
                    {
                        int sessionID = findSessionID(i);
                        int movieSessionID = -1;
                        connect();
                        SqlCommand cmd1 = new SqlCommand("SELECT movieSessionID from tbl_MovieSession where " +
                            "movieID=@movieID AND hallID=@hallID AND date=@date AND sessionID=@sessionID", connection);
                        cmd1.Parameters.AddWithValue("@movieID", Convert.ToInt32(cb_Movie.SelectedValue));
                        cmd1.Parameters.AddWithValue("@hallID", Convert.ToInt32(cb_Hall.SelectedValue));
                        cmd1.Parameters.AddWithValue("@date", date);
                        cmd1.Parameters.AddWithValue("@sessionID", sessionID);
                        SqlDataReader dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            movieSessionID = Convert.ToInt32(dr1["movieSessionID"]);
                        }
                        connect();
                        connect();
                        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbl_TicketBooking WHERE movieSessionID=@movieSessionID", connection);
                        cmd1.Parameters.AddWithValue("@movieSessionID", movieSessionID);
                        int result = (Int32)cmd.ExecuteScalar();
                        if (result != 0)
                        {
                            MessageBox.Show("For " + cb_Movie.SelectedText + " movie, " +
                                "" + date + " date, " +
                                "" + i + "hour, at least there is one booking. The Session cannot be canceled.");
                            connect();
                            continue;
                        }
                        else
                        {
                            connect();
                            connect();
                            SqlCommand cmd2 = new SqlCommand("delete from tbl_MovieSession where movieSessionID=@movieSessionID", connection);
                            cmd2.Parameters.AddWithValue("@movieSessionID", movieSessionID);
                            if (cmd2.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("For " + cb_Movie.Text + " movie, " +
                                "" + date + " date, " +
                                "" + i + " hour, the session is canceled.");
                            }
                            connect();
                        }
                    }
                }
            }
            if (sessionError) MessageBox.Show("Not all selected session created. Created ones are selected.");
            else MessageBox.Show("All sessions are created.");
        }

        private void cb_Hall_SelectedValueChanged(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                return;
            }
            getMovieSession();
        }
    }
}
