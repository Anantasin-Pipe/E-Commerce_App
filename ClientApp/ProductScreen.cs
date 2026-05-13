using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class ProductScreen : Form
    {
        private BindingList<Product> _products = new BindingList<Product>();
        private int _cartCount = 0;

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
            InitializeDataGrid();
            LoadProducts();
            UpdateCartBadge();
        }

        private void InitializeDataGrid()
        {
            dataGridViewProducts.DataSource = _products;
            dataGridViewProducts.SelectionChanged += DataGridViewProducts_SelectionChanged;
        }

        private void LoadProducts()
        {
            // Sample products - replace with API call
            _products.Add(new Product { ProductId = 1, ProductName = "Blue T-Shirt", Description = "Premium cotton blue shirt", Price = 19.99m, Stock = 50 });
            _products.Add(new Product { ProductId = 2, ProductName = "Red Mug", Description = "Ceramic coffee mug", Price = 8.50m, Stock = 100 });
            _products.Add(new Product { ProductId = 3, ProductName = "Notebook Set", Description = "3-pack lined notebooks", Price = 12.75m, Stock = 75 });
            _products.Add(new Product { ProductId = 4, ProductName = "Laptop Bag", Description = "Professional 15-inch laptop bag", Price = 45.00m, Stock = 30 });
            _products.Add(new Product { ProductId = 5, ProductName = "Wireless Mouse", Description = "Bluetooth mouse with USB adapter", Price = 24.99m, Stock = 120 });
        }

        private void DataGridViewProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count > 0)
            {
                numericUpDownQty.Value = 1;
            }
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to add to cart.", "No product selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dataGridViewProducts.SelectedRows[0];
            var product = selectedRow.DataBoundItem as Product;
            if (product == null) return;

            int quantity = (int)numericUpDownQty.Value;

            if (product.Stock < quantity)
            {
                MessageBox.Show($"Insufficient stock. Only {product.Stock} items available.", "Stock unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: Add to cart service/list
            _cartCount++;
            UpdateCartBadge();

            MessageBox.Show($"Added {quantity} x {product.ProductName} to cart.", "Added to Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
            numericUpDownQty.Value = 1;
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
    }
}
