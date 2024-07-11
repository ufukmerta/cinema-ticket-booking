using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;


namespace WFACinemaTicketBooking
{
    public partial class formBooking : Form
    {
        public formBooking()
        {
            InitializeComponent();
        }
        ArrayList seats = new ArrayList();
        ArrayList cancelSeats = new ArrayList();
        internal int movieID = 0;
        internal string date = "";
        internal int hallID = 0;
        internal int sessionID = 0;

        internal int userID = 0;
        internal string userName = "";
        internal bool isAuthorized = false;

        int movieSessionID = 0;
        int hallCapacity = 60;
        int price = 100;

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

        private void btn_Seat_Click(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.Lime)
            {
                ((Button)sender).BackColor = Color.Orange;
                seats.Add(Convert.ToInt32(((Button)sender).Text));
                seats.Sort();
                listChosenSeat();

            }
            else if (((Button)sender).BackColor == Color.Orange)
            {
                ((Button)sender).BackColor = Color.Lime;
                seats.Remove(Convert.ToInt32(((Button)sender).Text));
                seats.Sort();
                listChosenSeat();
            }
            else if (((Button)sender).BackColor == Color.OrangeRed)
            {
                ((Button)sender).BackColor = Color.LightCoral;
                cancelSeats.Remove(Convert.ToInt32(((Button)sender).Text));
                cancelSeats.Sort();
                listCancelSeat();
            }
            else if (((Button)sender).BackColor == Color.LightCoral)
            {
                ((Button)sender).BackColor = Color.OrangeRed;
                cancelSeats.Add(Convert.ToInt32(((Button)sender).Text));
                cancelSeats.Sort();
                listCancelSeat();
            }
        }
        void listChosenSeat()
        {
            txt_seatNo.Text = "";
            foreach (object seat in seats)
            {
                txt_seatNo.Text += seat + ", ";
            }
            if (seats.Count >= 1)
                txt_seatNo.Text = txt_seatNo.Text.Remove(txt_seatNo.Text.Length - 2, 2);
        }
        void listCancelSeat()
        {
            txt_CancelSeatNo.Text = "";
            foreach (object seat in cancelSeats)
            {
                txt_CancelSeatNo.Text += seat + ", ";
            }
            if (cancelSeats.Count >= 1)
                txt_CancelSeatNo.Text = txt_CancelSeatNo.Text.Remove(txt_CancelSeatNo.Text.Length - 2, 2);
        }

        private void FormBooking_Load(object sender, EventArgs e)
        {
            if (!isAuthorized)
            {
                txt_UserName.Text = userName;
                txt_PhoneNumber.Visible = false;
                label8.Visible = false;
                btn_BookTicket.Top = 60;
                btn_BookTicket.Enabled = true;
                btn_CancelTicket.Enabled = true;
                btn_FindCustomer.Visible = false;
            }
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
        private void getTicket()
        {
            connect();
            SqlCommand cmd = new SqlCommand("select seatNo,userID from tbl_TicketBooking where movieSessionID=@movieSessionID", connection);
            cmd.Parameters.AddWithValue("@movieSessionID", movieSessionID);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (userID != Convert.ToInt32(dr[1]))
                {
                    this.Controls.Find("btn" + Convert.ToInt32(dr[0]), true)[0].BackColor = Color.Red;
                    this.Controls.Find("btn" + Convert.ToInt32(dr[0]), true)[0].Enabled = false;
                }
                else
                {
                    this.Controls.Find("btn" + Convert.ToInt32(dr[0]), true)[0].BackColor = Color.LightCoral;
                    this.Controls.Find("btn" + Convert.ToInt32(dr[0]), true)[0].Enabled = Enabled;
                }
            }
            for (int i = hallCapacity + 1; i <= 60; i++)
            {
                this.Controls.Find("btn" + i, true)[0].BackColor = Color.Red;
                this.Controls.Find("btn" + i, true)[0].Enabled = false;
            }
            connect();
        }

