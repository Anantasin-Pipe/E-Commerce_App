using ClientApp;
using ClientApp.Services;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace SellerApp
{
    public partial class SellerScreen : Form
    {
        private BindingList<ProductDto> _products = new BindingList<ProductDto>();
        private readonly IProductApiService _productApiService;
        private readonly int _currentSellerId = 1;
        private readonly CartApiService _cartApiService;

        // 🌟 1. กำหนดเป็น string เพื่อรองรับรหัสแบบ "REC-xxxx"
        private string _selectedReceiptId = string.Empty;

        private BindingList<OrderStatusDto> _orderList = new BindingList<OrderStatusDto>();

        public SellerScreen()
        {
            InitializeComponent();

            _productApiService = new ProductApiService();
            _cartApiService = new CartApiService();

            // ป้องกันการผูก Event ซ้ำซ้อนของปุ่มกด
            btnUpdateStatus.Click -= btnUpdateStatus_Click;
            btnUpdateStatus.Click += btnUpdateStatus_Click;

            InitOrderUI();
            LoadOrdersAsync(); // โหลดออเดอร์มาแสดง

            InitializeDataGrid();
            LoadProductsFromDatabase();
        }

        private void InitializeDataGrid()
        {
            // คุมตารางสินค้าตามเดิม
            dataGridViewProducts.AutoGenerateColumns = false;
            if (dataGridViewProducts.Columns["colProductName"] != null)
            {
                dataGridViewProducts.Columns["colProductName"].DataPropertyName = "Name";
            }
            dataGridViewProducts.DataSource = _products;
            dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            LoadOrdersAsync();
            MessageBox.Show("อัปเดตข้อมูลสินค้าและรายการออเดอร์ล่าสุดเรียบร้อยแล้ว!", "รีเฟรชสำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        // 🌟 โซนระบบจัดการออเดอร์ 
        // =======================================================

        private void InitOrderUI()
        {
            if (cbStatus.Items.Count == 0)
            {
                cbStatus.Items.Add("Preparing"); // Index 0
                cbStatus.Items.Add("Shipping");   // Index 1
                cbStatus.Items.Add("Delivered"); // Index 2
            }
            cbStatus.SelectedIndex = 0;
        }

        private async Task LoadOrdersAsync()
        {
            try
            {
                var ordersFromApi = await _cartApiService.GetAllOrdersForSellerAsync();

                dataGridViewOrders.CellClick -= dataGridViewOrders_CellClick;
                dataGridViewOrders.AutoGenerateColumns = true;

                _orderList.Clear();

                // 🌟 2. กรองเฉพาะรายการที่มี ReceiptId และมัดรวมรายการ
                var groupedOrders = ordersFromApi
      .Where(o => !string.IsNullOrEmpty(o.ReceiptId))
      .GroupBy(o => o.ReceiptId)
      .Select(g =>
      {
          var firstItem = g.First();

          // 🌟 ค้นหาแถวที่มีการอัปเดตสถานะไปไกลที่สุดในกลุ่มบิลนี้ (เพื่อไม่ให้โดนค่า Preparing บัง)
          // โดยเรียงลำดับตามสถานะ หรือค้นหาตัวที่มีเลข Tracking ก่อน
          var updatedItem = g.OrderByDescending(x => x.Status).FirstOrDefault() ?? firstItem;

          // หรือถ้า Status เป็น string และอยากได้ตัวที่มีเลขพัสดุชัวร์ๆ:
          var activeTrackingItem = g.FirstOrDefault(x => !string.IsNullOrEmpty(x.TrackingNumber) && x.TrackingNumber != "ยังไม่มีเลขพัสดุ") ?? firstItem;

          return new OrderStatusDto
          {
              ReceiptId = firstItem.ReceiptId,
              OrderDate = firstItem.OrderDate,
              ProductName = string.Join(", ", g.Select(x => $"{x.ProductName} (x{x.Quantity})")),
              Quantity = g.Sum(x => x.Quantity),

              // ✅ เปลี่ยนมาดึงจากตัวที่อัปเดตเลขแทร็กกิ้งล่าสุดแทน firstItem ดั้งเดิมครับ!
              Status = activeTrackingItem.Status,
              TrackingNumber = activeTrackingItem.TrackingNumber,
              DeliveryTime = activeTrackingItem.DeliveryTime
          };
      }).ToList(); // อย่าลืม .ToList() หรืออัปเดตลง BindingList นะครับ

                foreach (var order in groupedOrders)
                {
                    _orderList.Add(order);
                }

                dataGridViewOrders.DataSource = null;
                dataGridViewOrders.DataSource = _orderList;

                // จัดการหน้าตาคอลัมน์
                if (dataGridViewOrders.Columns["CartId"] != null) dataGridViewOrders.Columns["CartId"].Visible = false;

                // 🌟 3. โชว์คอลัมน์รหัสใบเสร็จ 
                if (dataGridViewOrders.Columns["ReceiptId"] != null)
                {
                    dataGridViewOrders.Columns["ReceiptId"].HeaderText = "Receipt ID";
                    dataGridViewOrders.Columns["ReceiptId"].DisplayIndex = 0; // ย้ายไปไว้ซ้ายสุด
                    dataGridViewOrders.Columns["ReceiptId"].Visible = true;
                }

                if (dataGridViewOrders.Columns["OrderDate"] != null)
                {
                    dataGridViewOrders.Columns["OrderDate"].HeaderText = "Order Date";
                    dataGridViewOrders.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dataGridViewOrders.Columns["OrderDate"].DefaultCellStyle.FormatProvider = new CultureInfo("th-TH");
                }
                if (dataGridViewOrders.Columns["ProductName"] != null) dataGridViewOrders.Columns["ProductName"].HeaderText = "Product";
                if (dataGridViewOrders.Columns["Quantity"] != null) dataGridViewOrders.Columns["Quantity"].HeaderText = "Quantity";
                if (dataGridViewOrders.Columns["Status"] != null) dataGridViewOrders.Columns["Status"].HeaderText = "Status";
                if (dataGridViewOrders.Columns["TrackingNumber"] != null) dataGridViewOrders.Columns["TrackingNumber"].HeaderText = "TrackingNumber";
                if (dataGridViewOrders.Columns["DeliveryTime"] != null) dataGridViewOrders.Columns["DeliveryTime"].HeaderText = "DeliveryTime";

                dataGridViewOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewOrders.CellClick += dataGridViewOrders_CellClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"โหลดออเดอร์ไม่สำเร็จ: {ex.Message}");
                dataGridViewOrders.CellClick -= dataGridViewOrders_CellClick;
                dataGridViewOrders.CellClick += dataGridViewOrders_CellClick;
            }
        }

        private void dataGridViewOrders_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewOrders.Rows[e.RowIndex];

                if (row.Cells["ReceiptId"].Value != null)
                {
                    // 🌟 4. แปลงค่าให้เป็น string
                    _selectedReceiptId = row.Cells["ReceiptId"].Value.ToString() ?? "";
                }

                string currentTracking = row.Cells["TrackingNumber"].Value?.ToString() ?? "";
                txtTracking.Text = (currentTracking == "ยังไม่มีเลขพัสดุ" || string.IsNullOrWhiteSpace(currentTracking)) ? "" : currentTracking;

                string statusTxt = row.Cells["Status"].Value?.ToString() ?? "";
                if (statusTxt.Contains("Preparing")) cbStatus.SelectedIndex = 0;
                else if (statusTxt.Contains("Shipping")) cbStatus.SelectedIndex = 1;
                else if (statusTxt.Contains("Delivered")) cbStatus.SelectedIndex = 2;
            }
        }

        private async void btnUpdateStatus_Click(object? sender, EventArgs e)
        {
            // 🌟 5. ตรวจสอบว่า string ว่างหรือไม่
            if (string.IsNullOrEmpty(_selectedReceiptId))
            {
                MessageBox.Show("กรุณาคลิกเลือกออเดอร์จากตารางก่อนครับ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int newStatus = cbStatus.SelectedIndex;
            string tracking = txtTracking.Text.Trim();

            if (string.IsNullOrWhiteSpace(tracking) && newStatus >= 1)
            {
                tracking = GenerateTrackingNumber();
                txtTracking.Text = tracking;
            }

            dataGridViewOrders.CellClick -= dataGridViewOrders_CellClick;

            string result = await _cartApiService.UpdateOrderStatusAsync(_selectedReceiptId, newStatus, tracking);

            if (result == "SUCCESS")
            {
                MessageBox.Show("อัปเดตสถานะออเดอร์เรียบร้อยแล้ว!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ✅ หาข้อมูลแถวที่กำลังเลือกอยู่ใน BindingList ของหน้าจอ
                var orderToUpdate = _orderList.FirstOrDefault(o => o.ReceiptId == _selectedReceiptId);
                if (orderToUpdate != null)
                {
                    // 1. อัปเดตข้อความสถานะตามที่เราเลือกใน ComboBox
                    orderToUpdate.Status = cbStatus.SelectedItem?.ToString() ?? "Preparing";

                    // 2. อัปเดตเลขแทร็กกิ้งบนหน้าจอทันที
                    orderToUpdate.TrackingNumber = tracking;

                    // 3. อัปเดตเวลาจัดส่ง (จำลองให้ตรงกับหลังบ้าน)
                    if (newStatus == 0)
                    {
                        orderToUpdate.DeliveryTime = "ยังไม่ได้จัดส่ง";
                    }
                    else
                    {
                        orderToUpdate.DeliveryTime = DateTime.Now.ToString("d/M/yyyy HH:mm", new System.Globalization.CultureInfo("th-TH"));
                    }

                    // 4. สั่งให้ตาราง DataGridView วาดหน้าจอใหม่ (Refresh UI)
                    _orderList.ResetBindings();
                }

                // ไม่ต้องเรียก LoadOrdersAsync(); ซ้ำให้เปลืองเน็ตแล้วครับ ข้อมูลเปลี่ยนชัวร์!
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

        private void dataGridViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}