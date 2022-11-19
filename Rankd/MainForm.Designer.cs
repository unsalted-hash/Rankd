namespace Rankd
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.resultsGroupBox = new System.Windows.Forms.GroupBox();
            this.exportButton = new System.Windows.Forms.Button();
            this.resultsGridView = new System.Windows.Forms.DataGridView();
            this.IronStatusColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.UsernameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalLevelColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalExpColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usernamesGroupBox = new System.Windows.Forms.GroupBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.usersTextBox = new System.Windows.Forms.RichTextBox();
            this.contentPanel.SuspendLayout();
            this.resultsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGridView)).BeginInit();
            this.usernamesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.resultsGroupBox);
            this.contentPanel.Controls.Add(this.usernamesGroupBox);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(789, 449);
            this.contentPanel.TabIndex = 6;
            // 
            // resultsGroupBox
            // 
            this.resultsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsGroupBox.Controls.Add(this.exportButton);
            this.resultsGroupBox.Controls.Add(this.resultsGridView);
            this.resultsGroupBox.Location = new System.Drawing.Point(393, 12);
            this.resultsGroupBox.Name = "resultsGroupBox";
            this.resultsGroupBox.Size = new System.Drawing.Size(384, 425);
            this.resultsGroupBox.TabIndex = 7;
            this.resultsGroupBox.TabStop = false;
            this.resultsGroupBox.Text = "Results";
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.Location = new System.Drawing.Point(278, 396);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(100, 23);
            this.exportButton.TabIndex = 4;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // resultsGridView
            // 
            this.resultsGridView.AllowUserToAddRows = false;
            this.resultsGridView.AllowUserToDeleteRows = false;
            this.resultsGridView.AllowUserToOrderColumns = true;
            this.resultsGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.resultsGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.resultsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resultsGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            this.resultsGridView.Size = new System.Drawing.Size(372, 368);
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
            dataGridViewCellStyle3.Format = "N0";
            this.TotalLevelColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.TotalLevelColumn.HeaderText = "Total Level";
            this.TotalLevelColumn.Name = "TotalLevelColumn";
            this.TotalLevelColumn.ReadOnly = true;
            // 
            // TotalExpColumn
            // 
            dataGridViewCellStyle4.Format = "N0";
            this.TotalExpColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.TotalExpColumn.HeaderText = "Total Exp.";
            this.TotalExpColumn.Name = "TotalExpColumn";
            this.TotalExpColumn.ReadOnly = true;
            // 
            // usernamesGroupBox
            // 
            this.usernamesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usernamesGroupBox.Controls.Add(this.searchButton);
            this.usernamesGroupBox.Controls.Add(this.usersTextBox);
            this.usernamesGroupBox.Location = new System.Drawing.Point(12, 12);
            this.usernamesGroupBox.Name = "usernamesGroupBox";
            this.usernamesGroupBox.Size = new System.Drawing.Size(375, 425);
            this.usernamesGroupBox.TabIndex = 6;
            this.usernamesGroupBox.TabStop = false;
            this.usernamesGroupBox.Text = "Usernames";
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(269, 396);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(100, 23);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // usersTextBox
            // 
            this.usersTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersTextBox.Location = new System.Drawing.Point(6, 22);
            this.usersTextBox.Name = "usersTextBox";
            this.usersTextBox.Size = new System.Drawing.Size(363, 368);
            this.usersTextBox.TabIndex = 0;
            this.usersTextBox.Text = "Lynx Titan, Iron Hyger, UIM Paperbag, 5th hcim LUL";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 449);
            this.Controls.Add(this.contentPanel);
            this.MinimumSize = new System.Drawing.Size(720, 420);
            this.Name = "MainForm";
            this.Text = "Rankd";
            this.contentPanel.ResumeLayout(false);
            this.resultsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultsGridView)).EndInit();
            this.usernamesGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel contentPanel;
        private GroupBox resultsGroupBox;
        private Button exportButton;
        private DataGridView resultsGridView;
        private DataGridViewImageColumn IronStatusColumn;
        private DataGridViewTextBoxColumn UsernameColumn;
        private DataGridViewTextBoxColumn TotalLevelColumn;
        private DataGridViewTextBoxColumn TotalExpColumn;
        private GroupBox usernamesGroupBox;
        private Button searchButton;
        private RichTextBox usersTextBox;
    }
}