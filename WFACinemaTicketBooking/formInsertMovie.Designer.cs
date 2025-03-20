namespace WFACinemaTicketBooking
{
    partial class formInsertMovie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formInsertMovie));
            cb_MovieGenre = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            rTxt_Description = new System.Windows.Forms.RichTextBox();
            txt_Movie = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            txt_Director = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            btn_Insert = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            txt_ImgUrl = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // cb_MovieGenre
            // 
            cb_MovieGenre.FormattingEnabled = true;
            cb_MovieGenre.Location = new System.Drawing.Point(153, 85);
            cb_MovieGenre.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_MovieGenre.Name = "cb_MovieGenre";
            cb_MovieGenre.Size = new System.Drawing.Size(345, 23);
            cb_MovieGenre.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            label2.Location = new System.Drawing.Point(51, 142);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(81, 18);
            label2.TabIndex = 39;
            label2.Text = "Description :";
            // 
            // rTxt_Description
            // 
            rTxt_Description.Location = new System.Drawing.Point(153, 141);
            rTxt_Description.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rTxt_Description.Name = "rTxt_Description";
            rTxt_Description.Size = new System.Drawing.Size(450, 212);
            rTxt_Description.TabIndex = 4;
            rTxt_Description.Text = "";
            // 
            // txt_Movie
            // 
            txt_Movie.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            txt_Movie.Location = new System.Drawing.Point(153, 23);
            txt_Movie.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txt_Movie.Name = "txt_Movie";
            txt_Movie.Size = new System.Drawing.Size(345, 21);
            txt_Movie.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            label6.Location = new System.Drawing.Point(88, 86);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(50, 18);
            label6.TabIndex = 36;
            label6.Text = "Genre :";
            // 
            // txt_Director
            // 
            txt_Director.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            txt_Director.Location = new System.Drawing.Point(153, 54);
            txt_Director.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txt_Director.Name = "txt_Director";
            txt_Director.Size = new System.Drawing.Size(345, 21);
            txt_Director.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            label5.Location = new System.Drawing.Point(72, 57);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(63, 18);
            label5.TabIndex = 34;
            label5.Text = "Director :";
            // 
            // btn_Insert
            // 
            btn_Insert.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            btn_Insert.Location = new System.Drawing.Point(21, 359);
            btn_Insert.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Insert.Name = "btn_Insert";
            btn_Insert.Size = new System.Drawing.Size(582, 50);
            btn_Insert.TabIndex = 5;
            btn_Insert.Text = "Insert the Movie";
            btn_Insert.UseVisualStyleBackColor = true;
            btn_Insert.Click += btnInsert_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            label1.Location = new System.Drawing.Point(47, 26);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(85, 18);
            label1.TabIndex = 32;
            label1.Text = "Movie Name :";
            // 
            // txt_ImgUrl
            // 
            txt_ImgUrl.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            txt_ImgUrl.Location = new System.Drawing.Point(153, 114);
            txt_ImgUrl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txt_ImgUrl.Name = "txt_ImgUrl";
            txt_ImgUrl.Size = new System.Drawing.Size(345, 21);
            txt_ImgUrl.TabIndex = 40;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            label3.Location = new System.Drawing.Point(72, 117);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(74, 18);
            label3.TabIndex = 41;
            label3.Text = "Image URL :";
            // 
            // formInsertMovie
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(624, 426);
            Controls.Add(txt_ImgUrl);
            Controls.Add(label3);
            Controls.Add(cb_MovieGenre);
            Controls.Add(label2);
            Controls.Add(rTxt_Description);
            Controls.Add(txt_Movie);
            Controls.Add(label6);
            Controls.Add(txt_Director);
            Controls.Add(label5);
            Controls.Add(btn_Insert);
            Controls.Add(label1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "formInsertMovie";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Insert a New Movie";
            Load += formInsertMovie_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_MovieGenre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rTxt_Description;
        private System.Windows.Forms.TextBox txt_Movie;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Director;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Insert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ImgUrl;
        private System.Windows.Forms.Label label3;
    }
}