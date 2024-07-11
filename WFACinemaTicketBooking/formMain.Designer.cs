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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_Movie = new System.Windows.Forms.ComboBox();
            this.cb_Hall = new System.Windows.Forms.ComboBox();
            this.cb_Session = new System.Windows.Forms.ComboBox();
            this.btn_OpenBooking = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_Date = new System.Windows.Forms.ComboBox();
            this.btn_MovieDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(22, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Session :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(41, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Hall :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(29, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "Movie :";
            // 
            // cb_Movie
            // 
            this.cb_Movie.FormattingEnabled = true;
            this.cb_Movie.Location = new System.Drawing.Point(85, 22);
            this.cb_Movie.Name = "cb_Movie";
            this.cb_Movie.Size = new System.Drawing.Size(142, 21);
            this.cb_Movie.TabIndex = 1;
            this.cb_Movie.Click += new System.EventHandler(this.cb_Movie_Click);
            // 
            // cb_Hall
            // 
            this.cb_Hall.FormattingEnabled = true;
            this.cb_Hall.Location = new System.Drawing.Point(85, 76);
            this.cb_Hall.Name = "cb_Hall";
            this.cb_Hall.Size = new System.Drawing.Size(142, 21);
            this.cb_Hall.TabIndex = 3;
            this.cb_Hall.Click += new System.EventHandler(this.cb_Hall_Click);
            // 
            // cb_Session
            // 
            this.cb_Session.FormattingEnabled = true;
            this.cb_Session.Location = new System.Drawing.Point(85, 103);
            this.cb_Session.Name = "cb_Session";
            this.cb_Session.Size = new System.Drawing.Size(142, 21);
            this.cb_Session.TabIndex = 4;
            this.cb_Session.Click += new System.EventHandler(this.cb_Session_Click);
            // 
            // btn_OpenBooking
            // 
            this.btn_OpenBooking.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_OpenBooking.Location = new System.Drawing.Point(12, 136);
            this.btn_OpenBooking.Name = "btn_OpenBooking";
            this.btn_OpenBooking.Size = new System.Drawing.Size(242, 48);
            this.btn_OpenBooking.TabIndex = 5;
            this.btn_OpenBooking.Text = "Book in the Session";
            this.btn_OpenBooking.UseVisualStyleBackColor = true;
            this.btn_OpenBooking.Click += new System.EventHandler(this.btn_OpenBooking_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(37, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 18);
            this.label7.TabIndex = 18;
            this.label7.Text = "Date :";
            // 
            // cb_Date
            // 
            this.cb_Date.FormattingEnabled = true;
            this.cb_Date.Location = new System.Drawing.Point(85, 49);
            this.cb_Date.Name = "cb_Date";
            this.cb_Date.Size = new System.Drawing.Size(142, 21);
            this.cb_Date.TabIndex = 2;
            this.cb_Date.Click += new System.EventHandler(this.cb_Date_Click);
            // 
            // btn_MovieDetails
            // 
            this.btn_MovieDetails.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_MovieDetails.Location = new System.Drawing.Point(233, 22);
            this.btn_MovieDetails.Name = "btn_MovieDetails";
            this.btn_MovieDetails.Size = new System.Drawing.Size(21, 21);
            this.btn_MovieDetails.TabIndex = 19;
            this.btn_MovieDetails.Text = "i";
            this.btn_MovieDetails.UseVisualStyleBackColor = true;
            this.btn_MovieDetails.Visible = false;
            this.btn_MovieDetails.Click += new System.EventHandler(this.btn_MovieDetails_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 193);
            this.Controls.Add(this.btn_MovieDetails);
            this.Controls.Add(this.btn_OpenBooking);
            this.Controls.Add(this.cb_Session);
            this.Controls.Add(this.cb_Hall);
            this.Controls.Add(this.cb_Movie);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_Date);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ticket Booking";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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

