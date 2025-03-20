using System;
using System.Collections;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using ToolTip = System.Windows.Forms.ToolTip;


namespace WFACinemaTicketBooking
{
    public partial class formBookingAdmin : Form
    {
        public formBookingAdmin()
        {
            InitializeComponent();
        }
        ArrayList cancelSeats = new ArrayList();
        internal int movieID = 0;
        internal int hallID = 0;
        internal string date = "";
        internal int sessionID = 0;
        int movieSessionID = 0;
        int hallCapacity = 60;

        int userID = 0;

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionStr"].ToString());
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

        private void btn_Seat_Click(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.DarkRed)
            {
                ((Button)sender).BackColor = Color.LightCoral;
                cancelSeats.Remove(Convert.ToInt32(((Button)sender).Text));
                cancelSeats.Sort();
                listCancelSeats();
            }
            else if (((Button)sender).BackColor == Color.LightCoral)
            {
                ((Button)sender).BackColor = Color.DarkRed;
                cancelSeats.Add(Convert.ToInt32(((Button)sender).Text));
                cancelSeats.Sort();
                listCancelSeats();
            }
            else if (((Button)sender).BackColor == Color.Red)
            {
                if (txt_PhoneNumber.Text != ((Button)sender).Tag.ToString())
                {
                    cancelSeats.Clear();
                    txt_CancelSeatNo.Text = "";
                    txt_PhoneNumber.Text = ((Button)sender).Tag.ToString();
                    findCustomer();
                }
            }
        }
        void listCancelSeats()
        {
            txt_CancelSeatNo.Text = "";
            foreach (object seat in cancelSeats)
            {
                txt_CancelSeatNo.Text += seat + ", ";
            }
            if (cancelSeats.Count >= 1)
                txt_CancelSeatNo.Text = txt_CancelSeatNo.Text[..^2];
        }
        void findCustomer()
        {
            connect();
            SqlCommand cmd = new SqlCommand("select userID, name, surname from tbl_User where phoneNumber=@phoneNumber", connection);
            cmd.Parameters.AddWithValue("@phoneNumber", txt_PhoneNumber.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                userID = Convert.ToInt32(dr[0]);
                txt_UserName.Text = dr[1].ToString() + " " + dr[2].ToString();
                btn_CancelTicket.Enabled = true;
            }
            else
            {
                userID = 0;
                MessageBox.Show("Customer cannot be found with given phone number!");
                btn_CancelTicket.Enabled = false;
            }
            connect();
            getTicket();
        }

        private void FormBookingAdmin_Load(object sender, EventArgs e)
        {
            movieSessionID = getmovieSessionID();
            getMovieandSessionDetails();
            getTicket();
        }

        private int getmovieSessionID()
        {
            int id = 0;
            connect();
            SqlCommand cmd = new SqlCommand("select movieSessionID from tbl_MovieSession where " +
                "movieID=@movieID and hallID=@hallID and date=@date and sessionID=@sessionID", connection);
            cmd.Parameters.AddWithValue("@movieID", movieID);
            cmd.Parameters.AddWithValue("@hallID", hallID);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@sessionID", sessionID);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                id = Convert.ToInt32(dr["movieSessionID"]);
            }
            connect();
            return id;
        }
        void getMovieandSessionDetails()
        {
            connect();

            SqlCommand cmd = new SqlCommand("select tbl_Movie.name,tbl_Hall.name,tbl_Session.hour,tbl_Hall.hallCapacity from tbl_MovieSession " +
                "INNER JOIN tbl_Movie ON tbl_MovieSession.movieID=tbl_Movie.movieID " +
                "INNER JOIN tbl_Hall ON tbl_MovieSession.hallID=tbl_Hall.hallID " +
                "INNER JOIN tbl_Session ON tbl_MovieSession.sessionID=tbl_Session.sessionID where movieSessionID=@movieSessionID", connection);
            cmd.Parameters.AddWithValue("@movieSessionID", movieSessionID);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lbl_MovieName.Text = dr[0].ToString();
                lbl_MovieSession.Text = dr[1].ToString() + " / " + date + " / " + dr[2].ToString();
                hallCapacity = Convert.ToInt32(dr[3]);
            }
            dr.Close();
            connect();
        }
        ToolTip[] myToolTip = new ToolTip[60];
        private void getTicket()
        {
            connect();
            SqlCommand cmd = new SqlCommand("select seatNo, tbl_TicketBooking.userID, name, surname, phoneNumber from tbl_TicketBooking " +
                "INNER JOIN tbl_User ON tbl_TicketBooking.userID=tbl_User.userID where movieSessionID=@movieSessionID", connection);
            cmd.Parameters.AddWithValue("@movieSessionID", movieSessionID);
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {

                ToolTip tool = new ToolTip();
                Button btn = (Button)Controls.Find("btn" + Convert.ToInt32(dr[0]), true)[0];
                tool.SetToolTip(btn, dr[2] + " " + dr[3]);
                myToolTip[i++] = tool;
                btn.Tag = dr[4];
                if (userID != Convert.ToInt32(dr[1]))
                {
                    btn.BackColor = Color.Red;
                }
                else
                {
                    btn.BackColor = Color.LightCoral;
                }
            }
            for (int j = hallCapacity + 1; j <= 60; j++)
            {
                Controls.Find("btn" + j, true)[0].BackColor = Color.Red;
                Controls.Find("btn" + j, true)[0].Enabled = false;
            }
            connect();
        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            userID = 0;
            txt_UserName.Text = "";
            btn_CancelTicket.Enabled = false;
        }

        private void cancelTicket()
        {
            connect();
            for (int i = 0; i < cancelSeats.Count; i++)
            {
                SqlCommand cmd = new SqlCommand("delete from tbl_TicketBooking where movieSessionID=@movieSessionID and seatNo=@seatNo", connection);
                cmd.Parameters.AddWithValue("@movieSessionID", movieSessionID);
                cmd.Parameters.AddWithValue("@seatNo", cancelSeats[i]);
                cmd.ExecuteNonQuery();
                this.Controls.Find("btn" + cancelSeats[i].ToString(), true)[0].BackColor = Color.Lime;
            }
            connect();
            if (txt_CancelSeatNo.TextLength <= 2)
                MessageBox.Show("Number " + txt_CancelSeatNo.Text + " seat of " + txt_UserName.Text + " customer's booked ticket is canceled.");
            else if (txt_CancelSeatNo.TextLength > 2)
                MessageBox.Show("Number " + txt_CancelSeatNo.Text + " seats of " + txt_UserName.Text + " customer's booked tickets are canceled.");
            cancelSeats.Clear();
        }

        private void btn_FindCustomer_Click(object sender, EventArgs e)
        {
            if (txt_PhoneNumber.Text != "")
            {
                findCustomer();
            }
        }

        private void btn_CancelTicket_Click(object sender, EventArgs e)
        {
            if (txt_CancelSeatNo.Text != "")
            {
                if (userID != 0)
                {
                    cancelTicket();
                }
            }
            else
            {
                MessageBox.Show("Seat number isn't chosen!");
            }
        }
    }
}
