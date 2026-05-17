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
            btnStatusRefresh = new Button();
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
            btnBack.Location = new Point(921, 550);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(104, 41);
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
            labelTitle.Location = new Point(25, 12);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(105, 41);
            labelTitle.TabIndex = 14;
            labelTitle.Text = "Status";
            // 
            // labelSubtitle
            // 
            labelSubtitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelSubtitle.AutoSize = true;
            labelSubtitle.Font = new Font("Segoe UI", 10F);
            labelSubtitle.ForeColor = Color.FromArgb(100, 100, 100);
            labelSubtitle.Location = new Point(25, 48);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(203, 23);
            labelSubtitle.TabIndex = 15;
            labelSubtitle.Text = "Show your delivery status";
            labelSubtitle.Click += labelSubtitle_Click;
            // 
            // dataGridViewStatus
            // 
            dataGridViewStatus.BackgroundColor = Color.White;
            dataGridViewStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStatus.Location = new Point(25, 77);
            dataGridViewStatus.Margin = new Padding(3, 4, 3, 4);
            dataGridViewStatus.Name = "dataGridViewStatus";
            dataGridViewStatus.RowHeadersWidth = 51;
            dataGridViewStatus.Size = new Size(1000, 460);
            dataGridViewStatus.TabIndex = 16;
            // 
            // btnStatusRefresh
            // 
            btnStatusRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStatusRefresh.BackColor = Color.FromArgb(70, 130, 180);
            btnStatusRefresh.FlatStyle = FlatStyle.Flat;
            btnStatusRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnStatusRefresh.ForeColor = Color.White;
            btnStatusRefresh.Location = new Point(793, 550);
            btnStatusRefresh.Name = "btnStatusRefresh";
            btnStatusRefresh.Size = new Size(109, 43);
            btnStatusRefresh.TabIndex = 17;
            btnStatusRefresh.Text = "🔄 Refresh";
            btnStatusRefresh.UseVisualStyleBackColor = false;
            btnStatusRefresh.Click += btnStatusRefresh_Click;
            // 
            // StatusScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1052, 615);
            Controls.Add(btnStatusRefresh);
            Controls.Add(dataGridViewStatus);
            Controls.Add(labelTitle);
            Controls.Add(labelSubtitle);
            Controls.Add(btnBack);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(912, 651);
            Name = "StatusScreen";
            Text = "StatusScreen";
            Activated += StatusScreen_Activated;
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
        private Button btnStatusRefresh;
    }
}