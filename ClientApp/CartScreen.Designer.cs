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
        private DataGridViewCheckBoxColumn colSelect;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colUnitPrice;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colSubTotal;
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
            colSelect = new DataGridViewCheckBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colUnitPrice = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colSubTotal = new DataGridViewTextBoxColumn();
            btnRemove = new Button();
            btnBack = new Button();
            panelCartSummary = new Panel();
            labelSubtotalText = new Label();
            textBoxSubtotal = new TextBox();
            labelTotalText = new Label();
            textBoxTotal = new TextBox();
            btnCheckout = new Button();
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
            labelTitle.Location = new Point(22, 11);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(178, 32);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Shopping Cart";
            // 
            // labelSubtitle
            // 
            labelSubtitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelSubtitle.AutoSize = true;
            labelSubtitle.Font = new Font("Segoe UI", 10F);
            labelSubtitle.ForeColor = Color.FromArgb(100, 100, 100);
            labelSubtitle.Location = new Point(22, 38);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(200, 19);
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
            dataGridViewCart.Location = new Point(22, 56);
            dataGridViewCart.Margin = new Padding(3, 2, 3, 2);
            dataGridViewCart.Name = "dataGridViewCart";
            dataGridViewCart.RowHeadersVisible = false;
            dataGridViewCart.Size = new Size(750, 279);
            dataGridViewCart.TabIndex = 2;
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
            colQuantity.HeaderText = "Qty";
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
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRemove.BackColor = Color.FromArgb(244, 67, 54);
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe UI", 10F);
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(22, 341);
            btnRemove.Margin = new Padding(3, 2, 3, 2);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(108, 31);
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
            btnBack.Location = new Point(136, 341);
            btnBack.Margin = new Padding(3, 2, 3, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(91, 31);
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
            panelCartSummary.Controls.Add(labelSubtotalText);
            panelCartSummary.Controls.Add(textBoxSubtotal);
            panelCartSummary.Controls.Add(labelTotalText);
            panelCartSummary.Controls.Add(textBoxTotal);
            panelCartSummary.Location = new Point(585, 348);
            panelCartSummary.Margin = new Padding(3, 2, 3, 2);
            panelCartSummary.Name = "panelCartSummary";
            panelCartSummary.Size = new Size(187, 66);
            panelCartSummary.TabIndex = 5;
            // 
            // labelSubtotalText
            // 
            labelSubtotalText.AutoSize = true;
            labelSubtotalText.Font = new Font("Segoe UI", 9F);
            labelSubtotalText.Location = new Point(3, 8);
            labelSubtotalText.Name = "labelSubtotalText";
            labelSubtotalText.Size = new Size(54, 15);
            labelSubtotalText.TabIndex = 0;
            labelSubtotalText.Text = "Subtotal:";
            // 
            // textBoxSubtotal
            // 
            textBoxSubtotal.BackColor = Color.White;
            textBoxSubtotal.Font = new Font("Segoe UI", 9F);
            textBoxSubtotal.Location = new Point(53, 5);
            textBoxSubtotal.Margin = new Padding(3, 2, 3, 2);
            textBoxSubtotal.Name = "textBoxSubtotal";
            textBoxSubtotal.ReadOnly = true;
            textBoxSubtotal.Size = new Size(129, 23);
            textBoxSubtotal.TabIndex = 1;
            textBoxSubtotal.Text = "$0.00";
            textBoxSubtotal.TextAlign = HorizontalAlignment.Right;
            // 
            // labelTotalText
            // 
            labelTotalText.AutoSize = true;
            labelTotalText.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelTotalText.Location = new Point(3, 38);
            labelTotalText.Name = "labelTotalText";
            labelTotalText.Size = new Size(48, 20);
            labelTotalText.TabIndex = 2;
            labelTotalText.Text = "Total:";
            // 
            // textBoxTotal
            // 
            textBoxTotal.BackColor = Color.FromArgb(70, 130, 180);
            textBoxTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            textBoxTotal.ForeColor = Color.White;
            textBoxTotal.Location = new Point(53, 35);
            textBoxTotal.Margin = new Padding(3, 2, 3, 2);
            textBoxTotal.Name = "textBoxTotal";
            textBoxTotal.ReadOnly = true;
            textBoxTotal.Size = new Size(129, 27);
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
            btnCheckout.Location = new Point(585, 418);
            btnCheckout.Margin = new Padding(3, 2, 3, 2);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(187, 32);
            btnCheckout.TabIndex = 6;
            btnCheckout.Text = "Proceed to Checkout →";
            btnCheckout.UseVisualStyleBackColor = false;
            btnCheckout.Click += BtnCheckout_Click;
            // 
            // CartScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(labelTitle);
            Controls.Add(labelSubtitle);
            Controls.Add(dataGridViewCart);
            Controls.Add(btnRemove);
            Controls.Add(btnBack);
            Controls.Add(panelCartSummary);
            Controls.Add(btnCheckout);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(800, 500);
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
    }
}