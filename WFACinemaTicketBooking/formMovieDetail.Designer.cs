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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMovieDetail));
            panel1 = new System.Windows.Forms.Panel();
            pcBox_Movie = new System.Windows.Forms.PictureBox();
            panel2 = new System.Windows.Forms.Panel();
            lbl_Detail = new System.Windows.Forms.Label();
            lbl_Genre = new System.Windows.Forms.Label();
            lbl_Director = new System.Windows.Forms.Label();
            lbl_MovieName = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcBox_Movie).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.BackColor = System.Drawing.SystemColors.Control;
            panel1.Controls.Add(pcBox_Movie);
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(270, 361);
            panel1.TabIndex = 5;
            // 
            // pcBox_Movie
            // 
            pcBox_Movie.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pcBox_Movie.Location = new System.Drawing.Point(0, 0);
            pcBox_Movie.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pcBox_Movie.Name = "pcBox_Movie";
            pcBox_Movie.Size = new System.Drawing.Size(269, 361);
            pcBox_Movie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pcBox_Movie.TabIndex = 1;
            pcBox_Movie.TabStop = false;
            // 
            // panel2
            // 
            panel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            panel2.BackColor = System.Drawing.SystemColors.Control;
            panel2.Controls.Add(lbl_Detail);
            panel2.Controls.Add(lbl_Genre);
            panel2.Controls.Add(lbl_Director);
            panel2.Controls.Add(lbl_MovieName);
            panel2.Location = new System.Drawing.Point(276, 0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(508, 361);
            panel2.TabIndex = 6;
            // 
            // lbl_Detail
            // 
            lbl_Detail.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lbl_Detail.AutoSize = true;
            lbl_Detail.Location = new System.Drawing.Point(15, 130);
            lbl_Detail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Detail.MaximumSize = new System.Drawing.Size(467, 219);
            lbl_Detail.MinimumSize = new System.Drawing.Size(467, 219);
            lbl_Detail.Name = "lbl_Detail";
            lbl_Detail.Size = new System.Drawing.Size(467, 219);
            lbl_Detail.TabIndex = 8;
            lbl_Detail.Text = "Detail: ";
            // 
            // lbl_Genre
            // 
            lbl_Genre.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lbl_Genre.AutoSize = true;
            lbl_Genre.Location = new System.Drawing.Point(15, 89);
            lbl_Genre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Genre.Name = "lbl_Genre";
            lbl_Genre.Size = new System.Drawing.Size(57, 15);
            lbl_Genre.TabIndex = 7;
            lbl_Genre.Text = "Genre(s): ";
            // 
            // lbl_Director
            // 
            lbl_Director.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lbl_Director.AutoSize = true;
            lbl_Director.Location = new System.Drawing.Point(15, 51);
            lbl_Director.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Director.Name = "lbl_Director";
            lbl_Director.Size = new System.Drawing.Size(68, 15);
            lbl_Director.TabIndex = 6;
            lbl_Director.Text = "Director(s): ";
            // 
            // lbl_MovieName
            // 
            lbl_MovieName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lbl_MovieName.AutoSize = true;
            lbl_MovieName.Location = new System.Drawing.Point(15, 13);
            lbl_MovieName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_MovieName.Name = "lbl_MovieName";
            lbl_MovieName.Size = new System.Drawing.Size(81, 15);
            lbl_MovieName.TabIndex = 5;
            lbl_MovieName.Text = "Movie Name: ";
            // 
            // formMovieDetail
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(784, 361);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(800, 400);
            Name = "formMovieDetail";
            Text = "Movie Detail";
            Load += formMovieDetail_Load;
            SizeChanged += formMovieDetail_SizeChanged;
            KeyUp += formMovieDetail_KeyUp;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pcBox_Movie).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_Detail;
        private System.Windows.Forms.Label lbl_Genre;
        private System.Windows.Forms.Label lbl_Director;
        private System.Windows.Forms.Label lbl_MovieName;
        private System.Windows.Forms.PictureBox pcBox_Movie;
    }
}