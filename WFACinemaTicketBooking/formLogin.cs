using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WFACinemaTicketBooking
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void txt_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login.PerformClick();
            }
        }
        //User types: u, a, s. u is an user. a is an admin. s is a ticket seller.
        //if isAuthorized sets true, the user can access everywhere but admin forms.
        //the user can book or cancel booked tickets of customers.
        //to access admin panels, user's auth must be a.
        //Register form only registers users. So, admin user and ticket seller user need to be register on database or
        //user's auth needs to set a for admin and s for ticket seller.
        private void btn_Login_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionStr"].ToString());
            connection.Open();
            string sql = "select userID, name, surname, auth from tbl_User where email=@email and password=@password";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@email", txt_Email.Text);
            cmd.Parameters.AddWithValue("@password", txt_Password.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string userName = dr[1].ToString() + " " + dr[2].ToString();
                bool isAuthorized = false;
                char authorization = Convert.ToChar(dr[3]);
                if (authorization == 'a' || authorization == 's')//a is the admin user, s is the ticket seller user.
                    isAuthorized = true;
                if (authorization == 'u' || authorization == 's')//u is the normal user.
                {
                    formMain formMain = new formMain();
                    formMain.userID = Convert.ToInt32(dr[0]);
                    formMain.userName = userName.Trim();
                    formMain.isAuthorized = isAuthorized;
                    this.Hide();
                    formMain.ShowDialog();
                    this.Close();
                }
                if (authorization == 'a')
                {
                    formAdmin formAdmin = new formAdmin();
                    this.Hide();
                    formAdmin.ShowDialog();
                    this.Close();
                }
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Email or password is incorrect");
            }
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            formRegister formRegister = new formRegister();
            this.Hide();
            formRegister.ShowDialog();
            if (formRegister.isRegistered)
            {
                txt_Email.Text = formRegister.txt_Email.Text;
                txt_Password.Text = formRegister.txt_Password.Text;
            }
            this.Show();
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionMaster"].ToString());
            try
            {
                bool isExist = false;
                conn.Open();
                SqlCommand cmdDBExist = new SqlCommand("SELECT * FROM sys.databases where Name='MovieTicketBookingDB'", conn);
                SqlDataReader reader = cmdDBExist.ExecuteReader();
                isExist = reader.HasRows;
                conn.Close();
                if (!isExist)
                {
                    #region Create DB Query                
                    string createDBquery = " CREATE DATABASE [MovieTicketBookingDB]" +
                        " GO" +
                        " USE [MovieTicketBookingDB]" +
                        " GO" +
                        " SET ANSI_NULLS ON" +
                        " GO" +
                        " SET QUOTED_IDENTIFIER ON" +
                        " GO" +
                        " CREATE TABLE [dbo].[tbl_Hall](" +
                        " 	[hallID] [int] IDENTITY(1,1) NOT NULL," +
                        " 	[name] [nvarchar](15) NOT NULL," +
                        " 	[hallCapacity] [int] NOT NULL," +
                        "  CONSTRAINT [PK_tbl_Hall] PRIMARY KEY CLUSTERED " +
                        " (" +
                        " 	[hallID] ASC" +
                        " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" +
                        " ) ON [PRIMARY]" +
                        " GO" +
                        " SET ANSI_NULLS ON" +
                        " GO" +
                        " SET QUOTED_IDENTIFIER ON" +
                        " GO" +
                        " CREATE TABLE [dbo].[tbl_Movie](" +
                        " 	[movieID] [int] IDENTITY(1,1) NOT NULL," +
                        " 	[name] [nvarchar](50) NOT NULL," +
                        " 	[director] [nvarchar](50) NOT NULL," +
                        " 	[genreID] [int] NOT NULL," +
                        " 	[description] [nvarchar](max) NULL," +
                        "  CONSTRAINT [PK_tbl_Movie] PRIMARY KEY CLUSTERED " +
                        " (" +
                        " 	[movieID] ASC" +
                        " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" +
                        " ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]" +
                        " GO" +
                        " SET ANSI_NULLS ON" +
                        " GO" +
                        " SET QUOTED_IDENTIFIER ON" +
                        " GO" +
                        " CREATE TABLE [dbo].[tbl_MovieGenre](" +
                        " 	[genreID] [int] IDENTITY(1,1) NOT NULL," +
                        " 	[genre] [nvarchar](20) NOT NULL," +
                        "  CONSTRAINT [PK_tbl_MovieGenre] PRIMARY KEY CLUSTERED " +
                        " (" +
                        " 	[genreID] ASC" +
                        " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" +
                        " ) ON [PRIMARY]" +
                        " " +
                        " GO" +
                        " SET ANSI_NULLS ON" +
                        " GO" +
                        " SET QUOTED_IDENTIFIER ON" +
                        " GO" +
                        " CREATE TABLE [dbo].[tbl_MovieSession](" +
                        " 	[movieSessionID] [int] IDENTITY(1,1) NOT NULL," +
                        " 	[movieID] [int] NOT NULL," +
                        " 	[hallID] [int] NOT NULL," +
                        " 	[date] [date] NOT NULL," +
                        " 	[sessionID] [int] NOT NULL," +
                        "  CONSTRAINT [PK_tbl_MovieSession] PRIMARY KEY CLUSTERED " +
                        " (" +
                        " 	[movieSessionID] ASC" +
                        " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" +
                        " ) ON [PRIMARY]" +
                        " " +
                        " GO" +
                        " SET ANSI_NULLS ON" +
                        " GO" +
                        " SET QUOTED_IDENTIFIER ON" +
                        " GO" +
                        " SET ANSI_PADDING ON" +
                        " GO" +
                        " CREATE TABLE [dbo].[tbl_Session](" +
                        " 	[sessionID] [int] IDENTITY(1,1) NOT NULL," +
                        " 	[hour] [varchar](5) NOT NULL," +
                        "  CONSTRAINT [PK_tbl_Session] PRIMARY KEY CLUSTERED " +
                        " (" +
                        " 	[sessionID] ASC" +
                        " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" +
                        " ) ON [PRIMARY]" +
                        " " +
                        " GO" +
                        " SET ANSI_PADDING OFF" +
                        " GO" +
                        " SET ANSI_NULLS ON" +
                        " GO" +
                        " SET QUOTED_IDENTIFIER ON" +
                        " GO" +
                        " CREATE TABLE [dbo].[tbl_TicketBooking](" +
                        " 	[ticketID] [int] IDENTITY(1,1) NOT NULL," +
                        " 	[movieSessionID] [int] NOT NULL," +
                        " 	[userID] [int] NOT NULL," +
                        " 	[seatNo] [int] NOT NULL," +
                        " 	[price] [money] NOT NULL," +
                        " 	[ticketDate] [datetime] NULL CONSTRAINT [DF_tbl_BiletSatis_biletTarih]  DEFAULT (getdate())," +
                        "  CONSTRAINT [PK_tbl_TicketBooking] PRIMARY KEY CLUSTERED " +
                        " (" +
                        " 	[ticketID] ASC" +
                        " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" +
                        " ) ON [PRIMARY]" +
                        " " +
                        " GO" +
                        " SET ANSI_NULLS ON" +
                        " GO" +
                        " SET QUOTED_IDENTIFIER ON" +
                        " GO" +
                        " SET ANSI_PADDING ON" +
                        " GO" +
                        " CREATE TABLE [dbo].[tbl_User](" +
                        " 	[userID] [int] IDENTITY(1,1) NOT NULL," +
                        " 	[name] [nvarchar](25) NULL," +
                        " 	[surname] [nvarchar](25) NULL," +
                        " 	[profession] [nvarchar](50) NULL," +
                        " 	[phoneNumber] [varchar](11) NULL," +
                        " 	[email] [varchar](200) NOT NULL," +
                        " 	[password] [varchar](16) NOT NULL," +
                        " 	[auth] [char](1) NOT NULL," +
                        "  CONSTRAINT [PK_tbl_User] PRIMARY KEY CLUSTERED " +
                        " (" +
                        " 	[userID] ASC" +
                        " )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" +
                        " ) ON [PRIMARY]" +
                        " " +
                        " GO" +
                        " SET ANSI_PADDING OFF" +
                        " GO" +
                        " ALTER TABLE [dbo].[tbl_Movie]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Filmler_tbl_MovieGenre] FOREIGN KEY([genreID])" +
                        " REFERENCES [dbo].[tbl_MovieGenre] ([genreID])" +
                        " GO" +
                        " ALTER TABLE [dbo].[tbl_Movie] CHECK CONSTRAINT [FK_tbl_Filmler_tbl_MovieGenre]" +
                        " GO" +
                        " ALTER TABLE [dbo].[tbl_MovieSession]  WITH CHECK ADD  CONSTRAINT [FK_tbl_MovieSession_tbl_Hall] FOREIGN KEY([hallID])" +
                        " REFERENCES [dbo].[tbl_Hall] ([hallID])" +
                        " GO" +
                        " ALTER TABLE [dbo].[tbl_MovieSession] CHECK CONSTRAINT [FK_tbl_MovieSession_tbl_Hall]" +
                        " GO" +
                        " ALTER TABLE [dbo].[tbl_MovieSession]  WITH CHECK ADD  CONSTRAINT [FK_tbl_MovieSession_tbl_Movie] FOREIGN KEY([movieID])" +
                        " REFERENCES [dbo].[tbl_Movie] ([movieID])" +
                        " GO" +
                        " ALTER TABLE [dbo].[tbl_MovieSession] CHECK CONSTRAINT [FK_tbl_MovieSession_tbl_Movie]" +
                        " GO" +
                        " ALTER TABLE [dbo].[tbl_MovieSession]  WITH CHECK ADD  CONSTRAINT [FK_tbl_MovieSession_tbl_Session] FOREIGN KEY([sessionID])" +
                        " REFERENCES [dbo].[tbl_Session] ([sessionID])" +
                        " GO" +
                        " ALTER TABLE [dbo].[tbl_MovieSession] CHECK CONSTRAINT [FK_tbl_MovieSession_tbl_Session]" +
                        " GO" +
                        " ALTER TABLE [dbo].[tbl_TicketBooking]  WITH CHECK ADD  CONSTRAINT [FK_tbl_BiletSatis_tbl_BiletSatis] FOREIGN KEY([userID])" +
                        " REFERENCES [dbo].[tbl_User] ([userID])" +
                        " GO" +
                        " ALTER TABLE [dbo].[tbl_TicketBooking] CHECK CONSTRAINT [FK_tbl_BiletSatis_tbl_BiletSatis]" +
                        " GO" +
                        " ALTER TABLE [dbo].[tbl_TicketBooking]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TicketBooking_tbl_MovieSession] FOREIGN KEY([movieSessionID])" +
                        " REFERENCES [dbo].[tbl_MovieSession] ([movieSessionID])" +
                        " GO" +
                        " ALTER TABLE [dbo].[tbl_TicketBooking] CHECK CONSTRAINT [FK_tbl_TicketBooking_tbl_MovieSession]" +
                        " GO" +
                        " USE [master]" +
                        " GO" +
                        " ALTER DATABASE [MovieTicketBookingDB] SET  READ_WRITE" +
                        " GO ";
                    #endregion
                    try
                    {
                        conn.Open();
                        string[] split = new string[] { " GO " };
                        string[] commandTexts = createDBquery.Split(split, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string commandText in commandTexts)
                        {
                            SqlCommand cmd = new SqlCommand(commandText, conn);
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        MessageBox.Show("Error occurred while creating database: Error: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error occurred while searching database: Error: " + ex.Message);
                throw;
            }
        }
    }
}
