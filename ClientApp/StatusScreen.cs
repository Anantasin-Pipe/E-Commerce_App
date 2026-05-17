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

        private async Task LoadDataAsync()
        {
            try
            {
                // ดึงข้อมูลจาก API
                var statuses = await _apiService.GetOrderStatusesAsync(AppSession.SessionId);

                dataGridViewStatus.DataSource = statuses;

                // ตกแต่งหัวตาราง
                if (dataGridViewStatus.Columns.Count > 0)
                {
                    dataGridViewStatus.Columns["OrderDate"].HeaderText = "Date";
                    dataGridViewStatus.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                    dataGridViewStatus.Columns["CartId"].Visible = false;
                    dataGridViewStatus.Columns["ReceiptId"].Visible = false; // ปิด ReceiptId ไว้ด้วยจะได้สวยๆ

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

    // 🌟 คลาส Dto 
    public class OrderStatusDto
    {
        public DateTime OrderDate { get; set; }
        public int ReceiptId { get; set; }
        public int CartId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Status { get; set; } = string.Empty;
        public string TrackingNumber { get; set; } = string.Empty;
        public string DeliveryTime { get; set; } = string.Empty;
    }
}