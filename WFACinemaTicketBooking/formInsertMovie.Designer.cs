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
            this.cb_MovieGenre = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rTxt_Description = new System.Windows.Forms.RichTextBox();
            this.txt_Movie = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Director = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Insert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb_MovieGenre
            // 
            this.cb_MovieGenre.FormattingEnabled = true;
            this.cb_MovieGenre.Location = new System.Drawing.Point(131, 79);
            this.cb_MovieGenre.Name = "cb_MovieGenre";
            this.cb_MovieGenre.Size = new System.Drawing.Size(296, 21);
            this.cb_MovieGenre.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(44, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 18);
            this.label2.TabIndex = 39;
            this.label2.Text = "Description :";
            // 
            // rTxt_Description
            // 
            this.rTxt_Description.Location = new System.Drawing.Point(131, 111);
            this.rTxt_Description.Name = "rTxt_Description";
            this.rTxt_Description.Size = new System.Drawing.Size(386, 184);
            this.rTxt_Description.TabIndex = 4;
            this.rTxt_Description.Text = "";
            // 
            // txt_Movie
            // 
            this.txt_Movie.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_Movie.Location = new System.Drawing.Point(131, 25);
            this.txt_Movie.Name = "txt_Movie";
            this.txt_Movie.Size = new System.Drawing.Size(296, 21);
            this.txt_Movie.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(75, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 18);
            this.label6.TabIndex = 36;
            this.label6.Text = "Genre :";
            // 
            // txt_Director
            // 
            this.txt_Director.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_Director.Location = new System.Drawing.Point(131, 52);
            this.txt_Director.Name = "txt_Director";
            this.txt_Director.Size = new System.Drawing.Size(296, 21);
            this.txt_Director.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(62, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 18);
            this.label5.TabIndex = 34;
            this.label5.Text = "Director :";
            // 
            // btn_Insert
            // 
            this.btn_Insert.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_Insert.Location = new System.Drawing.Point(18, 301);
            this.btn_Insert.Name = "btn_Insert";
            this.btn_Insert.Size = new System.Drawing.Size(499, 43);
            this.btn_Insert.TabIndex = 5;
            this.btn_Insert.Text = "Insert the Movie";
            this.btn_Insert.UseVisualStyleBackColor = true;
            this.btn_Insert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(40, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 32;
            this.label1.Text = "Movie Name :";
            // 
            // formInsertMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 355);
            this.Controls.Add(this.cb_MovieGenre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rTxt_Description);
            this.Controls.Add(this.txt_Movie);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_Director);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_Insert);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formInsertMovie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insert a New Movie";
            this.Load += new System.EventHandler(this.formInsertMovie_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}