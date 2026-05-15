using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientApp.Services;

namespace SellerApp
{
    public partial class SellerScreen : Form
    {
        private BindingList<ProductDto> _products = new BindingList<ProductDto>();
        private readonly IProductApiService _productApiService;
        private readonly int _currentSellerId = 1;

        public SellerScreen()
        {
            InitializeComponent();

            _productApiService = new ProductApiService();

            InitializeDataGrid();

            LoadProductsFromDatabase();
        }

        private void InitializeDataGrid()
        {
            // 🌟 จุดที่ 1: ปิดการสร้างคอลัมน์อัตโนมัติ (ป้องกันคอลัมน์ Name ไปงอกต่อท้าย)
            dataGridViewProducts.AutoGenerateColumns = false;

            // 🌟 จุดที่ 1: บังคับให้คอลัมน์ Product Name ไปดึงข้อมูลจาก Property "Name" ใน ProductDto
            if (dataGridViewProducts.Columns["colProductName"] != null)
            {
                dataGridViewProducts.Columns["colProductName"].DataPropertyName = "Name";
            }

            dataGridViewProducts.DataSource = _products;
            dataGridViewProducts.CellEndEdit += DataGridViewProducts_CellEndEdit;
            _products.ListChanged += Products_ListChanged;
        }

        private async void LoadProductsFromDatabase()
        {
            try
            {
                var productsFromDb = await _productApiService.GetAllProductsAsync();

                // 🌟 จุดที่ 2: ยกเลิกการกรอง SellerId และนำข้อมูลทั้งหมดใส่ลง Grid เลย
                _products.Clear();
                foreach (var p in productsFromDb)
                {
                    _products.Add(p);
                }

                UpdateProductCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products from database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            UpdateProductCount();
        }

        private void Products_ListChanged(object sender, ListChangedEventArgs e)
        {
            UpdateProductCount();
        }

        private async void BtnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxProductName.Text))
                {
                    MessageBox.Show("Please enter a product name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxProductName.Focus();
                    return;
                }

                if (!decimal.TryParse(textBoxPrice.Text, out decimal price) || price < 0)
                {
                    MessageBox.Show("Please enter a valid price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxPrice.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxDescription.Text))
                {
                    MessageBox.Show("Please enter a product description.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxDescription.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxImageUrl.Text))
                {
                    MessageBox.Show("Please enter an image URL.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxImageUrl.Focus();
                    return;
                }

                var newProduct = new ProductDto
                {
                    SellerId = _currentSellerId,
                    Name = textBoxProductName.Text.Trim(),
                    Price = (int)price,
                    Description = textBoxDescription.Text.Trim(),
                    ImageUrl = textBoxImageUrl.Text.Trim()
                };

                bool isSuccess = await _productApiService.AddProductAsync(newProduct);

                if (isSuccess)
                {
                    MessageBox.Show($"Product '{newProduct.Name}' added successfully to database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearInputFields();

                    LoadProductsFromDatabase();
                }
                else
                {
                    MessageBox.Show("Failed to add product to database.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnRemoveProduct_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = dataGridViewProducts.Rows.Cast<DataGridViewRow>()
                    .Where(r => (bool)(r.Cells[0].Value ?? false))
                    .ToList();

                if (selectedRows.Count == 0)
                {
                    MessageBox.Show("Please select at least one product to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var confirm = MessageBox.Show(
                    $"Are you sure you want to remove {selectedRows.Count} product(s) from the database?",
                    "Confirm Removal",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                int successCount = 0;

                foreach (var row in selectedRows)
                {
                    if (row.Index >= 0 && row.Index < _products.Count)
                    {
                        var product = _products[row.Index];

                        bool isDeleted = await _productApiService.DeleteProductAsync(product.Id);

                        if (isDeleted)
                        {
                            successCount++;
                        }
                        else
                        {
                            MessageBox.Show($"Failed to delete '{product.Name}'.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                if (successCount > 0)
                {
                    MessageBox.Show($"Successfully removed {successCount} product(s).", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProductsFromDatabase();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadProductsFromDatabase();
            MessageBox.Show("Product list refreshed from database.", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearInputFields()
        {
            textBoxProductName.Clear();
            textBoxPrice.Text = "0.00";
            textBoxDescription.Clear();
            textBoxImageUrl.Clear();
            textBoxProductName.Focus();
        }

        private void UpdateProductCount()
        {
            labelProductCount.Text = $"Total: {_products.Count} products";
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}