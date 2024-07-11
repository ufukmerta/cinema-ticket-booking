namespace WFACinemaTicketBooking
{
    partial class formCreateSession
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCreateSession));
            this.cb_Session20 = new System.Windows.Forms.CheckBox();
            this.cb_Movie = new System.Windows.Forms.ComboBox();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_Session18 = new System.Windows.Forms.CheckBox();
            this.cb_Session16 = new System.Windows.Forms.CheckBox();
            this.cb_Session14 = new System.Windows.Forms.CheckBox();
            this.cb_Session12 = new System.Windows.Forms.CheckBox();
            this.cb_Session10 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_Hall = new System.Windows.Forms.ComboBox();
            this.btn_InsertSessions = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb_Session20
            // 
            this.cb_Session20.AutoSize = true;
            this.cb_Session20.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.cb_Session20.Location = new System.Drawing.Point(261, 157);
            this.cb_Session20.Name = "cb_Session20";
            this.cb_Session20.Size = new System.Drawing.Size(54, 20);
            this.cb_Session20.TabIndex = 42;
            this.cb_Session20.Text = "20:00";
            this.cb_Session20.UseVisualStyleBackColor = true;
            // 
            // cb_Movie
            // 
            this.cb_Movie.FormattingEnabled = true;
            this.cb_Movie.Location = new System.Drawing.Point(131, 30);
            this.cb_Movie.Name = "cb_Movie";
            this.cb_Movie.Size = new System.Drawing.Size(191, 21);
            this.cb_Movie.TabIndex = 1;
            this.cb_Movie.SelectedValueChanged += new System.EventHandler(this.cb_Movie_SelectedValueChanged);
            // 
            // dtp
            // 
            this.dtp.Location = new System.Drawing.Point(131, 57);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(191, 20);
            this.dtp.TabIndex = 2;
            this.dtp.Value = new System.DateTime(2024, 5, 1, 0, 0, 0, 0);
            this.dtp.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(72, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 18);
            this.label4.TabIndex = 39;
            this.label4.Text = "Date :";
            // 
            // cb_Session18
            // 
            this.cb_Session18.AutoSize = true;
            this.cb_Session18.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.cb_Session18.Location = new System.Drawing.Point(196, 157);
            this.cb_Session18.Name = "cb_Session18";
            this.cb_Session18.Size = new System.Drawing.Size(54, 20);
            this.cb_Session18.TabIndex = 38;
            this.cb_Session18.Text = "18:00";
            this.cb_Session18.UseVisualStyleBackColor = true;
            // 
            // cb_Session16
            // 
            this.cb_Session16.AutoSize = true;
            this.cb_Session16.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.cb_Session16.Location = new System.Drawing.Point(131, 157);
            this.cb_Session16.Name = "cb_Session16";
            this.cb_Session16.Size = new System.Drawing.Size(54, 20);
            this.cb_Session16.TabIndex = 37;
            this.cb_Session16.Text = "16:00";
            this.cb_Session16.UseVisualStyleBackColor = true;
            // 
            // cb_Session14
            // 
            this.cb_Session14.AutoSize = true;
            this.cb_Session14.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.cb_Session14.Location = new System.Drawing.Point(261, 129);
            this.cb_Session14.Name = "cb_Session14";
            this.cb_Session14.Size = new System.Drawing.Size(54, 20);
            this.cb_Session14.TabIndex = 36;
            this.cb_Session14.Text = "14:00";
            this.cb_Session14.UseVisualStyleBackColor = true;
            // 
            // cb_Session12
            // 
            this.cb_Session12.AutoSize = true;
            this.cb_Session12.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.cb_Session12.Location = new System.Drawing.Point(196, 129);
            this.cb_Session12.Name = "cb_Session12";
            this.cb_Session12.Size = new System.Drawing.Size(54, 20);
            this.cb_Session12.TabIndex = 35;
            this.cb_Session12.Text = "12:00";
            this.cb_Session12.UseVisualStyleBackColor = true;
            // 
            // cb_Session10
            // 
            this.cb_Session10.AutoSize = true;
            this.cb_Session10.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.cb_Session10.Location = new System.Drawing.Point(131, 129);
            this.cb_Session10.Name = "cb_Session10";
            this.cb_Session10.Size = new System.Drawing.Size(54, 20);
            this.cb_Session10.TabIndex = 34;
            this.cb_Session10.Text = "10:00";
            this.cb_Session10.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(57, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 33;
            this.label3.Text = "Session :";
            // 
            // cb_Hall
            // 
            this.cb_Hall.FormattingEnabled = true;
            this.cb_Hall.Location = new System.Drawing.Point(131, 83);
            this.cb_Hall.Name = "cb_Hall";
            this.cb_Hall.Size = new System.Drawing.Size(191, 21);
            this.cb_Hall.TabIndex = 3;
            this.cb_Hall.SelectedValueChanged += new System.EventHandler(this.cb_Hall_SelectedValueChanged);
            // 
            // btn_InsertSessions
            // 
            this.btn_InsertSessions.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_InsertSessions.Location = new System.Drawing.Point(12, 183);
            this.btn_InsertSessions.Name = "btn_InsertSessions";
            this.btn_InsertSessions.Size = new System.Drawing.Size(349, 50);
            this.btn_InsertSessions.TabIndex = 43;
            this.btn_InsertSessions.Text = "Insert the Movie Session(s)";
            this.btn_InsertSessions.UseVisualStyleBackColor = true;
            this.btn_InsertSessions.Click += new System.EventHandler(this.btn_InsertSessions_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(76, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 18);
            this.label2.TabIndex = 30;
            this.label2.Text = "Hall :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(29, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 29;
            this.label1.Text = "Movie Name :";
            // 
            // formCreateSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 247);
            this.Controls.Add(this.cb_Session20);
            this.Controls.Add(this.cb_Movie);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_Session18);
            this.Controls.Add(this.cb_Session16);
            this.Controls.Add(this.cb_Session14);
            this.Controls.Add(this.cb_Session12);
            this.Controls.Add(this.cb_Session10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_Hall);
            this.Controls.Add(this.btn_InsertSessions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formCreateSession";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Movie Session";
            this.Load += new System.EventHandler(this.formCreateSession_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_Session20;
        private System.Windows.Forms.ComboBox cb_Movie;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_Session18;
        private System.Windows.Forms.CheckBox cb_Session16;
        private System.Windows.Forms.CheckBox cb_Session14;
        private System.Windows.Forms.CheckBox cb_Session12;
        private System.Windows.Forms.CheckBox cb_Session10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_Hall;
        private System.Windows.Forms.Button btn_InsertSessions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}