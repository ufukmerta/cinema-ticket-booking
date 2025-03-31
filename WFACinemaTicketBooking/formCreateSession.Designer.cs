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
            cb_Movie = new System.Windows.Forms.ComboBox();
            dtp = new System.Windows.Forms.DateTimePicker();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            cb_Hall = new System.Windows.Forms.ComboBox();
            btn_InsertSessions = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            dgv_Sessions = new System.Windows.Forms.DataGridView();
            cb_Session = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            session_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            hour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgv_Sessions).BeginInit();
            SuspendLayout();
            // 
            // cb_Movie
            // 
            cb_Movie.FormattingEnabled = true;
            cb_Movie.Location = new System.Drawing.Point(153, 35);
            cb_Movie.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_Movie.Name = "cb_Movie";
            cb_Movie.Size = new System.Drawing.Size(222, 23);
            cb_Movie.TabIndex = 1;
            cb_Movie.SelectedValueChanged += cb_Movie_SelectedValueChanged;
            // 
            // dtp
            // 
            dtp.Location = new System.Drawing.Point(153, 66);
            dtp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dtp.Name = "dtp";
            dtp.Size = new System.Drawing.Size(222, 23);
            dtp.TabIndex = 2;
            dtp.Value = new System.DateTime(2024, 5, 1, 0, 0, 0, 0);
            dtp.ValueChanged += dtp_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            label4.Location = new System.Drawing.Point(84, 68);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(42, 18);
            label4.TabIndex = 39;
            label4.Text = "Date :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            label3.Location = new System.Drawing.Point(69, 128);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(57, 18);
            label3.TabIndex = 33;
            label3.Text = "Session :";
            // 
            // cb_Hall
            // 
            cb_Hall.FormattingEnabled = true;
            cb_Hall.Location = new System.Drawing.Point(153, 97);
            cb_Hall.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_Hall.Name = "cb_Hall";
            cb_Hall.Size = new System.Drawing.Size(222, 23);
            cb_Hall.TabIndex = 3;
            cb_Hall.SelectedValueChanged += cb_Hall_SelectedValueChanged;
            // 
            // btn_InsertSessions
            // 
            btn_InsertSessions.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            btn_InsertSessions.Location = new System.Drawing.Point(15, 251);
            btn_InsertSessions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_InsertSessions.Name = "btn_InsertSessions";
            btn_InsertSessions.Size = new System.Drawing.Size(406, 58);
            btn_InsertSessions.TabIndex = 43;
            btn_InsertSessions.Text = "Insert the Movie Session(s)";
            btn_InsertSessions.UseVisualStyleBackColor = true;
            btn_InsertSessions.Click += btn_InsertSessions_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            label2.Location = new System.Drawing.Point(88, 99);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(38, 18);
            label2.TabIndex = 30;
            label2.Text = "Hall :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            label1.Location = new System.Drawing.Point(41, 37);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(85, 18);
            label1.TabIndex = 29;
            label1.Text = "Movie Name :";
            // 
            // dgv_Sessions
            // 
            dgv_Sessions.AllowUserToAddRows = false;
            dgv_Sessions.AllowUserToDeleteRows = false;
            dgv_Sessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Sessions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { cb_Session, session_id, hour });
            dgv_Sessions.Location = new System.Drawing.Point(154, 128);
            dgv_Sessions.Name = "dgv_Sessions";
            dgv_Sessions.RowHeadersVisible = false;
            dgv_Sessions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv_Sessions.Size = new System.Drawing.Size(221, 113);
            dgv_Sessions.TabIndex = 44;
            // 
            // cb_Session
            // 
            cb_Session.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            cb_Session.HeaderText = "Chosen";
            cb_Session.Name = "cb_Session";
            cb_Session.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            cb_Session.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            cb_Session.Width = 72;
            // 
            // session_id
            // 
            session_id.DataPropertyName = "SessionId";
            session_id.HeaderText = "SessionId";
            session_id.Name = "session_id";
            session_id.ReadOnly = true;
            session_id.Visible = false;
            // 
            // hour
            // 
            hour.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            hour.DataPropertyName = "Hour";
            hour.HeaderText = "Session Hour";
            hour.MaxInputLength = 5;
            hour.Name = "hour";
            hour.ReadOnly = true;
            // 
            // formCreateSession
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(434, 321);
            Controls.Add(dgv_Sessions);
            Controls.Add(cb_Movie);
            Controls.Add(dtp);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cb_Hall);
            Controls.Add(btn_InsertSessions);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "formCreateSession";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Create Movie Session";
            Load += formCreateSession_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Sessions).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cb_Movie;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_Hall;
        private System.Windows.Forms.Button btn_InsertSessions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Sessions;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cb_Session;
        private System.Windows.Forms.DataGridViewTextBoxColumn session_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn hour;
    }
}