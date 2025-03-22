namespace WFACinemaTicketBooking
{
    partial class formLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLogin));
            txt_Password = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txt_Email = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            btn_Login = new System.Windows.Forms.Button();
            btn_Register = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // txt_Password
            // 
            txt_Password.Location = new System.Drawing.Point(160, 67);
            txt_Password.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txt_Password.Name = "txt_Password";
            txt_Password.Size = new System.Drawing.Size(170, 23);
            txt_Password.TabIndex = 2;
            txt_Password.KeyDown += txt_Password_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(70, 69);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(67, 18);
            label3.TabIndex = 8;
            label3.Text = "Password :";
            // 
            // txt_Email
            // 
            txt_Email.Location = new System.Drawing.Point(160, 37);
            txt_Email.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txt_Email.Name = "txt_Email";
            txt_Email.Size = new System.Drawing.Size(170, 23);
            txt_Email.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            label4.Location = new System.Drawing.Point(44, 38);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(93, 18);
            label4.TabIndex = 6;
            label4.Text = "Email address :";
            // 
            // btn_Login
            // 
            btn_Login.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            btn_Login.Location = new System.Drawing.Point(14, 111);
            btn_Login.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new System.Drawing.Size(369, 46);
            btn_Login.TabIndex = 3;
            btn_Login.Text = "Login";
            btn_Login.UseVisualStyleBackColor = true;
            btn_Login.Click += btn_Login_Click;
            // 
            // btn_Register
            // 
            btn_Register.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            btn_Register.Location = new System.Drawing.Point(14, 164);
            btn_Register.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Register.Name = "btn_Register";
            btn_Register.Size = new System.Drawing.Size(369, 46);
            btn_Register.TabIndex = 4;
            btn_Register.Text = "Register";
            btn_Register.UseVisualStyleBackColor = true;
            btn_Register.Click += btn_Register_Click;
            // 
            // formLogin
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(397, 219);
            Controls.Add(btn_Register);
            Controls.Add(txt_Password);
            Controls.Add(label3);
            Controls.Add(txt_Email);
            Controls.Add(label4);
            Controls.Add(btn_Login);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");           
            Name = "formLogin";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Movie Booking System Login";
            Load += formLogin_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Button btn_Register;
    }
}