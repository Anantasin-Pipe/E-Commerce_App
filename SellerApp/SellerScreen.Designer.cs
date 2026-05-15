namespace SellerApp
{
    partial class SellerScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label labelTitle;
        private Label labelSubtitle;
        private Panel panelAddProduct;
        private Label labelProductName;
        private TextBox textBoxProductName;
        private Label labelPrice;
        private TextBox textBoxPrice;
        private Label labelDescription;
        private TextBox textBoxDescription;
        private Label labelImageUrl;
        private TextBox textBoxImageUrl;
        private Button btnAddProduct;
        private Label labelProductList;
        private DataGridView dataGridViewProducts;
        private DataGridViewCheckBoxColumn colSelect;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colImageUrl;
        private Button btnRemoveProduct;
        private Button btnRefresh;
        private Label labelProductCount;

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
            panelAddProduct = new Panel();
            labelProductName = new Label();
            textBoxProductName = new TextBox();
            labelPrice = new Label();
            textBoxPrice = new TextBox();
            labelDescription = new Label();
            textBoxDescription = new TextBox();
            labelImageUrl = new Label();
            textBoxImageUrl = new TextBox();
            btnAddProduct = new Button();
            labelProductList = new Label();
            dataGridViewProducts = new DataGridView();
            colSelect = new DataGridViewCheckBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colImageUrl = new DataGridViewTextBoxColumn();
            btnRemoveProduct = new Button();
            btnRefresh = new Button();
            labelProductCount = new Label();
            panelAddProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(51, 51, 51);
            labelTitle.Location = new Point(25, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(258, 41);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Seller Dashboard";
            // 
            // labelSubtitle
            // 
            labelSubtitle.AutoSize = true;
            labelSubtitle.Font = new Font("Segoe UI", 10F);
            labelSubtitle.ForeColor = Color.FromArgb(100, 100, 100);
            labelSubtitle.Location = new Point(25, 50);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(293, 23);
            labelSubtitle.TabIndex = 1;
            labelSubtitle.Text = "Manage your products and inventory";
            // 
            // panelAddProduct
            // 
            panelAddProduct.BackColor = Color.FromArgb(240, 248, 255);
            panelAddProduct.BorderStyle = BorderStyle.FixedSingle;
            panelAddProduct.Controls.Add(labelProductName);
            panelAddProduct.Controls.Add(textBoxProductName);
            panelAddProduct.Controls.Add(labelPrice);
            panelAddProduct.Controls.Add(textBoxPrice);
            panelAddProduct.Controls.Add(labelDescription);
            panelAddProduct.Controls.Add(textBoxDescription);
            panelAddProduct.Controls.Add(labelImageUrl);
            panelAddProduct.Controls.Add(textBoxImageUrl);
            panelAddProduct.Controls.Add(btnAddProduct);
            panelAddProduct.Location = new Point(25, 75);
            panelAddProduct.Name = "panelAddProduct";
            panelAddProduct.Size = new Size(730, 180);
            panelAddProduct.TabIndex = 2;
            // 
            // labelProductName
            // 
            labelProductName.AutoSize = true;
            labelProductName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelProductName.ForeColor = Color.FromArgb(51, 51, 51);
            labelProductName.Location = new Point(10, 10);
            labelProductName.Name = "labelProductName";
            labelProductName.Size = new Size(130, 23);
            labelProductName.TabIndex = 0;
            labelProductName.Text = "Product Name:";
            // 
            // textBoxProductName
            // 
            textBoxProductName.BackColor = Color.White;
            textBoxProductName.Font = new Font("Segoe UI", 10F);
            textBoxProductName.Location = new Point(140, 8);
            textBoxProductName.Name = "textBoxProductName";
            textBoxProductName.Size = new Size(200, 30);
            textBoxProductName.TabIndex = 1;
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelPrice.ForeColor = Color.FromArgb(51, 51, 51);
            labelPrice.Location = new Point(350, 10);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(54, 23);
            labelPrice.TabIndex = 2;
            labelPrice.Text = "Price:";
            // 
            // textBoxPrice
            // 
            textBoxPrice.BackColor = Color.White;
            textBoxPrice.Font = new Font("Segoe UI", 10F);
            textBoxPrice.Location = new Point(410, 8);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(120, 30);
            textBoxPrice.TabIndex = 3;
            textBoxPrice.Text = "";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelDescription.ForeColor = Color.FromArgb(51, 51, 51);
            labelDescription.Location = new Point(10, 45);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(107, 23);
            labelDescription.TabIndex = 4;
            labelDescription.Text = "Description:";
            // 
            // textBoxDescription
            // 
            textBoxDescription.BackColor = Color.White;
            textBoxDescription.Font = new Font("Segoe UI", 10F);
            textBoxDescription.Location = new Point(140, 43);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(390, 50);
            textBoxDescription.TabIndex = 5;
            // 
            // labelImageUrl
            // 
            labelImageUrl.AutoSize = true;
            labelImageUrl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelImageUrl.ForeColor = Color.FromArgb(51, 51, 51);
            labelImageUrl.Location = new Point(10, 105);
            labelImageUrl.Name = "labelImageUrl";
            labelImageUrl.Size = new Size(102, 23);
            labelImageUrl.TabIndex = 6;
            labelImageUrl.Text = "Image URL:";
            // 
            // textBoxImageUrl
            // 
            textBoxImageUrl.BackColor = Color.White;
            textBoxImageUrl.Font = new Font("Segoe UI", 10F);
            textBoxImageUrl.Location = new Point(140, 103);
            textBoxImageUrl.Name = "textBoxImageUrl";
            textBoxImageUrl.Size = new Size(390, 30);
            textBoxImageUrl.TabIndex = 7;
            // 
            // btnAddProduct
            // 
            btnAddProduct.BackColor = Color.FromArgb(76, 175, 80);
            btnAddProduct.FlatStyle = FlatStyle.Flat;
            btnAddProduct.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddProduct.ForeColor = Color.White;
            btnAddProduct.Location = new Point(540, 45);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(180, 90);
            btnAddProduct.TabIndex = 8;
            btnAddProduct.Text = "+ Add Product";
            btnAddProduct.UseVisualStyleBackColor = false;
            btnAddProduct.Click += BtnAddProduct_Click;
            // 
            // labelProductList
            // 
            labelProductList.AutoSize = true;
            labelProductList.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelProductList.ForeColor = Color.FromArgb(51, 51, 51);
            labelProductList.Location = new Point(25, 270);
            labelProductList.Name = "labelProductList";
            labelProductList.Size = new Size(184, 28);
            labelProductList.TabIndex = 9;
            labelProductList.Text = "Product Inventory";
            // 
            // dataGridViewProducts
            // 
            dataGridViewProducts.AllowUserToAddRows = false;
            dataGridViewProducts.AllowUserToDeleteRows = false;
            dataGridViewProducts.BackgroundColor = Color.White;
            dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProducts.Columns.AddRange(new DataGridViewColumn[] { colSelect, colProductName, colPrice, colDescription, colImageUrl });
            dataGridViewProducts.Location = new Point(25, 295);
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.RowHeadersVisible = false;
            dataGridViewProducts.RowHeadersWidth = 51;
            dataGridViewProducts.Size = new Size(730, 200);
            dataGridViewProducts.TabIndex = 11;
            // 
            // colSelect
            // 
            colSelect.HeaderText = "✓";
            colSelect.MinimumWidth = 50;
            colSelect.Name = "colSelect";
            colSelect.Width = 50;
            // 
            // colProductName
            // 
            colProductName.DataPropertyName = "ProductName";
            colProductName.HeaderText = "Product Name";
            colProductName.MinimumWidth = 150;
            colProductName.Name = "colProductName";
            colProductName.ReadOnly = true;
            colProductName.Width = 150;
            // 
            // colPrice
            // 
            colPrice.DataPropertyName = "Price";
            colPrice.HeaderText = "Price";
            colPrice.MinimumWidth = 80;
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            colPrice.Width = 80;
            // 
            // colDescription
            // 
            colDescription.DataPropertyName = "Description";
            colDescription.HeaderText = "Description";
            colDescription.MinimumWidth = 150;
            colDescription.Name = "colDescription";
            colDescription.ReadOnly = true;
            colDescription.Width = 200;
            // 
            // colImageUrl
            // 
            colImageUrl.DataPropertyName = "ImageUrl";
            colImageUrl.HeaderText = "Image URL";
            colImageUrl.MinimumWidth = 150;
            colImageUrl.Name = "colImageUrl";
            colImageUrl.ReadOnly = true;
            colImageUrl.Width = 150;
            // 
            // btnRemoveProduct
            // 
            btnRemoveProduct.BackColor = Color.FromArgb(244, 67, 54);
            btnRemoveProduct.FlatStyle = FlatStyle.Flat;
            btnRemoveProduct.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRemoveProduct.ForeColor = Color.White;
            btnRemoveProduct.Location = new Point(25, 510);
            btnRemoveProduct.Name = "btnRemoveProduct";
            btnRemoveProduct.Size = new Size(140, 35);
            btnRemoveProduct.TabIndex = 12;
            btnRemoveProduct.Text = "🗑 Remove Selected";
            btnRemoveProduct.UseVisualStyleBackColor = false;
            btnRemoveProduct.Click += BtnRemoveProduct_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(70, 130, 180);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(175, 510);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 35);
            btnRefresh.TabIndex = 13;
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // labelProductCount
            // 
            labelProductCount.AutoSize = true;
            labelProductCount.Font = new Font("Segoe UI", 10F);
            labelProductCount.ForeColor = Color.FromArgb(100, 100, 100);
            labelProductCount.Location = new Point(600, 273);
            labelProductCount.Name = "labelProductCount";
            labelProductCount.Size = new Size(136, 23);
            labelProductCount.TabIndex = 10;
            labelProductCount.Text = "Total: 0 products";
            // 
            // SellerScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 560);
            MinimumSize = new Size(798, 607);
            Controls.Add(labelTitle);
            Controls.Add(labelSubtitle);
            Controls.Add(panelAddProduct);
            Controls.Add(labelProductList);
            Controls.Add(labelProductCount);
            Controls.Add(dataGridViewProducts);
            Controls.Add(btnRemoveProduct);
            Controls.Add(btnRefresh);
            Name = "SellerScreen";
            Text = "Seller Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).EndInit();
            panelAddProduct.ResumeLayout(false);
            panelAddProduct.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
