namespace WFACinemaTicketBooking
{
    partial class formMovieDetail
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
            this.pcBox_Movie = new System.Windows.Forms.PictureBox();
            this.lbl_MovieName = new System.Windows.Forms.Label();
            this.lbl_Director = new System.Windows.Forms.Label();
            this.lbl_Genre = new System.Windows.Forms.Label();
            this.lbl_Detail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcBox_Movie)).BeginInit();
            this.SuspendLayout();
            // 
            // pcBox_Movie
            // 
            this.pcBox_Movie.Location = new System.Drawing.Point(12, 12);
            this.pcBox_Movie.Name = "pcBox_Movie";
            this.pcBox_Movie.Size = new System.Drawing.Size(225, 291);
            this.pcBox_Movie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcBox_Movie.TabIndex = 0;
            this.pcBox_Movie.TabStop = false;
            // 
            // lbl_MovieName
            // 
            this.lbl_MovieName.AutoSize = true;
            this.lbl_MovieName.Location = new System.Drawing.Point(243, 12);
            this.lbl_MovieName.Name = "lbl_MovieName";
            this.lbl_MovieName.Size = new System.Drawing.Size(73, 13);
            this.lbl_MovieName.TabIndex = 1;
            this.lbl_MovieName.Text = "Movie Name: ";
            // 
            // lbl_Director
            // 
            this.lbl_Director.AutoSize = true;
            this.lbl_Director.Location = new System.Drawing.Point(243, 45);
            this.lbl_Director.Name = "lbl_Director";
            this.lbl_Director.Size = new System.Drawing.Size(61, 13);
            this.lbl_Director.TabIndex = 2;
            this.lbl_Director.Text = "Director(s): ";
            // 
            // lbl_Genre
            // 
            this.lbl_Genre.AutoSize = true;
            this.lbl_Genre.Location = new System.Drawing.Point(243, 78);
            this.lbl_Genre.Name = "lbl_Genre";
            this.lbl_Genre.Size = new System.Drawing.Size(53, 13);
            this.lbl_Genre.TabIndex = 3;
            this.lbl_Genre.Text = "Genre(s): ";
            // 
            // lbl_Detail
            // 
            this.lbl_Detail.AutoSize = true;
            this.lbl_Detail.Location = new System.Drawing.Point(243, 113);
            this.lbl_Detail.MaximumSize = new System.Drawing.Size(400, 190);
            this.lbl_Detail.MinimumSize = new System.Drawing.Size(400, 190);
            this.lbl_Detail.Name = "lbl_Detail";
            this.lbl_Detail.Size = new System.Drawing.Size(400, 190);
            this.lbl_Detail.TabIndex = 4;
            this.lbl_Detail.Text = "Detail: ";
            // 
            // formMovieDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 315);
            this.Controls.Add(this.lbl_Detail);
            this.Controls.Add(this.lbl_Genre);
            this.Controls.Add(this.lbl_Director);
            this.Controls.Add(this.lbl_MovieName);
            this.Controls.Add(this.pcBox_Movie);
            this.Name = "formMovieDetail";
            this.Text = "Movie Detail";
            this.Load += new System.EventHandler(this.formMovieDetail_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.formMovieDetail_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pcBox_Movie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcBox_Movie;
        private System.Windows.Forms.Label lbl_MovieName;
        private System.Windows.Forms.Label lbl_Director;
        private System.Windows.Forms.Label lbl_Genre;
        private System.Windows.Forms.Label lbl_Detail;
    }
}