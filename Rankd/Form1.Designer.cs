namespace Rankd
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.usersTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.resultsGridView = new System.Windows.Forms.DataGridView();
            this.IronStatusColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.UsernameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalLevelColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalExpColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // usersTextBox
            // 
            this.usersTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersTextBox.Location = new System.Drawing.Point(6, 22);
            this.usersTextBox.Name = "usersTextBox";
            this.usersTextBox.Size = new System.Drawing.Size(278, 338);
            this.usersTextBox.TabIndex = 0;
            this.usersTextBox.Text = "Lynx Titan, Iron Hyger, UIM Paperbag, 5th hcim LUL";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.searchButton);
            this.groupBox1.Controls.Add(this.usersTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 395);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usernames";
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(204, 366);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(80, 23);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.UserSearchButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.resultsGridView);
            this.groupBox3.Location = new System.Drawing.Point(308, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(384, 395);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Results";
            // 
            // resultsGridView
            // 
            this.resultsGridView.AllowUserToAddRows = false;
            this.resultsGridView.AllowUserToDeleteRows = false;
            this.resultsGridView.AllowUserToOrderColumns = true;
            this.resultsGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.resultsGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.resultsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resultsGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.resultsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IronStatusColumn,
            this.UsernameColumn,
            this.TotalLevelColumn,
            this.TotalExpColumn});
            this.resultsGridView.Location = new System.Drawing.Point(6, 22);
            this.resultsGridView.Name = "resultsGridView";
            this.resultsGridView.ReadOnly = true;
            this.resultsGridView.RowHeadersVisible = false;
            this.resultsGridView.RowTemplate.Height = 25;
            this.resultsGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultsGridView.Size = new System.Drawing.Size(372, 367);
            this.resultsGridView.TabIndex = 0;
            // 
            // IronStatusColumn
            // 
            this.IronStatusColumn.HeaderText = "";
            this.IronStatusColumn.Name = "IronStatusColumn";
            this.IronStatusColumn.ReadOnly = true;
            this.IronStatusColumn.Width = 32;
            // 
            // UsernameColumn
            // 
            this.UsernameColumn.HeaderText = "Name";
            this.UsernameColumn.Name = "UsernameColumn";
            this.UsernameColumn.ReadOnly = true;
            this.UsernameColumn.Width = 120;
            // 
            // TotalLevelColumn
            // 
            dataGridViewCellStyle7.Format = "N0";
            this.TotalLevelColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.TotalLevelColumn.HeaderText = "Total Level";
            this.TotalLevelColumn.Name = "TotalLevelColumn";
            this.TotalLevelColumn.ReadOnly = true;
            // 
            // TotalExpColumn
            // 
            dataGridViewCellStyle8.Format = "N0";
            this.TotalExpColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.TotalExpColumn.HeaderText = "Total Exp.";
            this.TotalExpColumn.Name = "TotalExpColumn";
            this.TotalExpColumn.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 419);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(720, 420);
            this.Name = "Form1";
            this.Text = "Rankd";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox usersTextBox;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private Button searchButton;
        private DataGridView resultsGridView;
        private DataGridViewImageColumn IronStatusColumn;
        private DataGridViewTextBoxColumn UsernameColumn;
        private DataGridViewTextBoxColumn TotalLevelColumn;
        private DataGridViewTextBoxColumn TotalExpColumn;
    }
}