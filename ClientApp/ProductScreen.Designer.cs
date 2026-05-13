namespace ClientApp
{
    partial class ProductScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label labelTitle;
        private Label labelSubtitle;
        private DataGridView dataGridViewProducts;
        private DataGridViewImageColumn colImage;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colStock;
        private NumericUpDown numericUpDownQty;
        private Label labelQtyLabel;
        private Button btnAddToCart;
        private Button btnViewCart;
        private Label labelCartCount;
        private Panel panelCartBadge;

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
            dataGridViewProducts = new DataGridView();
            colImage = new DataGridViewImageColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            numericUpDownQty = new NumericUpDown();
            labelQtyLabel = new Label();
            btnAddToCart = new Button();
            btnViewCart = new Button();
            labelCartCount = new Label();
            panelCartBadge = new Panel();

            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQty).BeginInit();
            panelCartBadge.SuspendLayout();
            SuspendLayout();

            // labelTitle
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.ForeColor = Color.FromArgb(51, 51, 51);
            labelTitle.Location = new Point(25, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(150, 32);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Products";

            // labelSubtitle
            labelSubtitle.AutoSize = true;
            labelSubtitle.Font = new Font("Segoe UI", 10F, GraphicsUnit.Point);
            labelSubtitle.ForeColor = Color.FromArgb(100, 100, 100);
            labelSubtitle.Location = new Point(25, 50);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(200, 19);
            labelSubtitle.TabIndex = 1;
            labelSubtitle.Text = "Browse and select your items";

            // dataGridViewProducts
            dataGridViewProducts.AllowUserToAddRows = false;
            dataGridViewProducts.AllowUserToDeleteRows = false;
            dataGridViewProducts.BackgroundColor = Color.White;
            dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProducts.Columns.AddRange(new DataGridViewColumn[] { colProductName, colDescription, colPrice, colStock });
            dataGridViewProducts.Location = new Point(25, 75);
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.RowHeadersVisible = false;
            dataGridViewProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProducts.Size = new Size(730, 280);
            dataGridViewProducts.TabIndex = 2;

            // colProductName
            colProductName.DataPropertyName = "ProductName";
            colProductName.HeaderText = "Product";
            colProductName.MinimumWidth = 150;
            colProductName.Name = "colProductName";
            colProductName.Width = 200;
            colProductName.ReadOnly = true;

            // colDescription
            colDescription.DataPropertyName = "Description";
            colDescription.HeaderText = "Description";
            colDescription.MinimumWidth = 150;
            colDescription.Name = "colDescription";
            colDescription.Width = 200;
            colDescription.ReadOnly = true;

            // colPrice
            colPrice.DataPropertyName = "Price";
            colPrice.HeaderText = "Price";
            colPrice.MinimumWidth = 100;
            colPrice.Name = "colPrice";
            colPrice.Width = 100;
            colPrice.ReadOnly = true;

            // colStock
            colStock.DataPropertyName = "Stock";
            colStock.HeaderText = "Stock";
            colStock.MinimumWidth = 80;
            colStock.Name = "colStock";
            colStock.Width = 80;
            colStock.ReadOnly = true;

            // labelQtyLabel
            labelQtyLabel.AutoSize = true;
            labelQtyLabel.Font = new Font("Segoe UI", 10F, GraphicsUnit.Point);
            labelQtyLabel.ForeColor = Color.FromArgb(51, 51, 51);
            labelQtyLabel.Location = new Point(25, 370);
            labelQtyLabel.Name = "labelQtyLabel";
            labelQtyLabel.Size = new Size(65, 19);
            labelQtyLabel.TabIndex = 3;
            labelQtyLabel.Text = "Quantity:";

            // numericUpDownQty
            numericUpDownQty.BackColor = Color.White;
            numericUpDownQty.Font = new Font("Segoe UI", 10F, GraphicsUnit.Point);
            numericUpDownQty.Location = new Point(100, 368);
            numericUpDownQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownQty.Name = "numericUpDownQty";
            numericUpDownQty.Size = new Size(80, 25);
            numericUpDownQty.TabIndex = 4;
            numericUpDownQty.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // btnAddToCart
            btnAddToCart.BackColor = Color.FromArgb(76, 175, 80);
            btnAddToCart.FlatStyle = FlatStyle.Flat;
            btnAddToCart.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddToCart.ForeColor = Color.White;
            btnAddToCart.Location = new Point(200, 365);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(140, 35);
            btnAddToCart.TabIndex = 5;
            btnAddToCart.Text = "+ Add to Cart";
            btnAddToCart.UseVisualStyleBackColor = false;
            btnAddToCart.Click += BtnAddToCart_Click;

            // panelCartBadge
            panelCartBadge.BackColor = Color.FromArgb(244, 67, 54);
            panelCartBadge.BorderStyle = BorderStyle.None;
            panelCartBadge.Controls.Add(labelCartCount);
            panelCartBadge.Location = new Point(675, 10);
            panelCartBadge.Name = "panelCartBadge";
            panelCartBadge.Size = new Size(80, 35);
            panelCartBadge.TabIndex = 6;

            // labelCartCount
            labelCartCount.AutoSize = true;
            labelCartCount.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelCartCount.ForeColor = Color.White;
            labelCartCount.Location = new Point(28, 5);
            labelCartCount.Name = "labelCartCount";
            labelCartCount.Size = new Size(20, 25);
            labelCartCount.TabIndex = 0;
            labelCartCount.Text = "0";

            // btnViewCart
            btnViewCart.BackColor = Color.FromArgb(70, 130, 180);
            btnViewCart.FlatStyle = FlatStyle.Flat;
            btnViewCart.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnViewCart.ForeColor = Color.White;
            btnViewCart.Location = new Point(655, 365);
            btnViewCart.Name = "btnViewCart";
            btnViewCart.Size = new Size(100, 35);
            btnViewCart.TabIndex = 7;
            btnViewCart.Text = "🛒 View Cart";
            btnViewCart.UseVisualStyleBackColor = false;
            btnViewCart.Click += BtnViewCart_Click;

            // ProductScreen
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 420);
            Controls.Add(labelTitle);
            Controls.Add(labelSubtitle);
            Controls.Add(dataGridViewProducts);
            Controls.Add(labelQtyLabel);
            Controls.Add(numericUpDownQty);
            Controls.Add(btnAddToCart);
            Controls.Add(btnViewCart);
            Controls.Add(panelCartBadge);
            Name = "ProductScreen";
            Text = "Products";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQty).EndInit();
            panelCartBadge.ResumeLayout(false);
            panelCartBadge.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}