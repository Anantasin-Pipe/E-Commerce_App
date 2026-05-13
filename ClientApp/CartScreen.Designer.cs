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

            // labelTitle
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.ForeColor = Color.FromArgb(51, 51, 51);
            labelTitle.Location = new Point(25, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(150, 32);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Shopping Cart";

            // labelSubtitle
            labelSubtitle.AutoSize = true;
            labelSubtitle.Font = new Font("Segoe UI", 10F, GraphicsUnit.Point);
            labelSubtitle.ForeColor = Color.FromArgb(100, 100, 100);
            labelSubtitle.Location = new Point(25, 50);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(210, 19);
            labelSubtitle.TabIndex = 1;
            labelSubtitle.Text = "Review and manage your items";

            // dataGridViewCart
            dataGridViewCart.AllowUserToAddRows = false;
            dataGridViewCart.AllowUserToDeleteRows = false;
            dataGridViewCart.BackgroundColor = Color.White;
            dataGridViewCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCart.Columns.AddRange(new DataGridViewColumn[] { colSelect, colProductName, colUnitPrice, colQuantity, colSubTotal });
            dataGridViewCart.Location = new Point(25, 75);
            dataGridViewCart.Name = "dataGridViewCart";
            dataGridViewCart.RowHeadersVisible = false;
            dataGridViewCart.Size = new Size(730, 200);
            dataGridViewCart.TabIndex = 2;

            // colSelect
            colSelect.DataPropertyName = "Selected";
            colSelect.HeaderText = "✓";
            colSelect.MinimumWidth = 50;
            colSelect.Name = "colSelect";
            colSelect.Width = 50;

            // colProductName
            colProductName.DataPropertyName = "ProductName";
            colProductName.HeaderText = "Product";
            colProductName.MinimumWidth = 150;
            colProductName.Name = "colProductName";
            colProductName.Width = 250;
            colProductName.ReadOnly = true;

            // colUnitPrice
            colUnitPrice.DataPropertyName = "UnitPrice";
            colUnitPrice.HeaderText = "Unit Price";
            colUnitPrice.MinimumWidth = 100;
            colUnitPrice.Name = "colUnitPrice";
            colUnitPrice.Width = 120;
            colUnitPrice.ReadOnly = true;

            // colQuantity
            colQuantity.DataPropertyName = "Quantity";
            colQuantity.HeaderText = "Qty";
            colQuantity.MinimumWidth = 60;
            colQuantity.Name = "colQuantity";
            colQuantity.Width = 80;

            // colSubTotal
            colSubTotal.DataPropertyName = "SubTotal";
            colSubTotal.HeaderText = "Subtotal";
            colSubTotal.MinimumWidth = 100;
            colSubTotal.Name = "colSubTotal";
            colSubTotal.Width = 120;
            colSubTotal.ReadOnly = true;

            // btnRemove
            btnRemove.BackColor = Color.FromArgb(244, 67, 54);
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(25, 295);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(120, 35);
            btnRemove.TabIndex = 3;
            btnRemove.Text = "🗑 Remove";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += BtnRemove_Click;

            // btnBack
            btnBack.BackColor = Color.FromArgb(200, 200, 200);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(155, 295);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 35);
            btnBack.TabIndex = 4;
            btnBack.Text = "← Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += BtnBack_Click;

            // panelCartSummary
            panelCartSummary.BackColor = Color.FromArgb(240, 240, 240);
            panelCartSummary.BorderStyle = BorderStyle.FixedSingle;
            panelCartSummary.Controls.Add(labelSubtotalText);
            panelCartSummary.Controls.Add(textBoxSubtotal);
            panelCartSummary.Controls.Add(labelTotalText);
            panelCartSummary.Controls.Add(textBoxTotal);
            panelCartSummary.Location = new Point(545, 285);
            panelCartSummary.Name = "panelCartSummary";
            panelCartSummary.Size = new Size(210, 85);
            panelCartSummary.TabIndex = 5;

            // labelSubtotalText
            labelSubtotalText.AutoSize = true;
            labelSubtotalText.Font = new Font("Segoe UI", 9F, GraphicsUnit.Point);
            labelSubtotalText.Location = new Point(8, 10);
            labelSubtotalText.Name = "labelSubtotalText";
            labelSubtotalText.Size = new Size(60, 15);
            labelSubtotalText.TabIndex = 0;
            labelSubtotalText.Text = "Subtotal:";

            // textBoxSubtotal
            textBoxSubtotal.BackColor = Color.White;
            textBoxSubtotal.Font = new Font("Segoe UI", 9F, GraphicsUnit.Point);
            textBoxSubtotal.Location = new Point(120, 10);
            textBoxSubtotal.Name = "textBoxSubtotal";
            textBoxSubtotal.ReadOnly = true;
            textBoxSubtotal.Size = new Size(80, 23);
            textBoxSubtotal.TabIndex = 1;
            textBoxSubtotal.Text = "$0.00";
            textBoxSubtotal.TextAlign = HorizontalAlignment.Right;

            // labelTotalText
            labelTotalText.AutoSize = true;
            labelTotalText.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            labelTotalText.Location = new Point(8, 50);
            labelTotalText.Name = "labelTotalText";
            labelTotalText.Size = new Size(50, 20);
            labelTotalText.TabIndex = 2;
            labelTotalText.Text = "Total:";

            // textBoxTotal
            textBoxTotal.BackColor = Color.FromArgb(70, 130, 180);
            textBoxTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxTotal.ForeColor = Color.White;
            textBoxTotal.Location = new Point(80, 50);
            textBoxTotal.Name = "textBoxTotal";
            textBoxTotal.ReadOnly = true;
            textBoxTotal.Size = new Size(120, 27);
            textBoxTotal.TabIndex = 3;
            textBoxTotal.Text = "$0.00";
            textBoxTotal.TextAlign = HorizontalAlignment.Right;

            // btnCheckout
            btnCheckout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCheckout.BackColor = Color.FromArgb(76, 175, 80);
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Location = new Point(545, 380);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(210, 40);
            btnCheckout.TabIndex = 6;
            btnCheckout.Text = "Proceed to Checkout →";
            btnCheckout.UseVisualStyleBackColor = false;
            btnCheckout.Click += BtnCheckout_Click;

            // CartScreen
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 450);
            Controls.Add(labelTitle);
            Controls.Add(labelSubtitle);
            Controls.Add(dataGridViewCart);
            Controls.Add(btnRemove);
            Controls.Add(btnBack);
            Controls.Add(panelCartSummary);
            Controls.Add(btnCheckout);
            Name = "CartScreen";
            Text = "Shopping Cart";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCart).EndInit();
            panelCartSummary.ResumeLayout(false);
            panelCartSummary.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}