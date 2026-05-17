using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientApp.Services;

namespace ClientApp
{
    public partial class StatusScreen : Form
    {
        private readonly CartApiService _apiService;

        public StatusScreen()
        {
            // 🌟 แก้จุดที่ 1: ลบ await LoadDataAsync() ออกจากตรงนี้
            InitializeComponent();
            _apiService = new CartApiService();
        }

        // 🌟 แก้จุดที่ 2: ตอนเปิดหน้าจอ ให้เรียกใช้ฟังก์ชัน LoadDataAsync ได้เลย ไม่ต้องเขียนโค้ดซ้ำ
        private async void StatusScreen_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }
        private async void StatusScreen_Activated(object sender, EventArgs e)
        {
            // ทุกครั้งที่หน้าจอนี้ถูกสลับกลับมาแสดงผล (โฟกัส) มันจะแอบรีเฟรชตัวเองให้อัตโนมัติแบบเรียลไทม์เลยครับ!
            await LoadDataAsync();
        }
        private async Task LoadDataAsync()
        {
            try
            {
                // 1. ดึงข้อมูลดิบจาก API (ที่อาจจะมีหลายชิ้นในบิลเดียวกัน)
                var rawStatuses = await _apiService.GetOrderStatusesAsync(AppSession.SessionId);

                if (rawStatuses == null || !rawStatuses.Any())
                {
                    dataGridViewStatus.DataSource = null;
                    return;
                }

                // 2. ทำการ GroupBy ด้วย ReceiptId เพื่อยุบรวมให้เหลือ 1 บิลต่อ 1 แถวเหมือนหน้า Seller
                var groupedStatuses = rawStatuses
                    .Where(o => !string.IsNullOrEmpty(o.ReceiptId))
                    .GroupBy(o => o.ReceiptId)
                    .Select(g =>
                    {
                        var firstItem = g.First();

                        // 🌟 ค้นหาไอเท็มในกลุ่มที่มีการอัปเดตสถานะไปไกลที่สุด (ป้องกันอาการเจอ Preparing บังตัวอื่น)
                        var activeItem = g.FirstOrDefault(x => !string.IsNullOrEmpty(x.TrackingNumber) && x.TrackingNumber != "ยังไม่มีเลขพัสดุ") ?? firstItem;

                        return new OrderStatusDto
                        {
                            ReceiptId = firstItem.ReceiptId,
                            OrderDate = firstItem.OrderDate,
                            // รวมชื่อสินค้าทุกชิ้นในบิลมาต่อกัน เช่น "Cotton T-Shirt (x1), Laptop Dell (x1)"
                            ProductName = string.Join(", ", g.Select(x => $"{x.ProductName} (x{x.Quantity})")),
                            Quantity = g.Sum(x => x.Quantity),
                            Status = activeItem.Status,
                            TrackingNumber = activeItem.TrackingNumber,
                            DeliveryTime = activeItem.DeliveryTime
                        };
                    })
                    .OrderByDescending(o => o.OrderDate) // เรียงลำดับเอาออเดอร์ใหม่ขึ้นก่อน
                    .ToList();

                // 3. ผูกข้อมูลที่จัดกลุ่มแล้วเข้าตาราง
                dataGridViewStatus.DataSource = groupedStatuses;

                // 4. ตกแต่งหัวตาราง (เหมือนเดิมของคุณ แต่เช็คความปลอดภัย)
                if (dataGridViewStatus.Columns.Count > 0)
                {
                    dataGridViewStatus.Columns["OrderDate"].HeaderText = "Date";
                    dataGridViewStatus.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                    // ซ่อนคอลัมน์ที่ไม่จำเป็นต้องแสดงบน UI เพื่อความสวยงาม
                    if (dataGridViewStatus.Columns["CartId"] != null) dataGridViewStatus.Columns["CartId"].Visible = false;
                    if (dataGridViewStatus.Columns["ReceiptId"] != null) dataGridViewStatus.Columns["ReceiptId"].Visible = true;
                    dataGridViewStatus.Columns["ReceiptId"].HeaderText = "Receipt ID";

                    dataGridViewStatus.Columns["ProductName"].HeaderText = "Item";
                    dataGridViewStatus.Columns["Quantity"].HeaderText = "Quantity";
                    dataGridViewStatus.Columns["Status"].HeaderText = "Status";
                    dataGridViewStatus.Columns["TrackingNumber"].HeaderText = "Tracking Number";
                    dataGridViewStatus.Columns["DeliveryTime"].HeaderText = "Delivery Time";

                    dataGridViewStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ดึงข้อมูลไม่สำเร็จ: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void flowLayoutPanelProducts_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            ProductScreen home = new ProductScreen();
            home.Show();
            this.Hide();
        }

        private void labelSubtitle_Click(object sender, EventArgs e)
        {

        }

        // 🌟 แก้จุดที่ 3: เติมคำว่า async เข้าไปตรงนี้
        private async void btnStatusRefresh_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
            MessageBox.Show("อัปเดตข้อมูลสถานะสินค้าล่าสุดเรียบร้อยแล้ว!", "รีเฟรชสำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

  
    
}