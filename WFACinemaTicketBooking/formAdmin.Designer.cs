using WFACinemaTicketBooking.Properties;

namespace WFACinemaTicketBooking
{
    partial class formAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAdmin));
            this.btn_InsertMovie = new System.Windows.Forms.Button();
            this.btn_CreateSession = new System.Windows.Forms.Button();
            this.btn_EditBookings = new System.Windows.Forms.Button();
            this.btn_BookTicket = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_InsertMovie
            // 
            this.btn_InsertMovie.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_InsertMovie.Location = new System.Drawing.Point(13, 124);
            this.btn_InsertMovie.Name = "btn_InsertMovie";
            this.btn_InsertMovie.Size = new System.Drawing.Size(204, 50);
            this.btn_InsertMovie.TabIndex = 3;
            this.btn_InsertMovie.Text = "Insert Movie";
            this.btn_InsertMovie.UseVisualStyleBackColor = true;
            this.btn_InsertMovie.Click += new System.EventHandler(this.btn_InsertMovie_Click);
            // 
            // btn_CreateSession
            // 
            this.btn_CreateSession.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_CreateSession.Location = new System.Drawing.Point(13, 68);
            this.btn_CreateSession.Name = "btn_CreateSession";
            this.btn_CreateSession.Size = new System.Drawing.Size(204, 50);
            this.btn_CreateSession.TabIndex = 2;
            this.btn_CreateSession.Text = "Create Movie Session";
            this.btn_CreateSession.UseVisualStyleBackColor = true;
            this.btn_CreateSession.Click += new System.EventHandler(this.btn_CreateSession_Click);
            // 
            // btn_EditBookings
            // 
            this.btn_EditBookings.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_EditBookings.Location = new System.Drawing.Point(13, 180);
            this.btn_EditBookings.Name = "btn_EditBookings";
            this.btn_EditBookings.Size = new System.Drawing.Size(204, 50);
            this.btn_EditBookings.TabIndex = 4;
            this.btn_EditBookings.Text = "Show/Edit Bookings";
            this.btn_EditBookings.UseVisualStyleBackColor = true;
            this.btn_EditBookings.Click += new System.EventHandler(this.btn_BookingAdmin_Click);
            // 
            // btn_BookTicket
            // 
            this.btn_BookTicket.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_BookTicket.Location = new System.Drawing.Point(13, 12);
            this.btn_BookTicket.Name = "btn_BookTicket";
            this.btn_BookTicket.Size = new System.Drawing.Size(204, 50);
            this.btn_BookTicket.TabIndex = 1;
            this.btn_BookTicket.Text = "Booking Movie Ticket";
            this.btn_BookTicket.UseVisualStyleBackColor = true;
            this.btn_BookTicket.Click += new System.EventHandler(this.btn_Booking_Click);
            // 
            // formAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 240);
            this.Controls.Add(this.btn_BookTicket);
            this.Controls.Add(this.btn_EditBookings);
            this.Controls.Add(this.btn_InsertMovie);
            this.Controls.Add(this.btn_CreateSession);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Admin Panel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_InsertMovie;
        private System.Windows.Forms.Button btn_CreateSession;
        private System.Windows.Forms.Button btn_EditBookings;
        private System.Windows.Forms.Button btn_BookTicket;
    }
}