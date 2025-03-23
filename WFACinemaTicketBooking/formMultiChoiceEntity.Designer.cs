namespace WFACinemaTicketBooking
{
    partial class formMultiChoiceEntity
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
            dgv_Choices = new System.Windows.Forms.DataGridView();
            btn_PassChosenEntities = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgv_Choices).BeginInit();
            SuspendLayout();
            // 
            // dgv_Choices
            // 
            dgv_Choices.AllowUserToAddRows = false;
            dgv_Choices.AllowUserToDeleteRows = false;
            dgv_Choices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Choices.Location = new System.Drawing.Point(12, 12);
            dgv_Choices.Name = "dgv_Choices";
            dgv_Choices.RowHeadersVisible = false;
            dgv_Choices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv_Choices.Size = new System.Drawing.Size(580, 380);
            dgv_Choices.TabIndex = 0;
            // 
            // btn_PassChosenEntities
            // 
            btn_PassChosenEntities.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            btn_PassChosenEntities.Location = new System.Drawing.Point(12, 400);
            btn_PassChosenEntities.Name = "btn_PassChosenEntities";
            btn_PassChosenEntities.Size = new System.Drawing.Size(580, 50);
            btn_PassChosenEntities.TabIndex = 1;
            btn_PassChosenEntities.Text = "Pass the Chosen {Entities}";
            btn_PassChosenEntities.UseVisualStyleBackColor = true;
            btn_PassChosenEntities.Click += btn_PassChosenEntities_Click;
            // 
            // formMultiChoiceEntity
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(605, 461);
            Controls.Add(btn_PassChosenEntities);
            Controls.Add(dgv_Choices);
            Name = "formMultiChoiceEntity";
            Text = "Choose {Entity}";
            Load += formMultiChoiceEntity_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Choices).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Choices;
        internal System.Windows.Forms.Button btn_PassChosenEntities;
    }
}