using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private readonly CartApiService _cartApiService;
        private int _selectedReceiptId = 0;

        public SellerScreen()
        {
            InitializeComponent();

            _productApiService = new ProductApiService();
            _cartApiService = new CartApiService();

            // 🌟 ย้ายการเสียบสายไฟ Event มาคุมด้วยโค้ดผ่านฟังก์ชันโหลดตารางแทน เพื่อไม่ให้ทำงานชนกัน
            btnUpdateStatus.Click += btnUpdateStatus_Click;

            InitOrderUI();
            LoadOrdersAsync(); // โหลดออเดอร์มาแสดง

            InitializeDataGrid();
            LoadProductsFromDatabase();
        }

        private void InitializeDataGrid()
        {
            dataGridViewProducts.AutoGenerateColumns = false;

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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }

        // =======================================================
        // 🌟 โซนระบบจัดการออเดอร์ (แก้ไขบักส์ระบบกะพริบรีเฟรชข้อมูล)
        // =======================================================

        private void InitOrderUI()
        {
            if (cbStatus.Items.Count == 0)
            {
                cbStatus.Items.Add("Preparing (กำลังเตรียมของ)"); // Index 0
                cbStatus.Items.Add("Shipping (กำลังจัดส่ง)");   // Index 1
                cbStatus.Items.Add("Delivered (จัดส่งสำเร็จ)"); // Index 2
            }
            cbStatus.SelectedIndex = 0;
        }

        private async void LoadOrdersAsync()
        {
            try
            {
                var orders = await _cartApiService.GetAllOrdersForSellerAsync();

                // 🌟 ไม้ตาย: ถอดสายไฟ Event คลิกตารางออกไปก่อนชั่วคราว เพื่อไม่ให้เงื่อนไขชนกันตอนโหลดข้อมูลใหม่
                dataGridViewOrders.CellClick -= dataGridViewOrders_CellClick;

                dataGridViewOrders.DataSource = null;
                dataGridViewOrders.DataSource = orders;

                if (dataGridViewOrders.Columns["CartId"] != null)
                    dataGridViewOrders.Columns["CartId"].Visible = false;

                if (dataGridViewOrders.Columns["ReceiptId"] != null)
                    dataGridViewOrders.Columns["ReceiptId"].Visible = false;

                if (dataGridViewOrders.Columns["OrderDate"] != null)
                    dataGridViewOrders.Columns["OrderDate"].HeaderText = "วันที่สั่งซื้อ";

                if (dataGridViewOrders.Columns["ProductName"] != null)
                    dataGridViewOrders.Columns["ProductName"].HeaderText = "สินค้า";

                if (dataGridViewOrders.Columns["Quantity"] != null)
                    dataGridViewOrders.Columns["Quantity"].HeaderText = "จำนวน";

                if (dataGridViewOrders.Columns["Status"] != null)
                    dataGridViewOrders.Columns["Status"].HeaderText = "สถานะ";

                if (dataGridViewOrders.Columns["TrackingNumber"] != null)
                    dataGridViewOrders.Columns["TrackingNumber"].HeaderText = "เลขพัสดุ";

                // 🌟 เพิ่มการตั้งค่าแสดงผลของคอลัมน์เวลา พ.ศ. ไทย ในหน้าตารางหลังบ้าน
                if (dataGridViewOrders.Columns["DeliveryTime"] != null)
                    dataGridViewOrders.Columns["DeliveryTime"].HeaderText = "DeliveryTime";

                dataGridViewOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // 🌟 เสียบสายไฟ Event คลิกตารางกลับคืนเข้าไปเมื่อระบบเซ็ตตารางใหม่เสร็จสมบูรณ์ 100%
                dataGridViewOrders.CellClick += dataGridViewOrders_CellClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"โหลดออเดอร์ไม่สำเร็จ: {ex.Message}");
                dataGridViewOrders.CellClick += dataGridViewOrders_CellClick; // ป้องกันบักกรณีพังแล้วลืมต่อคืน
            }
        }

        private void dataGridViewOrders_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewOrders.Rows[e.RowIndex];

                _selectedReceiptId = Convert.ToInt32(row.Cells["ReceiptId"].Value);

                string currentTracking = row.Cells["TrackingNumber"].Value?.ToString() ?? "";
                txtTracking.Text = currentTracking == "ยังไม่มีเลขพัสดุ" ? "" : currentTracking;

                string statusTxt = row.Cells["Status"].Value.ToString();
                if (statusTxt.Contains("Preparing")) cbStatus.SelectedIndex = 0;
                else if (statusTxt.Contains("Shipping")) cbStatus.SelectedIndex = 1;
                else if (statusTxt.Contains("Delivered")) cbStatus.SelectedIndex = 2;
            }
        }

        private async void btnUpdateStatus_Click(object? sender, EventArgs e)
        {
            if (_selectedReceiptId == 0)
            {
                MessageBox.Show("กรุณาคลิกเลือกออเดอร์จากตารางก่อนครับ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int newStatus = cbStatus.SelectedIndex;
            string tracking = txtTracking.Text.Trim();

            // ถ้าช่องเลขพัสดุว่างเปล่า และสถานะถูกเปลี่ยนเป็น Shipping (1) หรือ Delivered (2) สั่งระบบเจนให้ทันที
            if (string.IsNullOrWhiteSpace(tracking) && newStatus >= 1)
            {
                tracking = GenerateTrackingNumber();
                txtTracking.Text = tracking;
            }

            bool success = await _cartApiService.UpdateOrderStatusAsync(_selectedReceiptId, newStatus, tracking);

            if (success)
            {
                MessageBox.Show("อัปเดตสถานะออเดอร์เรียบร้อยแล้ว!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 🌟 สลับลำดับเคลียร์ค่า State หน้าจอให้หมดจดก่อนลื่นไหลไม่มีกระตุก
                _selectedReceiptId = 0;
                txtTracking.Text = "";
                cbStatus.SelectedIndex = 0;

                // สั่งโหลดหน้าตาข้อมูลเวอร์ชันล่าสุดมาวาดใหม่ปิดท้ายรายการ
                LoadOrdersAsync();
            }
        }

        private string GenerateTrackingNumber()
        {
            Random random = new Random();
            string datePart = DateTime.Now.ToString("yyMMdd");
            string randomPart = random.Next(1000, 9999).ToString();

            return $"TH{datePart}{randomPart}";
        }

        private void SellerScreen_Load(object sender, EventArgs e) { }
        private void dataGridViewOrders_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void SellerScreen_Load_1(object sender, EventArgs e) { }
    }
}