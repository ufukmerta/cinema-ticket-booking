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
            btn_BookTicket = new System.Windows.Forms.Button();
            btn_CreateSession = new System.Windows.Forms.Button();
            btn_InsertMovie = new System.Windows.Forms.Button();
            btn_EditBookings = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btn_BookTicket
            // 
            btn_BookTicket.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btn_BookTicket.Location = new System.Drawing.Point(12, 12);
            btn_BookTicket.Name = "btn_BookTicket";
            btn_BookTicket.Size = new System.Drawing.Size(238, 58);
            btn_BookTicket.TabIndex = 0;
            btn_BookTicket.Text = "Booking Movie Ticket";
            btn_BookTicket.UseVisualStyleBackColor = true;
            btn_BookTicket.Click += btn_BookTicket_Click;
            // 
            // btn_CreateSession
            // 
            btn_CreateSession.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btn_CreateSession.Location = new System.Drawing.Point(12, 76);
            btn_CreateSession.Name = "btn_CreateSession";
            btn_CreateSession.Size = new System.Drawing.Size(238, 58);
            btn_CreateSession.TabIndex = 1;
            btn_CreateSession.Text = "Create Movie Session";
            btn_CreateSession.UseVisualStyleBackColor = true;
            btn_CreateSession.Click += btn_CreateSession_Click;
            // 
            // btn_InsertMovie
            // 
            btn_InsertMovie.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btn_InsertMovie.Location = new System.Drawing.Point(12, 140);
            btn_InsertMovie.Name = "btn_InsertMovie";
            btn_InsertMovie.Size = new System.Drawing.Size(238, 58);
            btn_InsertMovie.TabIndex = 2;
            btn_InsertMovie.Text = "Insert Movie";
            btn_InsertMovie.UseVisualStyleBackColor = true;
            btn_InsertMovie.Click += btn_InsertMovie_Click;
            // 
            // btn_EditBookings
            // 
            btn_EditBookings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            btn_EditBookings.Location = new System.Drawing.Point(12, 204);
            btn_EditBookings.Name = "btn_EditBookings";
            btn_EditBookings.Size = new System.Drawing.Size(238, 58);
            btn_EditBookings.TabIndex = 3;
            btn_EditBookings.Text = "Show/Edit Bookings";
            btn_EditBookings.UseVisualStyleBackColor = true;
            btn_EditBookings.Click += btn_EditBookings_Click;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(264, 277);
            Controls.Add(btn_EditBookings);
            Controls.Add(btn_InsertMovie);
            Controls.Add(btn_CreateSession);
            Controls.Add(btn_BookTicket);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "formAdmin";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Admin Panel";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btn_BookTicket;
        private System.Windows.Forms.Button btn_CreateSession;
        private System.Windows.Forms.Button btn_InsertMovie;
        private System.Windows.Forms.Button btn_EditBookings;
    }
}