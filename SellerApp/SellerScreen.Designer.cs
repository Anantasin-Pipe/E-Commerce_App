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
            dataGridViewOrders = new DataGridView();
            label1 = new Label();
            txtTracking = new TextBox();
            cbStatus = new ComboBox();
            btnUpdateStatus = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            panelAddProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).BeginInit();
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
            labelTitle.Size = new Size(208, 32);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Seller Dashboard";
            // 
            // labelSubtitle
            // 
            labelSubtitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelSubtitle.AutoSize = true;
            labelSubtitle.Font = new Font("Segoe UI", 10F);
            labelSubtitle.ForeColor = Color.FromArgb(100, 100, 100);
            labelSubtitle.Location = new Point(22, 38);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(238, 19);
            labelSubtitle.TabIndex = 1;
            labelSubtitle.Text = "Manage your products and inventory";
            // 
            // panelAddProduct
            // 
            panelAddProduct.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            panelAddProduct.Location = new Point(22, 56);
            panelAddProduct.Margin = new Padding(3, 2, 3, 2);
            panelAddProduct.Name = "panelAddProduct";
            panelAddProduct.Size = new Size(639, 129);
            panelAddProduct.TabIndex = 2;
            // 
            // labelProductName
            // 
            labelProductName.AutoSize = true;
            labelProductName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelProductName.ForeColor = Color.FromArgb(51, 51, 51);
            labelProductName.Location = new Point(9, 8);
            labelProductName.Name = "labelProductName";
            labelProductName.Size = new Size(110, 19);
            labelProductName.TabIndex = 0;
            labelProductName.Text = "Product Name:";
            // 
            // textBoxProductName
            // 
            textBoxProductName.BackColor = Color.White;
            textBoxProductName.Font = new Font("Segoe UI", 10F);
            textBoxProductName.Location = new Point(122, 6);
            textBoxProductName.Margin = new Padding(3, 2, 3, 2);
            textBoxProductName.Name = "textBoxProductName";
            textBoxProductName.Size = new Size(176, 25);
            textBoxProductName.TabIndex = 1;
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelPrice.ForeColor = Color.FromArgb(51, 51, 51);
            labelPrice.Location = new Point(306, 8);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(47, 19);
            labelPrice.TabIndex = 2;
            labelPrice.Text = "Price:";
            // 
            // textBoxPrice
            // 
            textBoxPrice.BackColor = Color.White;
            textBoxPrice.Font = new Font("Segoe UI", 10F);
            textBoxPrice.Location = new Point(359, 6);
            textBoxPrice.Margin = new Padding(3, 2, 3, 2);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(106, 25);
            textBoxPrice.TabIndex = 3;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelDescription.ForeColor = Color.FromArgb(51, 51, 51);
            labelDescription.Location = new Point(9, 34);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(89, 19);
            labelDescription.TabIndex = 4;
            labelDescription.Text = "Description:";
            // 
            // textBoxDescription
            // 
            textBoxDescription.BackColor = Color.White;
            textBoxDescription.Font = new Font("Segoe UI", 10F);
            textBoxDescription.Location = new Point(122, 32);
            textBoxDescription.Margin = new Padding(3, 2, 3, 2);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(342, 38);
            textBoxDescription.TabIndex = 5;
            // 
            // labelImageUrl
            // 
            labelImageUrl.AutoSize = true;
            labelImageUrl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelImageUrl.ForeColor = Color.FromArgb(51, 51, 51);
            labelImageUrl.Location = new Point(9, 79);
            labelImageUrl.Name = "labelImageUrl";
            labelImageUrl.Size = new Size(85, 19);
            labelImageUrl.TabIndex = 6;
            labelImageUrl.Text = "Image URL:";
            // 
            // textBoxImageUrl
            // 
            textBoxImageUrl.BackColor = Color.White;
            textBoxImageUrl.Font = new Font("Segoe UI", 10F);
            textBoxImageUrl.Location = new Point(122, 77);
            textBoxImageUrl.Margin = new Padding(3, 2, 3, 2);
            textBoxImageUrl.Name = "textBoxImageUrl";
            textBoxImageUrl.Size = new Size(342, 25);
            textBoxImageUrl.TabIndex = 7;
            // 
            // btnAddProduct
            // 
            btnAddProduct.BackColor = Color.FromArgb(76, 175, 80);
            btnAddProduct.FlatStyle = FlatStyle.Flat;
            btnAddProduct.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddProduct.ForeColor = Color.White;
            btnAddProduct.Location = new Point(472, 34);
            btnAddProduct.Margin = new Padding(3, 2, 3, 2);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(158, 68);
            btnAddProduct.TabIndex = 8;
            btnAddProduct.Text = "+ Add Product";
            btnAddProduct.UseVisualStyleBackColor = false;
            btnAddProduct.Click += BtnAddProduct_Click;
            // 
            // labelProductList
            // 
            labelProductList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelProductList.AutoSize = true;
            labelProductList.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelProductList.ForeColor = Color.FromArgb(51, 51, 51);
            labelProductList.Location = new Point(22, 198);
            labelProductList.Name = "labelProductList";
            labelProductList.Size = new Size(149, 21);
            labelProductList.TabIndex = 9;
            labelProductList.Text = "Product Inventory";
            // 
            // dataGridViewProducts
            // 
            dataGridViewProducts.AllowUserToAddRows = false;
            dataGridViewProducts.AllowUserToDeleteRows = false;
            dataGridViewProducts.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewProducts.BackgroundColor = Color.White;
            dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProducts.Columns.AddRange(new DataGridViewColumn[] { colSelect, colProductName, colPrice, colDescription, colImageUrl });
            dataGridViewProducts.Location = new Point(22, 221);
            dataGridViewProducts.Margin = new Padding(3, 2, 3, 2);
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.RowHeadersVisible = false;
            dataGridViewProducts.RowHeadersWidth = 51;
            dataGridViewProducts.Size = new Size(639, 142);
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
            btnRemoveProduct.Location = new Point(22, 372);
            btnRemoveProduct.Margin = new Padding(3, 2, 3, 2);
            btnRemoveProduct.Name = "btnRemoveProduct";
            btnRemoveProduct.Size = new Size(129, 28);
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
            btnRefresh.Location = new Point(370, 683);
            btnRefresh.Margin = new Padding(3, 2, 3, 2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(95, 28);
            btnRefresh.TabIndex = 13;
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // labelProductCount
            // 
            labelProductCount.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelProductCount.AutoSize = true;
            labelProductCount.Font = new Font("Segoe UI", 10F);
            labelProductCount.ForeColor = Color.FromArgb(100, 100, 100);
            labelProductCount.Location = new Point(542, 198);
            labelProductCount.Name = "labelProductCount";
            labelProductCount.Size = new Size(111, 19);
            labelProductCount.TabIndex = 10;
            labelProductCount.Text = "Total: 0 products";
            // 
            // dataGridViewOrders
            // 
            dataGridViewOrders.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrders.Location = new Point(22, 431);
            dataGridViewOrders.Name = "dataGridViewOrders";
            dataGridViewOrders.Size = new Size(639, 205);
            dataGridViewOrders.TabIndex = 14;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(51, 51, 51);
            label1.Location = new Point(22, 407);
            label1.Name = "label1";
            label1.Size = new Size(159, 21);
            label1.TabIndex = 15;
            label1.Text = "Order Management";
            // 
            // txtTracking
            // 
            txtTracking.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtTracking.Location = new Point(98, 649);
            txtTracking.Name = "txtTracking";
            txtTracking.Size = new Size(308, 23);
            txtTracking.TabIndex = 17;
            // 
            // cbStatus
            // 
            cbStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(473, 651);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(181, 23);
            cbStatus.TabIndex = 18;
            // 
            // btnUpdateStatus
            // 
            btnUpdateStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpdateStatus.BackColor = Color.FromArgb(76, 175, 80);
            btnUpdateStatus.FlatStyle = FlatStyle.Flat;
            btnUpdateStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdateStatus.ForeColor = Color.White;
            btnUpdateStatus.Location = new Point(473, 679);
            btnUpdateStatus.Name = "btnUpdateStatus";
            btnUpdateStatus.Size = new Size(181, 32);
            btnUpdateStatus.TabIndex = 19;
            btnUpdateStatus.Text = "Update Status";
            btnUpdateStatus.UseVisualStyleBackColor = false;
            btnUpdateStatus.Click += btnUpdateStatus_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(51, 51, 51);
            label3.Location = new Point(22, 649);
            label3.Name = "label3";
            label3.Size = new Size(70, 19);
            label3.TabIndex = 10;
            label3.Text = "Tracking:";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(51, 51, 51);
            label4.Location = new Point(404, 687);
            label4.Name = "label4";
            label4.Size = new Size(0, 19);
            label4.TabIndex = 10;
            label4.Click += label3_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(51, 51, 51);
            label5.Location = new Point(412, 651);
            label5.Name = "label5";
            label5.Size = new Size(53, 19);
            label5.TabIndex = 9;
            label5.Text = "Status:";
            label5.Click += label2_Click;
            // 
            // SellerScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 723);
            Controls.Add(label5);
            Controls.Add(btnUpdateStatus);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cbStatus);
            Controls.Add(txtTracking);
            Controls.Add(label1);
            Controls.Add(dataGridViewOrders);
            Controls.Add(labelTitle);
            Controls.Add(labelSubtitle);
            Controls.Add(panelAddProduct);
            Controls.Add(labelProductList);
            Controls.Add(labelProductCount);
            Controls.Add(dataGridViewProducts);
            Controls.Add(btnRemoveProduct);
            Controls.Add(btnRefresh);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(700, 465);
            Name = "SellerScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Seller Dashboard";
            Load += SellerScreen_Load_1;
            panelAddProduct.ResumeLayout(false);
            panelAddProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewOrders;
        private Label label1;
        private TextBox txtTracking;
        private ComboBox cbStatus;
        private Button btnUpdateStatus;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}
