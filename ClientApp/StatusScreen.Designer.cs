namespace ClientApp
{
    partial class StatusScreen
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
            btnBack = new Button();
            labelTitle = new Label();
            labelSubtitle = new Label();
            dataGridViewStatus = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStatus).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBack.BackColor = Color.FromArgb(200, 200, 200);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(674, 414);
            btnBack.Margin = new Padding(3, 2, 3, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(91, 31);
            btnBack.TabIndex = 13;
            btnBack.Text = "← Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click_1;
            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(51, 51, 51);
            labelTitle.Location = new Point(22, 9);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(83, 32);
            labelTitle.TabIndex = 14;
            labelTitle.Text = "Status";
            // 
            // labelSubtitle
            // 
            labelSubtitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelSubtitle.AutoSize = true;
            labelSubtitle.Font = new Font("Segoe UI", 10F);
            labelSubtitle.ForeColor = Color.FromArgb(100, 100, 100);
            labelSubtitle.Location = new Point(22, 36);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(166, 19);
            labelSubtitle.TabIndex = 15;
            labelSubtitle.Text = "Show your delivery status";
            labelSubtitle.Click += labelSubtitle_Click;
            // 
            // dataGridViewStatus
            // 
            dataGridViewStatus.BackgroundColor = Color.White;
            dataGridViewStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStatus.Location = new Point(22, 58);
            dataGridViewStatus.Name = "dataGridViewStatus";
            dataGridViewStatus.Size = new Size(741, 345);
            dataGridViewStatus.TabIndex = 16;
            // 
            // StatusScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 461);
            Controls.Add(dataGridViewStatus);
            Controls.Add(labelTitle);
            Controls.Add(labelSubtitle);
            Controls.Add(btnBack);
            MinimumSize = new Size(800, 500);
            Name = "StatusScreen";
            Text = "StatusScreen";
            Load += StatusScreen_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewStatus).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnBack;
        private Label labelTitle;
        private Label labelSubtitle;
        private DataGridView dataGridViewStatus;
    }
}