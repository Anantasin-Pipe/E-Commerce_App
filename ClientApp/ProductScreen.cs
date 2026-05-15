using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClientApp.Services;

namespace ClientApp
{
    public partial class ProductScreen : Form
    {
        private int _cartCount = 0;
        private ProductDto? _selectedProduct = null;
        private List<ProductDto> _products = new List<ProductDto>();
        private readonly IProductApiService _productApiService;

        private readonly CartApiService _cartApiService;
        public ProductScreen()
        {
            InitializeComponent();
            _productApiService = new ProductApiService();
            _cartApiService = new CartApiService();
            LoadProductsFromDatabase();
            UpdateCartBadge();
            LoadInitialCartCount();
        }

        /// <summary>
        /// Load products from database via API
        /// </summary>
        private async void LoadProductsFromDatabase()
        {
            try
            {
                _products = await _productApiService.GetAllProductsAsync();
                DisplayProductCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Fallback to sample products if database is unavailable
                LoadSampleProducts();
            }
        }

        /// <summary>
        /// Load sample products as fallback
        /// </summary>
        private void LoadSampleProducts()
        {
            _products = new List<ProductDto>
            {
                new ProductDto { Id = 1, SellerId = 1, Name = "Blue T-Shirt", Description = "Premium cotton blue shirt", Price = 1999 },
                new ProductDto { Id = 2, SellerId = 1, Name = "Red Mug", Description = "Ceramic coffee mug", Price = 850 },
                new ProductDto { Id = 3, SellerId = 2, Name = "Notebook Set", Description = "3-pack lined notebooks", Price = 1275 },
                new ProductDto { Id = 4, SellerId = 2, Name = "Laptop Bag", Description = "Professional 15-inch laptop bag", Price = 4500 },
                new ProductDto { Id = 5, SellerId = 3, Name = "Wireless Mouse", Description = "Bluetooth mouse with USB adapter", Price = 2499 }
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

        private Panel CreateProductCard(ProductDto product)
        {
            var card = new Panel
            {
                Size = new Size(220, 260),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(10),
                Tag = product.Id
            };

            // Product Image
            var pictureBox = new PictureBox
            {
                Size = new Size(200, 120),
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            if (!string.IsNullOrEmpty(product.ImageUrl))
            {
                try
                {
                    pictureBox.LoadAsync(product.ImageUrl);
                }
                catch
                {
                    // 🌟 ถ้าโหลด URL ไม่สำเร็จ ให้ใช้รูป Placeholder ของคุณแทน
                    pictureBox.Image = GetPlaceholderImage();
                }
            }
            else
            {
                // 🌟 ถ้าไม่มี URL เลย ก็ให้ใช้รูป Placeholder ของคุณเช่นกัน
                pictureBox.Image = GetPlaceholderImage();
            }

            card.Controls.Add(pictureBox);

            // Product Name
            var lblName = new Label
            {
                Text = product.Name,
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
                Text = $"฿{product.Price:N0}",
                Location = new Point(10, 165),
                Size = new Size(100, 20),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(76, 175, 80)
            };
            card.Controls.Add(lblPrice);

            // Description
            var lblDescription = new Label
            {
                Text = product.Description,
                Location = new Point(10, 190),
                Size = new Size(200, 20),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.Gray,
                AutoEllipsis = true
            };
            card.Controls.Add(lblDescription);

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

        private async void BtnAddToCart_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null)
            {
                MessageBox.Show("Please select a product first.", "No product selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int quantity = (int)numericUpDownQty.Value;

            try
            {
                bool isSuccess = await _cartApiService.AddToCartAsync(_selectedProduct.Id, quantity);

                if (isSuccess)
                {
                    _cartCount += quantity;
                    UpdateCartBadge();
                    MessageBox.Show($"Added {quantity} x {_selectedProduct.Name} to cart.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    numericUpDownQty.Value = 1;
                }
                else
                {
                    MessageBox.Show("Failed to add product to cart.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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

        // 🌟 เพิ่มฟังก์ชันนี้เข้าไป เพื่อให้ Constructor เรียกใช้งานได้
        private async void LoadInitialCartCount()
        {
            try
            {
                var cartItems = await _cartApiService.GetCartItemsAsync();

                // นับรวมจำนวนสินค้าทั้งหมดในตะกร้า
                _cartCount = cartItems.Sum(item => item.Quantity);
                UpdateCartBadge();
            }
            catch
            {
                // ถ้าดึงไม่ได้ ให้แสดงเป็น 0 ไปก่อน
                _cartCount = 0;
                UpdateCartBadge();
            }
        }

        private void UpdateCartBadge()
        {
            labelCartCount.Text = _cartCount.ToString();
        }


        private void flowLayoutPanelProducts_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProductScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
