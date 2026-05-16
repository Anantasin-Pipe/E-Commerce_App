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
            InitializeComponent();
            _apiService = new CartApiService();
        }

        // โหลดข้อมูลทันทีที่เปิดหน้านี้ขึ้นมา
        private async void StatusScreen_Load(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show($"กำลังดึงข้อมูลสำหรับ Session: {AppSession.SessionId}", "Debug Check");
                // ดึงข้อมูลจาก API (ต้องมีฟังก์ชัน GetOrderStatusesAsync ใน CartApiService ก่อนนะ)
                var statuses = await _apiService.GetOrderStatusesAsync(AppSession.SessionId);

                dataGridViewStatus.DataSource = statuses;

                // ตกแต่งหัวตาราง
                if (dataGridViewStatus.Columns.Count > 0)
                {
                    dataGridViewStatus.Columns["OrderDate"].HeaderText = "Date";
                    dataGridViewStatus.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                    dataGridViewStatus.Columns["CartId"].Visible = false;

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
    }

    // 🌟 เอาคลาส Dto มาแปะไว้ท้ายไฟล์แบบนี้ได้เลย สะดวกดีครับ
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
