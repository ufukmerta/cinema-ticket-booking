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
            label1 = new System.Windows.Forms.Label();
            txt_Search = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)dgv_Choices).BeginInit();
            SuspendLayout();
            // 
            // dgv_Choices
            // 
            dgv_Choices.AllowUserToAddRows = false;
            dgv_Choices.AllowUserToDeleteRows = false;
            dgv_Choices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Choices.Location = new System.Drawing.Point(12, 35);
            dgv_Choices.Name = "dgv_Choices";
            dgv_Choices.RowHeadersVisible = false;
            dgv_Choices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv_Choices.Size = new System.Drawing.Size(580, 408);
            dgv_Choices.TabIndex = 0;
            dgv_Choices.CellEndEdit += dgv_Choices_CellEndEdit;
            // 
            // btn_PassChosenEntities
            // 
            btn_PassChosenEntities.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            btn_PassChosenEntities.Location = new System.Drawing.Point(12, 449);
            btn_PassChosenEntities.Name = "btn_PassChosenEntities";
            btn_PassChosenEntities.Size = new System.Drawing.Size(580, 50);
            btn_PassChosenEntities.TabIndex = 1;
            btn_PassChosenEntities.Text = "Pass the Chosen {Entities}";
            btn_PassChosenEntities.UseVisualStyleBackColor = true;
            btn_PassChosenEntities.Click += btn_PassChosenEntities_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(83, 15);
            label1.TabIndex = 2;
            label1.Text = "Search on List:";
            // 
            // txt_Search
            // 
            txt_Search.Location = new System.Drawing.Point(101, 6);
            txt_Search.Name = "txt_Search";
            txt_Search.PlaceholderText = "Type name to search";
            txt_Search.Size = new System.Drawing.Size(491, 23);
            txt_Search.TabIndex = 3;
            txt_Search.TextChanged += txt_Search_TextChanged;
            // 
            // formMultiChoiceEntity
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(605, 511);
            Controls.Add(txt_Search);
            Controls.Add(label1);
            Controls.Add(btn_PassChosenEntities);
            Controls.Add(dgv_Choices);
            Name = "formMultiChoiceEntity";
            Text = "Choose {Entity}";
            Load += formMultiChoiceEntity_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Choices).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Choices;
        internal System.Windows.Forms.Button btn_PassChosenEntities;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Search;
    }
}