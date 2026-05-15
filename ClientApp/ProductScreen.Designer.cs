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
            flowLayoutPanelProducts = new FlowLayoutPanel();
            numericUpDownQty = new NumericUpDown();
            labelQtyLabel = new Label();
            btnViewCart = new Button();
            labelCartCount = new Label();
            panelCartBadge = new Panel();
            btnAddToCart = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQty).BeginInit();
            panelCartBadge.SuspendLayout();
            panel1.SuspendLayout();
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
            labelTitle.Size = new Size(142, 41);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Products";
            // 
            // labelSubtitle
            // 
            labelSubtitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelSubtitle.AutoSize = true;
            labelSubtitle.Font = new Font("Segoe UI", 10F);
            labelSubtitle.ForeColor = Color.FromArgb(100, 100, 100);
            labelSubtitle.Location = new Point(25, 51);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(231, 23);
            labelSubtitle.TabIndex = 1;
            labelSubtitle.Text = "Browse and select your items";
            // 
            // flowLayoutPanelProducts
            // 
            flowLayoutPanelProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelProducts.AutoScroll = true;
            flowLayoutPanelProducts.BackColor = Color.White;
            flowLayoutPanelProducts.Location = new Point(25, 75);
            flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            flowLayoutPanelProducts.Size = new Size(847, 461);
            flowLayoutPanelProducts.TabIndex = 2;
            flowLayoutPanelProducts.Paint += flowLayoutPanelProducts_Paint;
            // 
            // numericUpDownQty
            // 
            numericUpDownQty.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            numericUpDownQty.BackColor = Color.White;
            numericUpDownQty.Font = new Font("Segoe UI", 10F);
            numericUpDownQty.Location = new Point(86, 12);
            numericUpDownQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownQty.Name = "numericUpDownQty";
            numericUpDownQty.Size = new Size(80, 30);
            numericUpDownQty.TabIndex = 4;
            numericUpDownQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelQtyLabel
            // 
            labelQtyLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            labelQtyLabel.AutoSize = true;
            labelQtyLabel.Font = new Font("Segoe UI", 10F);
            labelQtyLabel.ForeColor = Color.FromArgb(51, 51, 51);
            labelQtyLabel.Location = new Point(3, 15);
            labelQtyLabel.Name = "labelQtyLabel";
            labelQtyLabel.Size = new Size(80, 23);
            labelQtyLabel.TabIndex = 3;
            labelQtyLabel.Text = "Quantity:";
            // 
            // btnViewCart
            // 
            btnViewCart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnViewCart.BackColor = Color.FromArgb(70, 130, 180);
            btnViewCart.FlatStyle = FlatStyle.Flat;
            btnViewCart.Font = new Font("Segoe UI", 10F);
            btnViewCart.ForeColor = Color.White;
            btnViewCart.Location = new Point(691, 9);
            btnViewCart.Name = "btnViewCart";
            btnViewCart.Size = new Size(152, 36);
            btnViewCart.TabIndex = 7;
            btnViewCart.Text = "\U0001f6d2 View Cart";
            btnViewCart.UseVisualStyleBackColor = false;
            btnViewCart.Click += BtnViewCart_Click;
            // 
            // labelCartCount
            // 
            labelCartCount.AutoSize = true;
            labelCartCount.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelCartCount.ForeColor = Color.White;
            labelCartCount.Location = new Point(27, 5);
            labelCartCount.Name = "labelCartCount";
            labelCartCount.Size = new Size(28, 32);
            labelCartCount.TabIndex = 0;
            labelCartCount.Text = "0";
            // 
            // panelCartBadge
            // 
            panelCartBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelCartBadge.BackColor = Color.FromArgb(244, 67, 54);
            panelCartBadge.Controls.Add(labelCartCount);
            panelCartBadge.Location = new Point(760, 9);
            panelCartBadge.Name = "panelCartBadge";
            panelCartBadge.Size = new Size(112, 48);
            panelCartBadge.TabIndex = 6;
            // 
            // btnAddToCart
            // 
            btnAddToCart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddToCart.BackColor = Color.FromArgb(76, 175, 80);
            btnAddToCart.FlatStyle = FlatStyle.Flat;
            btnAddToCart.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddToCart.ForeColor = Color.White;
            btnAddToCart.Location = new Point(173, 9);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(150, 36);
            btnAddToCart.TabIndex = 5;
            btnAddToCart.Text = "+ Add to Cart";
            btnAddToCart.UseVisualStyleBackColor = false;
            btnAddToCart.Click += BtnAddToCart_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(btnViewCart);
            panel1.Controls.Add(numericUpDownQty);
            panel1.Controls.Add(btnAddToCart);
            panel1.Controls.Add(labelQtyLabel);
            panel1.Location = new Point(25, 543);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(847, 56);
            panel1.TabIndex = 0;
            // 
            // ProductScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 615);
            Controls.Add(labelTitle);
            Controls.Add(panel1);
            Controls.Add(labelSubtitle);
            Controls.Add(flowLayoutPanelProducts);
            Controls.Add(panelCartBadge);
            MinimumSize = new Size(912, 651);
            Name = "ProductScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Products";
            Load += ProductScreen_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownQty).EndInit();
            panelCartBadge.ResumeLayout(false);
            panelCartBadge.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAddToCart;
        private Panel panel1;
    }
}