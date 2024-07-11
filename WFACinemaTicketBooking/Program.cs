using System;
using System.Windows.Forms;

namespace WFACinemaTicketBooking
{
    static class Program
    {
        //An icon that is taken by the website is used by this project to represent its forms and application image.
        //Movie Ticket icon by Icons8, icons8.com/icon/OHTdn9KDbw19/movie-ticket
        //link control date: 26/05/2024 22.10
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new formLogin());
        }
    }
}
