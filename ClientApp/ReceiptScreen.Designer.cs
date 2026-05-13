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
        private Panel panelPriceSummary;
        private Label labelSubtotalText;
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
        private Button btnClose;

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
            panelPriceSummary = new Panel();
            labelSubtotalText = new Label();
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
            btnClose = new Button();

            ((System.ComponentModel.ISupportInitialize)dataGridViewItems).BeginInit();
            panelPriceSummary.SuspendLayout();
            panelPaymentInfo.SuspendLayout();
            SuspendLayout();

            // labelTitle
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.ForeColor = Color.FromArgb(51, 51, 51);
            labelTitle.Location = new Point(25, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(180, 32);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Order Receipt";

            // labelReceiptNumber
            labelReceiptNumber.AutoSize = true;
            labelReceiptNumber.Font = new Font("Segoe UI", 10F, GraphicsUnit.Point);
            labelReceiptNumber.ForeColor = Color.FromArgb(100, 100, 100);
            labelReceiptNumber.Location = new Point(25, 50);
            labelReceiptNumber.Name = "labelReceiptNumber";
            labelReceiptNumber.Size = new Size(150, 19);
            labelReceiptNumber.TabIndex = 1;
            labelReceiptNumber.Text = "Order #12345 | Invoice ID: INV-001";

            // labelReceiptDate
            labelReceiptDate.AutoSize = true;
            labelReceiptDate.Font = new Font("Segoe UI", 10F, GraphicsUnit.Point);
            labelReceiptDate.ForeColor = Color.FromArgb(100, 100, 100);
            labelReceiptDate.Location = new Point(25, 72);
            labelReceiptDate.Name = "labelReceiptDate";
            labelReceiptDate.Size = new Size(140, 19);
            labelReceiptDate.TabIndex = 2;
            labelReceiptDate.Text = "May 13, 2026 - 2:45 PM";

            // labelOrderDetails
            labelOrderDetails.AutoSize = true;
            labelOrderDetails.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelOrderDetails.ForeColor = Color.FromArgb(51, 51, 51);
            labelOrderDetails.Location = new Point(25, 105);
            labelOrderDetails.Name = "labelOrderDetails";
            labelOrderDetails.Size = new Size(120, 21);
            labelOrderDetails.TabIndex = 3;
            labelOrderDetails.Text = "Order Items";

            // dataGridViewItems
            dataGridViewItems.AllowUserToAddRows = false;
            dataGridViewItems.AllowUserToDeleteRows = false;
            dataGridViewItems.BackgroundColor = Color.White;
            dataGridViewItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewItems.Columns.AddRange(new DataGridViewColumn[] { colProductName, colUnitPrice, colQuantity, colSubTotal });
            dataGridViewItems.Location = new Point(25, 130);
            dataGridViewItems.Name = "dataGridViewItems";
            dataGridViewItems.RowHeadersVisible = false;
            dataGridViewItems.ReadOnly = true;
            dataGridViewItems.Size = new Size(730, 180);
            dataGridViewItems.TabIndex = 4;

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
            colQuantity.Width = 60;
            colQuantity.ReadOnly = true;

            // colSubTotal
            colSubTotal.DataPropertyName = "SubTotal";
            colSubTotal.HeaderText = "Subtotal";
            colSubTotal.MinimumWidth = 100;
            colSubTotal.Name = "colSubTotal";
            colSubTotal.Width = 120;
            colSubTotal.ReadOnly = true;

            // panelPriceSummary
            panelPriceSummary.BackColor = Color.FromArgb(240, 240, 240);
            panelPriceSummary.BorderStyle = BorderStyle.FixedSingle;
            panelPriceSummary.Controls.Add(labelSubtotalText);
            panelPriceSummary.Controls.Add(textBoxSubtotal);
            panelPriceSummary.Controls.Add(labelShippingText);
            panelPriceSummary.Controls.Add(textBoxShipping);
            panelPriceSummary.Controls.Add(labelTaxText);
            panelPriceSummary.Controls.Add(textBoxTax);
            panelPriceSummary.Controls.Add(labelTotalText);
            panelPriceSummary.Controls.Add(textBoxTotal);
            panelPriceSummary.Location = new Point(520, 320);
            panelPriceSummary.Name = "panelPriceSummary";
            panelPriceSummary.Size = new Size(235, 130);
            panelPriceSummary.TabIndex = 5;

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
            textBoxSubtotal.Location = new Point(140, 10);
            textBoxSubtotal.Name = "textBoxSubtotal";
            textBoxSubtotal.ReadOnly = true;
            textBoxSubtotal.Size = new Size(85, 23);
            textBoxSubtotal.TabIndex = 1;
            textBoxSubtotal.Text = "$0.00";
            textBoxSubtotal.TextAlign = HorizontalAlignment.Right;

            // labelShippingText
            labelShippingText.AutoSize = true;
            labelShippingText.Font = new Font("Segoe UI", 9F, GraphicsUnit.Point);
            labelShippingText.Location = new Point(8, 35);
            labelShippingText.Name = "labelShippingText";
            labelShippingText.Size = new Size(59, 15);
            labelShippingText.TabIndex = 2;
            labelShippingText.Text = "Shipping:";

            // textBoxShipping
            textBoxShipping.BackColor = Color.White;
            textBoxShipping.Font = new Font("Segoe UI", 9F, GraphicsUnit.Point);
            textBoxShipping.Location = new Point(140, 35);
            textBoxShipping.Name = "textBoxShipping";
            textBoxShipping.ReadOnly = true;
            textBoxShipping.Size = new Size(85, 23);
            textBoxShipping.TabIndex = 3;
            textBoxShipping.Text = "$0.00";
            textBoxShipping.TextAlign = HorizontalAlignment.Right;

            // labelTaxText
            labelTaxText.AutoSize = true;
            labelTaxText.Font = new Font("Segoe UI", 9F, GraphicsUnit.Point);
            labelTaxText.Location = new Point(8, 60);
            labelTaxText.Name = "labelTaxText";
            labelTaxText.Size = new Size(32, 15);
            labelTaxText.TabIndex = 4;
            labelTaxText.Text = "Tax:";

            // textBoxTax
            textBoxTax.BackColor = Color.White;
            textBoxTax.Font = new Font("Segoe UI", 9F, GraphicsUnit.Point);
            textBoxTax.Location = new Point(140, 60);
            textBoxTax.Name = "textBoxTax";
            textBoxTax.ReadOnly = true;
            textBoxTax.Size = new Size(85, 23);
            textBoxTax.TabIndex = 5;
            textBoxTax.Text = "$0.00";
            textBoxTax.TextAlign = HorizontalAlignment.Right;

            // labelTotalText
            labelTotalText.AutoSize = true;
            labelTotalText.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            labelTotalText.Location = new Point(8, 90);
            labelTotalText.Name = "labelTotalText";
            labelTotalText.Size = new Size(50, 20);
            labelTotalText.TabIndex = 6;
            labelTotalText.Text = "Total:";

            // textBoxTotal
            textBoxTotal.BackColor = Color.FromArgb(70, 130, 180);
            textBoxTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxTotal.ForeColor = Color.White;
            textBoxTotal.Location = new Point(98, 90);
            textBoxTotal.Name = "textBoxTotal";
            textBoxTotal.ReadOnly = true;
            textBoxTotal.Size = new Size(127, 27);
            textBoxTotal.TabIndex = 7;
            textBoxTotal.Text = "$0.00";
            textBoxTotal.TextAlign = HorizontalAlignment.Right;

            // panelPaymentInfo
            panelPaymentInfo.BackColor = Color.FromArgb(240, 240, 240);
            panelPaymentInfo.BorderStyle = BorderStyle.FixedSingle;
            panelPaymentInfo.Controls.Add(labelPaymentMethodText);
            panelPaymentInfo.Controls.Add(textBoxPaymentMethod);
            panelPaymentInfo.Controls.Add(labelPaidDateText);
            panelPaymentInfo.Controls.Add(textBoxPaidDate);
            panelPaymentInfo.Location = new Point(25, 320);
            panelPaymentInfo.Name = "panelPaymentInfo";
            panelPaymentInfo.Size = new Size(480, 75);
            panelPaymentInfo.TabIndex = 6;

            // labelPaymentMethodText
            labelPaymentMethodText.AutoSize = true;
            labelPaymentMethodText.Font = new Font("Segoe UI", 9F, GraphicsUnit.Point);
            labelPaymentMethodText.Location = new Point(8, 10);
            labelPaymentMethodText.Name = "labelPaymentMethodText";
            labelPaymentMethodText.Size = new Size(100, 15);
            labelPaymentMethodText.TabIndex = 0;
            labelPaymentMethodText.Text = "Payment Method:";

            // textBoxPaymentMethod
            textBoxPaymentMethod.BackColor = Color.White;
            textBoxPaymentMethod.Font = new Font("Segoe UI", 9F, GraphicsUnit.Point);
            textBoxPaymentMethod.Location = new Point(120, 10);
            textBoxPaymentMethod.Name = "textBoxPaymentMethod";
            textBoxPaymentMethod.ReadOnly = true;
            textBoxPaymentMethod.Size = new Size(350, 23);
            textBoxPaymentMethod.TabIndex = 1;
            textBoxPaymentMethod.Text = "Credit Card";

            // labelPaidDateText
            labelPaidDateText.AutoSize = true;
            labelPaidDateText.Font = new Font("Segoe UI", 9F, GraphicsUnit.Point);
            labelPaidDateText.Location = new Point(8, 40);
            labelPaidDateText.Name = "labelPaidDateText";
            labelPaidDateText.Size = new Size(67, 15);
            labelPaidDateText.TabIndex = 2;
            labelPaidDateText.Text = "Paid Date:";

            // textBoxPaidDate
            textBoxPaidDate.BackColor = Color.White;
            textBoxPaidDate.Font = new Font("Segoe UI", 9F, GraphicsUnit.Point);
            textBoxPaidDate.Location = new Point(120, 40);
            textBoxPaidDate.Name = "textBoxPaidDate";
            textBoxPaidDate.ReadOnly = true;
            textBoxPaidDate.Size = new Size(350, 23);
            textBoxPaidDate.TabIndex = 3;
            textBoxPaidDate.Text = "May 13, 2026 - 2:45 PM";

            // btnPrint
            btnPrint.BackColor = Color.FromArgb(70, 130, 180);
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(25, 410);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(100, 35);
            btnPrint.TabIndex = 7;
            btnPrint.Text = "🖨 Print";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += BtnPrint_Click;

            // btnDownload
            btnDownload.BackColor = Color.FromArgb(70, 130, 180);
            btnDownload.FlatStyle = FlatStyle.Flat;
            btnDownload.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnDownload.ForeColor = Color.White;
            btnDownload.Location = new Point(135, 410);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(110, 35);
            btnDownload.TabIndex = 8;
            btnDownload.Text = "⬇ Download PDF";
            btnDownload.UseVisualStyleBackColor = false;
            btnDownload.Click += BtnDownload_Click;

            // btnClose
            btnClose.BackColor = Color.FromArgb(200, 200, 200);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(655, 410);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 35);
            btnClose.TabIndex = 9;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;

            // ReceiptScreen
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 470);
            Controls.Add(labelTitle);
            Controls.Add(labelReceiptNumber);
            Controls.Add(labelReceiptDate);
            Controls.Add(labelOrderDetails);
            Controls.Add(dataGridViewItems);
            Controls.Add(panelPaymentInfo);
            Controls.Add(panelPriceSummary);
            Controls.Add(btnPrint);
            Controls.Add(btnDownload);
            Controls.Add(btnClose);
            Name = "ReceiptScreen";
            Text = "Receipt";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)dataGridViewItems).EndInit();
            panelPaymentInfo.ResumeLayout(false);
            panelPaymentInfo.PerformLayout();
            panelPriceSummary.ResumeLayout(false);
            panelPriceSummary.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}