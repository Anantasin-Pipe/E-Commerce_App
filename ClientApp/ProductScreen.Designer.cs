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
            btnStatus = new Button();
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
            labelTitle.Location = new Point(22, 11);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(116, 32);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Products";
            // 
            // labelSubtitle
            // 
            labelSubtitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelSubtitle.AutoSize = true;
            labelSubtitle.Font = new Font("Segoe UI", 10F);
            labelSubtitle.ForeColor = Color.FromArgb(100, 100, 100);
            labelSubtitle.Location = new Point(22, 38);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(187, 19);
            labelSubtitle.TabIndex = 1;
            labelSubtitle.Text = "Browse and select your items";
            // 
            // flowLayoutPanelProducts
            // 
            flowLayoutPanelProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelProducts.AutoScroll = true;
            flowLayoutPanelProducts.BackColor = Color.White;
            flowLayoutPanelProducts.Location = new Point(22, 56);
            flowLayoutPanelProducts.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            flowLayoutPanelProducts.Size = new Size(741, 346);
            flowLayoutPanelProducts.TabIndex = 2;
            flowLayoutPanelProducts.Paint += flowLayoutPanelProducts_Paint;
            // 
            // numericUpDownQty
            // 
            numericUpDownQty.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            numericUpDownQty.BackColor = Color.White;
            numericUpDownQty.Font = new Font("Segoe UI", 10F);
            numericUpDownQty.Location = new Point(75, 9);
            numericUpDownQty.Margin = new Padding(3, 2, 3, 2);
            numericUpDownQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownQty.Name = "numericUpDownQty";
            numericUpDownQty.Size = new Size(70, 25);
            numericUpDownQty.TabIndex = 4;
            numericUpDownQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelQtyLabel
            // 
            labelQtyLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            labelQtyLabel.AutoSize = true;
            labelQtyLabel.Font = new Font("Segoe UI", 10F);
            labelQtyLabel.ForeColor = Color.FromArgb(51, 51, 51);
            labelQtyLabel.Location = new Point(3, 11);
            labelQtyLabel.Name = "labelQtyLabel";
            labelQtyLabel.Size = new Size(66, 19);
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
            btnViewCart.Location = new Point(605, 7);
            btnViewCart.Margin = new Padding(3, 2, 3, 2);
            btnViewCart.Name = "btnViewCart";
            btnViewCart.Size = new Size(133, 27);
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
            labelCartCount.Location = new Point(24, 4);
            labelCartCount.Name = "labelCartCount";
            labelCartCount.Size = new Size(23, 25);
            labelCartCount.TabIndex = 0;
            labelCartCount.Text = "0";
            // 
            // panelCartBadge
            // 
            panelCartBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelCartBadge.BackColor = Color.FromArgb(244, 67, 54);
            panelCartBadge.Controls.Add(labelCartCount);
            panelCartBadge.Location = new Point(665, 7);
            panelCartBadge.Margin = new Padding(3, 2, 3, 2);
            panelCartBadge.Name = "panelCartBadge";
            panelCartBadge.Size = new Size(98, 36);
            panelCartBadge.TabIndex = 6;
            // 
            // btnAddToCart
            // 
            btnAddToCart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddToCart.BackColor = Color.FromArgb(76, 175, 80);
            btnAddToCart.FlatStyle = FlatStyle.Flat;
            btnAddToCart.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddToCart.ForeColor = Color.White;
            btnAddToCart.Location = new Point(151, 7);
            btnAddToCart.Margin = new Padding(3, 2, 3, 2);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(131, 27);
            btnAddToCart.TabIndex = 5;
            btnAddToCart.Text = "+ Add to Cart";
            btnAddToCart.UseVisualStyleBackColor = false;
            btnAddToCart.Click += BtnAddToCart_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(btnStatus);
            panel1.Controls.Add(btnViewCart);
            panel1.Controls.Add(numericUpDownQty);
            panel1.Controls.Add(btnAddToCart);
            panel1.Controls.Add(labelQtyLabel);
            panel1.Location = new Point(22, 407);
            panel1.Name = "panel1";
            panel1.Size = new Size(741, 42);
            panel1.TabIndex = 0;
            // 
            // btnStatus
            // 
            btnStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnStatus.BackColor = Color.FromArgb(70, 130, 180);
            btnStatus.FlatStyle = FlatStyle.Flat;
            btnStatus.Font = new Font("Segoe UI", 10F);
            btnStatus.ForeColor = Color.White;
            btnStatus.Location = new Point(466, 7);
            btnStatus.Margin = new Padding(3, 2, 3, 2);
            btnStatus.Name = "btnStatus";
            btnStatus.Size = new Size(133, 27);
            btnStatus.TabIndex = 8;
            btnStatus.Text = "View Status";
            btnStatus.UseVisualStyleBackColor = false;
            btnStatus.Click += btnStatus_Click;
            // 
            // ProductScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(labelTitle);
            Controls.Add(panel1);
            Controls.Add(labelSubtitle);
            Controls.Add(flowLayoutPanelProducts);
            Controls.Add(panelCartBadge);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(800, 498);
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
        private Button btnStatus;
    }
}