namespace ClientApp
{
    partial class CheckoutScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label labelTitle;
        private Label labelOrderSummary;
        private DataGridView dataGridViewItems;
        private DataGridViewCheckBoxColumn colSelect;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colUnitPrice;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colSubTotal;
        private Label labelShippingCost;
        private ComboBox comboBoxShipping;
        private TextBox textBoxShippingCost;
        private Label labelPaymentMethod;
        private ComboBox comboBoxPaymentMethod;
        private Label labelSubtotal;
        private TextBox textBoxSubtotal;
        private Label labelTax;
        private TextBox textBoxTax;
        private Label labelTotal;
        private TextBox textBoxTotal;
        private Button btnBack;
        private Button btnPay;
        private Panel panelOrderSummary;

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
            labelOrderSummary = new Label();
            dataGridViewItems = new DataGridView();
            colSelect = new DataGridViewCheckBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colUnitPrice = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colSubTotal = new DataGridViewTextBoxColumn();
            labelShippingCost = new Label();
            comboBoxShipping = new ComboBox();
            textBoxShippingCost = new TextBox();
            labelPaymentMethod = new Label();
            comboBoxPaymentMethod = new ComboBox();
            labelSubtotal = new Label();
            textBoxSubtotal = new TextBox();
            labelTax = new Label();
            textBoxTax = new TextBox();
            labelTotal = new Label();
            textBoxTotal = new TextBox();
            btnBack = new Button();
            btnPay = new Button();
            panelOrderSummary = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItems).BeginInit();
            panelOrderSummary.SuspendLayout();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(51, 51, 51);
            labelTitle.Location = new Point(22, 11);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(110, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Checkout";
            // 
            // labelOrderSummary
            // 
            labelOrderSummary.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelOrderSummary.AutoSize = true;
            labelOrderSummary.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelOrderSummary.ForeColor = Color.FromArgb(51, 51, 51);
            labelOrderSummary.Location = new Point(22, 38);
            labelOrderSummary.Name = "labelOrderSummary";
            labelOrderSummary.Size = new Size(131, 21);
            labelOrderSummary.TabIndex = 1;
            labelOrderSummary.Text = "Order Summary";
            // 
            // dataGridViewItems
            // 
            dataGridViewItems.AllowUserToAddRows = false;
            dataGridViewItems.AllowUserToDeleteRows = false;
            dataGridViewItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewItems.BackgroundColor = Color.White;
            dataGridViewItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewItems.Columns.AddRange(new DataGridViewColumn[] { colSelect, colProductName, colUnitPrice, colQuantity, colSubTotal });
            dataGridViewItems.Location = new Point(22, 56);
            dataGridViewItems.Margin = new Padding(3, 2, 3, 2);
            dataGridViewItems.Name = "dataGridViewItems";
            dataGridViewItems.RowHeadersVisible = false;
            dataGridViewItems.RowHeadersWidth = 51;
            dataGridViewItems.Size = new Size(742, 281);
            dataGridViewItems.TabIndex = 2;
            // 
            // colSelect
            // 
            colSelect.DataPropertyName = "Selected";
            colSelect.HeaderText = "Select";
            colSelect.MinimumWidth = 60;
            colSelect.Name = "colSelect";
            colSelect.Width = 60;
            // 
            // colProductName
            // 
            colProductName.DataPropertyName = "ProductName";
            colProductName.HeaderText = "Product";
            colProductName.MinimumWidth = 150;
            colProductName.Name = "colProductName";
            colProductName.ReadOnly = true;
            colProductName.Width = 200;
            // 
            // colUnitPrice
            // 
            colUnitPrice.DataPropertyName = "UnitPrice";
            colUnitPrice.HeaderText = "Unit Price";
            colUnitPrice.MinimumWidth = 100;
            colUnitPrice.Name = "colUnitPrice";
            colUnitPrice.ReadOnly = true;
            // 
            // colQuantity
            // 
            colQuantity.DataPropertyName = "Quantity";
            colQuantity.HeaderText = "Quantity";
            colQuantity.MinimumWidth = 80;
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
            // 
            // labelShippingCost
            // 
            labelShippingCost.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelShippingCost.Font = new Font("Segoe UI", 10F);
            labelShippingCost.ForeColor = Color.FromArgb(51, 51, 51);
            labelShippingCost.Location = new Point(22, 348);
            labelShippingCost.Name = "labelShippingCost";
            labelShippingCost.Size = new Size(119, 17);
            labelShippingCost.TabIndex = 3;
            labelShippingCost.Text = "Shipping Cost";
            // 
            // comboBoxShipping
            // 
            comboBoxShipping.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            comboBoxShipping.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxShipping.FormattingEnabled = true;
            comboBoxShipping.Items.AddRange(new object[] { "Standard ($5.00)", "Express ($15.00)", "Overnight ($25.00)" });
            comboBoxShipping.Location = new Point(140, 346);
            comboBoxShipping.Margin = new Padding(3, 2, 3, 2);
            comboBoxShipping.Name = "comboBoxShipping";
            comboBoxShipping.Size = new Size(181, 23);
            comboBoxShipping.TabIndex = 4;
            comboBoxShipping.SelectedIndexChanged += ComboBoxShipping_SelectedIndexChanged;
            // 
            // textBoxShippingCost
            // 
            textBoxShippingCost.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBoxShippingCost.BackColor = Color.FromArgb(240, 240, 240);
            textBoxShippingCost.Font = new Font("Segoe UI", 10F);
            textBoxShippingCost.Location = new Point(328, 346);
            textBoxShippingCost.Margin = new Padding(3, 2, 3, 2);
            textBoxShippingCost.Name = "textBoxShippingCost";
            textBoxShippingCost.ReadOnly = true;
            textBoxShippingCost.Size = new Size(75, 25);
            textBoxShippingCost.TabIndex = 5;
            textBoxShippingCost.Text = "$5.00";
            textBoxShippingCost.TextAlign = HorizontalAlignment.Right;
            // 
            // labelPaymentMethod
            // 
            labelPaymentMethod.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelPaymentMethod.Font = new Font("Segoe UI", 10F);
            labelPaymentMethod.ForeColor = Color.FromArgb(51, 51, 51);
            labelPaymentMethod.Location = new Point(22, 375);
            labelPaymentMethod.Name = "labelPaymentMethod";
            labelPaymentMethod.Size = new Size(119, 17);
            labelPaymentMethod.TabIndex = 6;
            labelPaymentMethod.Text = "Payment Method";
            // 
            // comboBoxPaymentMethod
            // 
            comboBoxPaymentMethod.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            comboBoxPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPaymentMethod.FormattingEnabled = true;
            comboBoxPaymentMethod.Items.AddRange(new object[] { "Credit Card", "Debit Card", "Bank Transfer", "Cash on Delivery" });
            comboBoxPaymentMethod.Location = new Point(140, 372);
            comboBoxPaymentMethod.Margin = new Padding(3, 2, 3, 2);
            comboBoxPaymentMethod.Name = "comboBoxPaymentMethod";
            comboBoxPaymentMethod.Size = new Size(181, 23);
            comboBoxPaymentMethod.TabIndex = 7;
            comboBoxPaymentMethod.SelectedIndexChanged += comboBoxPaymentMethod_SelectedIndexChanged;
            // 
            // labelSubtotal
            // 
            labelSubtotal.AutoSize = true;
            labelSubtotal.Font = new Font("Segoe UI", 9F);
            labelSubtotal.Location = new Point(4, 6);
            labelSubtotal.Name = "labelSubtotal";
            labelSubtotal.Size = new Size(54, 15);
            labelSubtotal.TabIndex = 0;
            labelSubtotal.Text = "Subtotal:";
            // 
            // textBoxSubtotal
            // 
            textBoxSubtotal.BackColor = Color.White;
            textBoxSubtotal.Font = new Font("Segoe UI", 9F);
            textBoxSubtotal.Location = new Point(83, 6);
            textBoxSubtotal.Margin = new Padding(3, 2, 3, 2);
            textBoxSubtotal.Name = "textBoxSubtotal";
            textBoxSubtotal.ReadOnly = true;
            textBoxSubtotal.Size = new Size(72, 23);
            textBoxSubtotal.TabIndex = 1;
            textBoxSubtotal.Text = "$0.00";
            textBoxSubtotal.TextAlign = HorizontalAlignment.Right;
            // 
            // labelTax
            // 
            labelTax.AutoSize = true;
            labelTax.Font = new Font("Segoe UI", 9F);
            labelTax.Location = new Point(4, 26);
            labelTax.Name = "labelTax";
            labelTax.Size = new Size(27, 15);
            labelTax.TabIndex = 2;
            labelTax.Text = "Tax:";
            // 
            // textBoxTax
            // 
            textBoxTax.BackColor = Color.White;
            textBoxTax.Font = new Font("Segoe UI", 9F);
            textBoxTax.Location = new Point(83, 26);
            textBoxTax.Margin = new Padding(3, 2, 3, 2);
            textBoxTax.Name = "textBoxTax";
            textBoxTax.ReadOnly = true;
            textBoxTax.Size = new Size(72, 23);
            textBoxTax.TabIndex = 3;
            textBoxTax.Text = "$0.00";
            textBoxTax.TextAlign = HorizontalAlignment.Right;
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelTotal.Location = new Point(4, 46);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(48, 20);
            labelTotal.TabIndex = 4;
            labelTotal.Text = "Total:";
            // 
            // textBoxTotal
            // 
            textBoxTotal.BackColor = Color.FromArgb(70, 130, 180);
            textBoxTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            textBoxTotal.ForeColor = Color.White;
            textBoxTotal.Location = new Point(52, 46);
            textBoxTotal.Margin = new Padding(3, 2, 3, 2);
            textBoxTotal.Name = "textBoxTotal";
            textBoxTotal.ReadOnly = true;
            textBoxTotal.Size = new Size(103, 27);
            textBoxTotal.TabIndex = 5;
            textBoxTotal.Text = "$0.00";
            textBoxTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBack.BackColor = Color.FromArgb(200, 200, 200);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(22, 420);
            btnBack.Margin = new Padding(3, 2, 3, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(114, 30);
            btnBack.TabIndex = 9;
            btnBack.Text = "← Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += BtnBack_Click;
            // 
            // btnPay
            // 
            btnPay.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnPay.BackColor = Color.FromArgb(76, 175, 80);
            btnPay.FlatStyle = FlatStyle.Flat;
            btnPay.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPay.ForeColor = Color.White;
            btnPay.Location = new Point(676, 424);
            btnPay.Margin = new Padding(3, 2, 3, 2);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(88, 30);
            btnPay.TabIndex = 10;
            btnPay.Text = "Pay Now";
            btnPay.UseVisualStyleBackColor = false;
            btnPay.Click += BtnPay_Click;
            // 
            // panelOrderSummary
            // 
            panelOrderSummary.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panelOrderSummary.BackColor = Color.FromArgb(240, 240, 240);
            panelOrderSummary.BorderStyle = BorderStyle.FixedSingle;
            panelOrderSummary.Controls.Add(labelSubtotal);
            panelOrderSummary.Controls.Add(textBoxSubtotal);
            panelOrderSummary.Controls.Add(labelTax);
            panelOrderSummary.Controls.Add(textBoxTax);
            panelOrderSummary.Controls.Add(labelTotal);
            panelOrderSummary.Controls.Add(textBoxTotal);
            panelOrderSummary.Location = new Point(604, 341);
            panelOrderSummary.Margin = new Padding(3, 2, 3, 2);
            panelOrderSummary.Name = "panelOrderSummary";
            panelOrderSummary.Size = new Size(160, 79);
            panelOrderSummary.TabIndex = 8;
            // 
            // CheckoutScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(labelTitle);
            Controls.Add(labelOrderSummary);
            Controls.Add(dataGridViewItems);
            Controls.Add(labelShippingCost);
            Controls.Add(comboBoxShipping);
            Controls.Add(textBoxShippingCost);
            Controls.Add(labelPaymentMethod);
            Controls.Add(comboBoxPaymentMethod);
            Controls.Add(panelOrderSummary);
            Controls.Add(btnBack);
            Controls.Add(btnPay);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(800, 500);
            Name = "CheckoutScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Checkout";
            ((System.ComponentModel.ISupportInitialize)dataGridViewItems).EndInit();
            panelOrderSummary.ResumeLayout(false);
            panelOrderSummary.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}