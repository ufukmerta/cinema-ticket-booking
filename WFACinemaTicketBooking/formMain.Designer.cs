namespace WFACinemaTicketBooking
{
    partial class formMain
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            cb_Movie = new System.Windows.Forms.ComboBox();
            cb_Hall = new System.Windows.Forms.ComboBox();
            cb_Session = new System.Windows.Forms.ComboBox();
            btn_OpenBooking = new System.Windows.Forms.Button();
            label7 = new System.Windows.Forms.Label();
            cb_Date = new System.Windows.Forms.ComboBox();
            btn_MovieDetails = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            label4.Location = new System.Drawing.Point(26, 120);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(57, 18);
            label4.TabIndex = 10;
            label4.Text = "Session :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            label5.Location = new System.Drawing.Point(48, 89);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(38, 18);
            label5.TabIndex = 9;
            label5.Text = "Hall :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            label6.Location = new System.Drawing.Point(34, 27);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(50, 18);
            label6.TabIndex = 8;
            label6.Text = "Movie :";
            // 
            // cb_Movie
            // 
            cb_Movie.FormattingEnabled = true;
            cb_Movie.Location = new System.Drawing.Point(99, 25);
            cb_Movie.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_Movie.Name = "cb_Movie";
            cb_Movie.Size = new System.Drawing.Size(165, 23);
            cb_Movie.TabIndex = 1;
            cb_Movie.Click += cb_Movie_Click;
            // 
            // cb_Hall
            // 
            cb_Hall.FormattingEnabled = true;
            cb_Hall.Location = new System.Drawing.Point(99, 88);
            cb_Hall.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_Hall.Name = "cb_Hall";
            cb_Hall.Size = new System.Drawing.Size(165, 23);
            cb_Hall.TabIndex = 3;
            cb_Hall.Click += cb_Hall_Click;
            // 
            // cb_Session
            // 
            cb_Session.FormattingEnabled = true;
            cb_Session.Location = new System.Drawing.Point(99, 119);
            cb_Session.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_Session.Name = "cb_Session";
            cb_Session.Size = new System.Drawing.Size(165, 23);
            cb_Session.TabIndex = 4;
            cb_Session.Click += cb_Session_Click;
            // 
            // btn_OpenBooking
            // 
            btn_OpenBooking.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            btn_OpenBooking.Location = new System.Drawing.Point(14, 157);
            btn_OpenBooking.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_OpenBooking.Name = "btn_OpenBooking";
            btn_OpenBooking.Size = new System.Drawing.Size(282, 55);
            btn_OpenBooking.TabIndex = 5;
            btn_OpenBooking.Text = "Book in the Session";
            btn_OpenBooking.UseVisualStyleBackColor = true;
            btn_OpenBooking.Click += btn_OpenBooking_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            label7.Location = new System.Drawing.Point(43, 58);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(42, 18);
            label7.TabIndex = 18;
            label7.Text = "Date :";
            // 
            // cb_Date
            // 
            cb_Date.FormattingEnabled = true;
            cb_Date.Location = new System.Drawing.Point(99, 57);
            cb_Date.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_Date.Name = "cb_Date";
            cb_Date.Size = new System.Drawing.Size(165, 23);
            cb_Date.TabIndex = 2;
            cb_Date.Click += cb_Date_Click;
            // 
            // btn_MovieDetails
            // 
            btn_MovieDetails.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            btn_MovieDetails.Location = new System.Drawing.Point(272, 25);
            btn_MovieDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_MovieDetails.Name = "btn_MovieDetails";
            btn_MovieDetails.Size = new System.Drawing.Size(24, 24);
            btn_MovieDetails.TabIndex = 19;
            btn_MovieDetails.Text = "i";
            btn_MovieDetails.UseVisualStyleBackColor = true;
            btn_MovieDetails.Visible = false;
            btn_MovieDetails.Click += btn_MovieDetails_Click;
            // 
            // formMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(310, 223);
            Controls.Add(btn_MovieDetails);
            Controls.Add(btn_OpenBooking);
            Controls.Add(cb_Session);
            Controls.Add(cb_Hall);
            Controls.Add(cb_Movie);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(cb_Date);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "formMain";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Ticket Booking";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_Movie;
        private System.Windows.Forms.ComboBox cb_Hall;
        private System.Windows.Forms.ComboBox cb_Session;
        private System.Windows.Forms.Button btn_OpenBooking;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_Date;
        private System.Windows.Forms.Button btn_MovieDetails;
    }
}

