namespace ClientApp
{
    partial class CartScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label labelTitle;
        private Label labelSubtitle;
        private DataGridView dataGridViewCart;
        private Button btnRemove;
        private Button btnBack;
        private Panel panelCartSummary;
        private Label labelSubtotalText;
        private TextBox textBoxSubtotal;
        private Label labelTotalText;
        private TextBox textBoxTotal;
        private Button btnCheckout;

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
            labelTitle = new Label();
            labelSubtitle = new Label();
            dataGridViewCart = new DataGridView();
            btnRemove = new Button();
            btnBack = new Button();
            panelCartSummary = new Panel();
            labelTotalText = new Label();
            textBoxTotal = new TextBox();
            btnCheckout = new Button();
            colSelect = new DataGridViewCheckBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colUnitPrice = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colSubTotal = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCart).BeginInit();
            panelCartSummary.SuspendLayout();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(51, 51, 51);
            labelTitle.Location = new Point(25, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(223, 41);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Shopping Cart";
            // 
            // labelSubtitle
            // 
            labelSubtitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelSubtitle.AutoSize = true;
            labelSubtitle.Font = new Font("Segoe UI", 10F);
            labelSubtitle.ForeColor = Color.FromArgb(100, 100, 100);
            labelSubtitle.Location = new Point(25, 51);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(248, 23);
            labelSubtitle.TabIndex = 1;
            labelSubtitle.Text = "Review and manage your items";
            // 
            // dataGridViewCart
            // 
            dataGridViewCart.AllowUserToAddRows = false;
            dataGridViewCart.AllowUserToDeleteRows = false;
            dataGridViewCart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCart.BackgroundColor = Color.White;
            dataGridViewCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCart.Columns.AddRange(new DataGridViewColumn[] { colSelect, colProductName, colUnitPrice, colQuantity, colSubTotal });
            dataGridViewCart.Location = new Point(25, 75);
            dataGridViewCart.Name = "dataGridViewCart";
            dataGridViewCart.RowHeadersVisible = false;
            dataGridViewCart.RowHeadersWidth = 51;
            dataGridViewCart.Size = new Size(857, 372);
            dataGridViewCart.TabIndex = 2;
            dataGridViewCart.CellContentClick += dataGridViewCart_CellContentClick;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRemove.BackColor = Color.FromArgb(244, 67, 54);
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe UI", 10F);
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(25, 455);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(123, 41);
            btnRemove.TabIndex = 3;
            btnRemove.Text = "🗑 Remove";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += BtnRemove_Click;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBack.BackColor = Color.FromArgb(200, 200, 200);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(155, 455);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(104, 41);
            btnBack.TabIndex = 4;
            btnBack.Text = "← Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += BtnBack_Click;
            // 
            // panelCartSummary
            // 
            panelCartSummary.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panelCartSummary.BackColor = Color.FromArgb(240, 240, 240);
            panelCartSummary.BorderStyle = BorderStyle.FixedSingle;
            panelCartSummary.Controls.Add(labelTotalText);
            panelCartSummary.Controls.Add(textBoxTotal);
            panelCartSummary.Location = new Point(669, 503);
            panelCartSummary.Name = "panelCartSummary";
            panelCartSummary.Size = new Size(213, 48);
            panelCartSummary.TabIndex = 5;
            panelCartSummary.Paint += panelCartSummary_Paint;
            // 
            // labelTotalText
            // 
            labelTotalText.AutoSize = true;
            labelTotalText.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelTotalText.Location = new Point(3, 11);
            labelTotalText.Name = "labelTotalText";
            labelTotalText.Size = new Size(60, 25);
            labelTotalText.TabIndex = 2;
            labelTotalText.Text = "Total:";
            labelTotalText.Click += labelTotalText_Click;
            // 
            // textBoxTotal
            // 
            textBoxTotal.BackColor = Color.FromArgb(70, 130, 180);
            textBoxTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            textBoxTotal.ForeColor = Color.White;
            textBoxTotal.Location = new Point(61, 8);
            textBoxTotal.Name = "textBoxTotal";
            textBoxTotal.ReadOnly = true;
            textBoxTotal.Size = new Size(147, 32);
            textBoxTotal.TabIndex = 3;
            textBoxTotal.Text = "$0.00";
            textBoxTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // btnCheckout
            // 
            btnCheckout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCheckout.BackColor = Color.FromArgb(76, 175, 80);
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Location = new Point(669, 557);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(214, 43);
            btnCheckout.TabIndex = 6;
            btnCheckout.Text = "Proceed to Checkout →";
            btnCheckout.UseVisualStyleBackColor = false;
            btnCheckout.Click += BtnCheckout_Click;
            // 
            // colSelect
            // 
            colSelect.DataPropertyName = "Selected";
            colSelect.HeaderText = "✓";
            colSelect.MinimumWidth = 50;
            colSelect.Name = "colSelect";
            colSelect.Width = 50;
            // 
            // colProductName
            // 
            colProductName.DataPropertyName = "ProductName";
            colProductName.HeaderText = "Product";
            colProductName.MinimumWidth = 150;
            colProductName.Name = "colProductName";
            colProductName.ReadOnly = true;
            colProductName.Width = 250;
            // 
            // colUnitPrice
            // 
            colUnitPrice.DataPropertyName = "UnitPrice";
            colUnitPrice.HeaderText = "Unit Price";
            colUnitPrice.MinimumWidth = 100;
            colUnitPrice.Name = "colUnitPrice";
            colUnitPrice.ReadOnly = true;
            colUnitPrice.Width = 120;
            // 
            // colQuantity
            // 
            colQuantity.DataPropertyName = "Quantity";
            colQuantity.HeaderText = "Quantity";
            colQuantity.MinimumWidth = 60;
            colQuantity.Name = "colQuantity";
            colQuantity.Width = 80;
            // 
            // colSubTotal
            // 
            colSubTotal.DataPropertyName = "SubTotal";
            colSubTotal.HeaderText = "Subtotal";
            colSubTotal.MinimumWidth = 100;
            colSubTotal.Name = "colSubTotal";
            colSubTotal.ReadOnly = true;
            colSubTotal.Width = 120;
            // 
            // CartScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 615);
            Controls.Add(labelTitle);
            Controls.Add(labelSubtitle);
            Controls.Add(dataGridViewCart);
            Controls.Add(btnRemove);
            Controls.Add(btnBack);
            Controls.Add(panelCartSummary);
            Controls.Add(btnCheckout);
            MinimumSize = new Size(912, 651);
            Name = "CartScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Shopping Cart";
            ((System.ComponentModel.ISupportInitialize)dataGridViewCart).EndInit();
            panelCartSummary.ResumeLayout(false);
            panelCartSummary.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridViewCheckBoxColumn colSelect;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colUnitPrice;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colSubTotal;
    }
}