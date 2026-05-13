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
        private FlowLayoutPanel flowLayoutPanelProducts;
        private NumericUpDown numericUpDownQty;
        private Label labelQtyLabel;
        private Button btnAddToCart;
        private Button btnViewCart;
        private Label labelCartCount;
        private Panel panelCartBadge;
        private Panel panelProductSelector;

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
            flowLayoutPanelProducts = new FlowLayoutPanel();
            numericUpDownQty = new NumericUpDown();
            labelQtyLabel = new Label();
            btnAddToCart = new Button();
            btnViewCart = new Button();
            labelCartCount = new Label();
            panelCartBadge = new Panel();
            panelProductSelector = new Panel();

            ((System.ComponentModel.ISupportInitialize)numericUpDownQty).BeginInit();
            panelCartBadge.SuspendLayout();
            panelProductSelector.SuspendLayout();
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

            // flowLayoutPanelProducts
            flowLayoutPanelProducts.AutoScroll = true;
            flowLayoutPanelProducts.BackColor = Color.White;
            flowLayoutPanelProducts.Location = new Point(25, 75);
            flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            flowLayoutPanelProducts.Size = new Size(730, 280);
            flowLayoutPanelProducts.TabIndex = 2;
            flowLayoutPanelProducts.WrapContents = true;

            // panelProductSelector
            panelProductSelector.BackColor = Color.FromArgb(240, 240, 240);
            panelProductSelector.BorderStyle = BorderStyle.FixedSingle;
            panelProductSelector.Controls.Add(labelQtyLabel);
            panelProductSelector.Controls.Add(numericUpDownQty);
            panelProductSelector.Controls.Add(btnAddToCart);
            panelProductSelector.Location = new Point(25, 360);
            panelProductSelector.Name = "panelProductSelector";
            panelProductSelector.Size = new Size(500, 50);
            panelProductSelector.TabIndex = 3;

            // labelQtyLabel
            labelQtyLabel.AutoSize = true;
            labelQtyLabel.Font = new Font("Segoe UI", 10F, GraphicsUnit.Point);
            labelQtyLabel.ForeColor = Color.FromArgb(51, 51, 51);
            labelQtyLabel.Location = new Point(10, 15);
            labelQtyLabel.Name = "labelQtyLabel";
            labelQtyLabel.Size = new Size(65, 19);
            labelQtyLabel.TabIndex = 3;
            labelQtyLabel.Text = "Quantity:";

            // numericUpDownQty
            numericUpDownQty.BackColor = Color.White;
            numericUpDownQty.Font = new Font("Segoe UI", 10F, GraphicsUnit.Point);
            numericUpDownQty.Location = new Point(85, 13);
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
            btnAddToCart.Location = new Point(180, 10);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(140, 30);
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

            // btnViewCart - VIEW CART BUTTON
            btnViewCart.BackColor = Color.FromArgb(70, 130, 180);
            btnViewCart.FlatStyle = FlatStyle.Flat;
            btnViewCart.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnViewCart.ForeColor = Color.White;
            btnViewCart.Location = new Point(655, 360);
            btnViewCart.Name = "btnViewCart";
            btnViewCart.Size = new Size(100, 50);
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
            Controls.Add(flowLayoutPanelProducts);
            Controls.Add(panelProductSelector);
            Controls.Add(btnViewCart);
            Controls.Add(panelCartBadge);
            Name = "ProductScreen";
            Text = "Products";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)numericUpDownQty).EndInit();
            panelCartBadge.ResumeLayout(false);
            panelProductSelector.ResumeLayout(false);
            panelProductSelector.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}