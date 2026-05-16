namespace ClientApp
{
    partial class ReceiptScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label labelTitle;
        private Label labelReceiptNumber;
        private Label labelReceiptDate;
        private Label labelOrderDetails;
        private DataGridView dataGridViewItems;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colUnitPrice;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colSubTotal;
        private TextBox textBoxSubtotal;
        private Label labelShippingText;
        private TextBox textBoxShipping;
        private Label labelTaxText;
        private TextBox textBoxTax;
        private Label labelTotalText;
        private TextBox textBoxTotal;
        private Panel panelPaymentInfo;
        private Label labelPaymentMethodText;
        private TextBox textBoxPaymentMethod;
        private Label labelPaidDateText;
        private TextBox textBoxPaidDate;
        private Button btnPrint;
        private Button btnDownload;

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
            labelReceiptNumber = new Label();
            labelReceiptDate = new Label();
            labelOrderDetails = new Label();
            dataGridViewItems = new DataGridView();
            colProductName = new DataGridViewTextBoxColumn();
            colUnitPrice = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colSubTotal = new DataGridViewTextBoxColumn();
            textBoxSubtotal = new TextBox();
            labelShippingText = new Label();
            textBoxShipping = new TextBox();
            labelTaxText = new Label();
            textBoxTax = new TextBox();
            labelTotalText = new Label();
            textBoxTotal = new TextBox();
            panelPaymentInfo = new Panel();
            labelPaymentMethodText = new Label();
            textBoxPaymentMethod = new TextBox();
            labelPaidDateText = new Label();
            textBoxPaidDate = new TextBox();
            btnPrint = new Button();
            btnDownload = new Button();
            panel1 = new Panel();
            btnBack = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItems).BeginInit();
            panelPaymentInfo.SuspendLayout();
            panel1.SuspendLayout();
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
            labelTitle.Size = new Size(171, 32);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Order Receipt";
            labelTitle.Click += labelTitle_Click;
            // 
            // labelReceiptNumber
            // 
            labelReceiptNumber.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelReceiptNumber.AutoSize = true;
            labelReceiptNumber.Font = new Font("Segoe UI", 10F);
            labelReceiptNumber.ForeColor = Color.FromArgb(100, 100, 100);
            labelReceiptNumber.Location = new Point(22, 38);
            labelReceiptNumber.Name = "labelReceiptNumber";
            labelReceiptNumber.Size = new Size(229, 19);
            labelReceiptNumber.TabIndex = 1;
            labelReceiptNumber.Text = "Order #12345 | Invoice ID: INV-001";
            // 
            // labelReceiptDate
            // 
            labelReceiptDate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelReceiptDate.AutoSize = true;
            labelReceiptDate.Font = new Font("Segoe UI", 10F);
            labelReceiptDate.ForeColor = Color.FromArgb(100, 100, 100);
            labelReceiptDate.Location = new Point(22, 54);
            labelReceiptDate.Name = "labelReceiptDate";
            labelReceiptDate.Size = new Size(161, 19);
            labelReceiptDate.TabIndex = 2;
            labelReceiptDate.Text = "May 13, 2026 - 2:45 PM";
            // 
            // labelOrderDetails
            // 
            labelOrderDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelOrderDetails.AutoSize = true;
            labelOrderDetails.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelOrderDetails.ForeColor = Color.FromArgb(51, 51, 51);
            labelOrderDetails.Location = new Point(22, 79);
            labelOrderDetails.Name = "labelOrderDetails";
            labelOrderDetails.Size = new Size(99, 21);
            labelOrderDetails.TabIndex = 3;
            labelOrderDetails.Text = "Order Items";
            // 
            // dataGridViewItems
            // 
            dataGridViewItems.AllowUserToAddRows = false;
            dataGridViewItems.AllowUserToDeleteRows = false;
            dataGridViewItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewItems.BackgroundColor = Color.White;
            dataGridViewItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewItems.Columns.AddRange(new DataGridViewColumn[] { colProductName, colUnitPrice, colQuantity, colSubTotal });
            dataGridViewItems.Location = new Point(22, 98);
            dataGridViewItems.Margin = new Padding(3, 2, 3, 2);
            dataGridViewItems.Name = "dataGridViewItems";
            dataGridViewItems.ReadOnly = true;
            dataGridViewItems.RowHeadersVisible = false;
            dataGridViewItems.Size = new Size(760, 250);
            dataGridViewItems.TabIndex = 4;
            dataGridViewItems.CellContentClick += dataGridViewItems_CellContentClick;
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
            colQuantity.ReadOnly = true;
            colQuantity.Width = 60;
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
            // textBoxSubtotal
            // 
            textBoxSubtotal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSubtotal.BackColor = Color.White;
            textBoxSubtotal.Font = new Font("Segoe UI", 9F);
            textBoxSubtotal.Location = new Point(57, 2);
            textBoxSubtotal.Margin = new Padding(3, 2, 3, 2);
            textBoxSubtotal.Name = "textBoxSubtotal";
            textBoxSubtotal.ReadOnly = true;
            textBoxSubtotal.Size = new Size(172, 23);
            textBoxSubtotal.TabIndex = 1;
            textBoxSubtotal.Text = "$0.00";
            textBoxSubtotal.TextAlign = HorizontalAlignment.Right;
            // 
            // labelShippingText
            // 
            labelShippingText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelShippingText.AutoSize = true;
            labelShippingText.Font = new Font("Segoe UI", 9F);
            labelShippingText.Location = new Point(3, 5);
            labelShippingText.Name = "labelShippingText";
            labelShippingText.Size = new Size(57, 15);
            labelShippingText.TabIndex = 2;
            labelShippingText.Text = "Shipping:";
            labelShippingText.Click += labelShippingText_Click;
            // 
            // textBoxShipping
            // 
            textBoxShipping.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxShipping.BackColor = Color.White;
            textBoxShipping.Font = new Font("Segoe UI", 9F);
            textBoxShipping.Location = new Point(57, 29);
            textBoxShipping.Margin = new Padding(3, 2, 3, 2);
            textBoxShipping.Name = "textBoxShipping";
            textBoxShipping.ReadOnly = true;
            textBoxShipping.Size = new Size(172, 23);
            textBoxShipping.TabIndex = 3;
            textBoxShipping.Text = "$0.00";
            textBoxShipping.TextAlign = HorizontalAlignment.Right;
            // 
            // labelTaxText
            // 
            labelTaxText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelTaxText.AutoSize = true;
            labelTaxText.Font = new Font("Segoe UI", 9F);
            labelTaxText.Location = new Point(3, 31);
            labelTaxText.Name = "labelTaxText";
            labelTaxText.Size = new Size(27, 15);
            labelTaxText.TabIndex = 4;
            labelTaxText.Text = "Tax:";
            // 
            // textBoxTax
            // 
            textBoxTax.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxTax.BackColor = Color.White;
            textBoxTax.Font = new Font("Segoe UI", 9F);
            textBoxTax.Location = new Point(57, 56);
            textBoxTax.Margin = new Padding(3, 2, 3, 2);
            textBoxTax.Name = "textBoxTax";
            textBoxTax.ReadOnly = true;
            textBoxTax.Size = new Size(172, 23);
            textBoxTax.TabIndex = 5;
            textBoxTax.Text = "$0.00";
            textBoxTax.TextAlign = HorizontalAlignment.Right;
            // 
            // labelTotalText
            // 
            labelTotalText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelTotalText.AutoSize = true;
            labelTotalText.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelTotalText.Location = new Point(3, 56);
            labelTotalText.Name = "labelTotalText";
            labelTotalText.Size = new Size(48, 20);
            labelTotalText.TabIndex = 6;
            labelTotalText.Text = "Total:";
            // 
            // textBoxTotal
            // 
            textBoxTotal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxTotal.BackColor = Color.FromArgb(70, 130, 180);
            textBoxTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBoxTotal.ForeColor = Color.White;
            textBoxTotal.Location = new Point(57, 81);
            textBoxTotal.Margin = new Padding(3, 2, 3, 2);
            textBoxTotal.Name = "textBoxTotal";
            textBoxTotal.ReadOnly = true;
            textBoxTotal.Size = new Size(172, 29);
            textBoxTotal.TabIndex = 7;
            textBoxTotal.Text = "$0.00";
            textBoxTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // panelPaymentInfo
            // 
            panelPaymentInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelPaymentInfo.BackColor = Color.FromArgb(240, 240, 240);
            panelPaymentInfo.BorderStyle = BorderStyle.FixedSingle;
            panelPaymentInfo.Controls.Add(labelPaymentMethodText);
            panelPaymentInfo.Controls.Add(textBoxPaymentMethod);
            panelPaymentInfo.Controls.Add(labelPaidDateText);
            panelPaymentInfo.Controls.Add(textBoxPaidDate);
            panelPaymentInfo.Location = new Point(22, 351);
            panelPaymentInfo.Margin = new Padding(3, 2, 3, 2);
            panelPaymentInfo.Name = "panelPaymentInfo";
            panelPaymentInfo.Size = new Size(509, 61);
            panelPaymentInfo.TabIndex = 6;
            // 
            // labelPaymentMethodText
            // 
            labelPaymentMethodText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelPaymentMethodText.AutoSize = true;
            labelPaymentMethodText.Font = new Font("Segoe UI", 9F);
            labelPaymentMethodText.Location = new Point(7, 8);
            labelPaymentMethodText.Name = "labelPaymentMethodText";
            labelPaymentMethodText.Size = new Size(102, 15);
            labelPaymentMethodText.TabIndex = 0;
            labelPaymentMethodText.Text = "Payment Method:";
            // 
            // textBoxPaymentMethod
            // 
            textBoxPaymentMethod.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPaymentMethod.BackColor = Color.White;
            textBoxPaymentMethod.Font = new Font("Segoe UI", 9F);
            textBoxPaymentMethod.Location = new Point(122, 8);
            textBoxPaymentMethod.Margin = new Padding(3, 2, 3, 2);
            textBoxPaymentMethod.Name = "textBoxPaymentMethod";
            textBoxPaymentMethod.ReadOnly = true;
            textBoxPaymentMethod.Size = new Size(370, 23);
            textBoxPaymentMethod.TabIndex = 1;
            textBoxPaymentMethod.Text = "Credit Card";
            // 
            // labelPaidDateText
            // 
            labelPaidDateText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelPaidDateText.AutoSize = true;
            labelPaidDateText.Font = new Font("Segoe UI", 9F);
            labelPaidDateText.Location = new Point(7, 30);
            labelPaidDateText.Name = "labelPaidDateText";
            labelPaidDateText.Size = new Size(60, 15);
            labelPaidDateText.TabIndex = 2;
            labelPaidDateText.Text = "Paid Date:";
            // 
            // textBoxPaidDate
            // 
            textBoxPaidDate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPaidDate.BackColor = Color.White;
            textBoxPaidDate.Font = new Font("Segoe UI", 9F);
            textBoxPaidDate.Location = new Point(122, 30);
            textBoxPaidDate.Margin = new Padding(3, 2, 3, 2);
            textBoxPaidDate.Name = "textBoxPaidDate";
            textBoxPaidDate.ReadOnly = true;
            textBoxPaidDate.Size = new Size(370, 23);
            textBoxPaidDate.TabIndex = 3;
            textBoxPaidDate.Text = "May 13, 2026 - 2:45 PM";
            // 
            // btnPrint
            // 
            btnPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPrint.BackColor = Color.FromArgb(70, 130, 180);
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI", 10F);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(22, 417);
            btnPrint.Margin = new Padding(3, 2, 3, 2);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(95, 32);
            btnPrint.TabIndex = 7;
            btnPrint.Text = "🖨 Print";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += BtnPrint_Click;
            // 
            // btnDownload
            // 
            btnDownload.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDownload.BackColor = Color.FromArgb(70, 130, 180);
            btnDownload.FlatStyle = FlatStyle.Flat;
            btnDownload.Font = new Font("Segoe UI", 10F);
            btnDownload.ForeColor = Color.White;
            btnDownload.Location = new Point(123, 417);
            btnDownload.Margin = new Padding(3, 2, 3, 2);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(103, 32);
            btnDownload.TabIndex = 8;
            btnDownload.Text = "⬇ Download PDF";
            btnDownload.UseVisualStyleBackColor = false;
            btnDownload.Click += BtnDownload_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.Controls.Add(textBoxTotal);
            panel1.Controls.Add(labelTotalText);
            panel1.Controls.Add(textBoxSubtotal);
            panel1.Controls.Add(textBoxTax);
            panel1.Controls.Add(textBoxShipping);
            panel1.Controls.Add(labelTaxText);
            panel1.Controls.Add(labelShippingText);
            panel1.Location = new Point(550, 351);
            panel1.Name = "panel1";
            panel1.Size = new Size(232, 112);
            panel1.TabIndex = 11;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBack.BackColor = Color.FromArgb(200, 200, 200);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(325, 418);
            btnBack.Margin = new Padding(3, 2, 3, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(91, 31);
            btnBack.TabIndex = 12;
            btnBack.Text = "← Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += BtnBack_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(704, 20);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 13;
            // 
            // ReceiptScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 467);
            Controls.Add(btnBack);
            Controls.Add(panel1);
            Controls.Add(labelTitle);
            Controls.Add(labelReceiptNumber);
            Controls.Add(labelReceiptDate);
            Controls.Add(labelOrderDetails);
            Controls.Add(dataGridViewItems);
            Controls.Add(panelPaymentInfo);
            Controls.Add(btnPrint);
            Controls.Add(btnDownload);
            Controls.Add(btnClose);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(800, 500);
            Name = "ReceiptScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Receipt";
            ((System.ComponentModel.ISupportInitialize)dataGridViewItems).EndInit();
            panelPaymentInfo.ResumeLayout(false);
            panelPaymentInfo.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Button btnBack;
        private Button btnClose;
    }
}
//how to use btnBack to PorductScreen