        bool validityCheck(string chosenTicket)
        {
            if (chosenTicket != "")
            {
                if (userID != 0)
                {
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Seat number isn't chosen!");
            }
            return false;
        }
        private void btn_BiletAyir_Click(object sender, EventArgs e)
        {
            if (validityCheck(txt_seatNo.Text))
            {
                bookTicket();
            }
        }

        void bookTicket()
        {
            connect();
            for (int i = 0; i < seats.Count; i++)
            {
                SqlCommand cmd = new SqlCommand("insert into tbl_TicketBooking(movieSessionID, userID, seatNo, price) " +
                    "values(@movieSessionID,@userID,@seatNo,@price)", connection);
                cmd.Parameters.AddWithValue("@movieSessionID", movieSessionID);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@seatNo", seats[i]);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.ExecuteNonQuery();
                this.Controls.Find("btn" + seats[i].ToString(), true)[0].BackColor = Color.LightCoral;
            }
            connect();
            if (txt_seatNo.TextLength <= 2 && isAuthorized)
                MessageBox.Show("Number " + txt_seatNo.Text + " seat is booked by " + txt_UserName.Text);
            else if (txt_seatNo.TextLength > 2 && isAuthorized)
                MessageBox.Show("Number " + txt_seatNo.Text + " seat is booked by " + txt_UserName.Text);
            else if (txt_seatNo.TextLength <= 2 && !isAuthorized)
                MessageBox.Show("You (" + txt_UserName.Text + ") booked number " + txt_seatNo.Text + " seat.");
            else if (txt_seatNo.TextLength > 2 && !isAuthorized)
                MessageBox.Show("You (" + txt_UserName.Text + ") booked number " + txt_seatNo.Text + " seats.");
            seats.Clear();
            txt_seatNo.Text = "";
        }
        private void txt_PhoneNumber_TextChanged(object sender, EventArgs e)
        {
            userID = 0;
            txt_UserName.Text = "";
            btn_BookTicket.Enabled = btn_CancelTicket.Enabled = false;
        }

        private void rb_TicketType_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Student.Checked == true)
                price = 80;
            else
                price = 100;
        }

        private void btn_FindCustomer_Click(object sender, EventArgs e)
        {
            connect();
            SqlCommand cmd = new SqlCommand("select userID, name, surname from tbl_User where phoneNumber=@phoneNumber", connection);
            cmd.Parameters.AddWithValue("@phoneNumber", txt_PhoneNumber.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                userID = Convert.ToInt32(dr[0]);
                txt_UserName.Text = dr[1].ToString() + " " + dr[2].ToString();
                btn_BookTicket.Enabled = btn_CancelTicket.Enabled = true;
            }
            else
            {
                userID = 0;
                MessageBox.Show("Customer cannot be found with given phone number!");
                btn_BookTicket.Enabled = btn_CancelTicket.Enabled = false;
            }
            connect();
            getTicket();
        }

        private void btn_CancelTicket_Click(object sender, EventArgs e)
        {
            if (validityCheck(txt_CancelSeatNo.Text))
            {
                cancelTicket();
            }
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
            if (txt_CancelSeatNo.TextLength <= 2 && isAuthorized)
                MessageBox.Show("Number " + txt_CancelSeatNo.Text + " seat of " + txt_UserName.Text + " customer's booked ticket is canceled.");
            else if (txt_CancelSeatNo.TextLength > 2 && isAuthorized)
                MessageBox.Show("Number " + txt_CancelSeatNo.Text + " seats of " + txt_UserName.Text + " customer's booked tickets are canceled.");
            else if (txt_CancelSeatNo.TextLength <= 2 && !isAuthorized)
                MessageBox.Show("You (" + txt_UserName.Text + ") canceled your booked number " + txt_CancelSeatNo.Text + " seat.");
            else if (txt_CancelSeatNo.TextLength > 2 && !isAuthorized)
                MessageBox.Show("You (" + txt_UserName.Text + ") canceled your booked number " + txt_CancelSeatNo.Text + " seats.");
            cancelSeats.Clear();
        }
    }
}
