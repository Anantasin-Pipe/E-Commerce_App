using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class ProductScreen : Form
    {
        private int _cartCount = 0;
        private Product _selectedProduct = null;
        private List<Product> _products = new List<Product>();

        public class Product
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public decimal Price { get; set; }
            public int Stock { get; set; }
        }

        public ProductScreen()
        {
            InitializeComponent();
            LoadSampleProducts();
            UpdateCartBadge();
        }

        /// <summary>
        /// Load sample products for display
        /// </summary>
        private void LoadSampleProducts()
        {
            _products = new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Blue T-Shirt", Description = "Premium cotton blue shirt", Price = 19.99m, Stock = 50 },
                new Product { ProductId = 2, ProductName = "Red Mug", Description = "Ceramic coffee mug", Price = 8.50m, Stock = 100 },
                new Product { ProductId = 3, ProductName = "Notebook Set", Description = "3-pack lined notebooks", Price = 12.75m, Stock = 75 },
                new Product { ProductId = 4, ProductName = "Laptop Bag", Description = "Professional 15-inch laptop bag", Price = 45.00m, Stock = 30 },
                new Product { ProductId = 5, ProductName = "Wireless Mouse", Description = "Bluetooth mouse with USB adapter", Price = 24.99m, Stock = 120 }
            };

            DisplayProductCards();
        }

        private void DisplayProductCards()
        {
            flowLayoutPanelProducts.Controls.Clear();

            foreach (var product in _products)
            {
                var productCard = CreateProductCard(product);
                flowLayoutPanelProducts.Controls.Add(productCard);
            }
        }

        private Panel CreateProductCard(Product product)
        {
            var card = new Panel
            {
                Size = new Size(220, 260),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(10),
                Tag = product.ProductId
            };

            // Product Image
            var pictureBox = new PictureBox
            {
                Size = new Size(200, 120),
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(240, 240, 240),
                BorderStyle = BorderStyle.FixedSingle
            };

            try
            {
                pictureBox.Image = GetPlaceholderImage();
            }
            catch
            {
                pictureBox.Image = GetPlaceholderImage();
            }

            card.Controls.Add(pictureBox);

            // Product Name
            var lblName = new Label
            {
                Text = product.ProductName,
                Location = new Point(10, 135),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(51, 51, 51),
                AutoSize = false
            };
            card.Controls.Add(lblName);

            // Price
            var lblPrice = new Label
            {
                Text = $"${product.Price:F2}",
                Location = new Point(10, 165),
                Size = new Size(100, 20),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(76, 175, 80)
            };
            card.Controls.Add(lblPrice);

            // Stock Status
            var stockColor = product.Stock > 10 ? Color.Green : product.Stock > 0 ? Color.Orange : Color.Red;
            var lblStock = new Label
            {
                Text = $"Stock: {product.Stock}",
                Location = new Point(10, 190),
                Size = new Size(200, 20),
                Font = new Font("Segoe UI", 9F),
                ForeColor = stockColor
            };
            card.Controls.Add(lblStock);

            // Select Button
            var btnSelect = new Button
            {
                Text = "Select",
                Location = new Point(10, 215),
                Size = new Size(200, 35),
                BackColor = Color.FromArgb(70, 130, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Tag = product
            };

            btnSelect.Click += (sender, e) =>
            {
                _selectedProduct = product;
                numericUpDownQty.Value = 1;
                btnAddToCart.Focus();

                // Highlight selected card
                foreach (Panel p in flowLayoutPanelProducts.Controls.OfType<Panel>())
                {
                    p.BorderStyle = BorderStyle.FixedSingle;
                    p.BackColor = Color.White;
                }
                card.BorderStyle = BorderStyle.Fixed3D;
                card.BackColor = Color.FromArgb(240, 248, 255);
            };

            card.Controls.Add(btnSelect);

            return card;
        }

        private Image GetPlaceholderImage()
        {
            var bitmap = new Bitmap(200, 120);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.FromArgb(220, 220, 220));
                g.DrawString("No Image", new Font("Segoe UI", 12F), Brushes.Gray, new PointF(50, 50));
            }
            return bitmap;
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null)
            {
                MessageBox.Show("Please select a product first.", "No product selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int quantity = (int)numericUpDownQty.Value;

            if (_selectedProduct.Stock < quantity)
            {
                MessageBox.Show($"Insufficient stock. Only {_selectedProduct.Stock} items available.", "Stock unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _cartCount++;
                UpdateCartBadge();
                MessageBox.Show($"Added {quantity} x {_selectedProduct.ProductName} to cart.", "Added to Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numericUpDownQty.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding to cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnViewCart_Click(object sender, EventArgs e)
        {
            CartScreen cart = new CartScreen();
            cart.Show();
            this.Hide();
        }

        private void UpdateCartBadge()
        {
            labelCartCount.Text = _cartCount.ToString();
        }

        private void panelProductSelector_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
