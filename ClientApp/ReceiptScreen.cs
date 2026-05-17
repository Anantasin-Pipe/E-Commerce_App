using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class ReceiptScreen : Form
    {
        private BindingList<ReceiptItem> _items = new BindingList<ReceiptItem>();
        // 🌟 แก้ให้ภาษีเป็น 7% (0.07) เพื่อให้คำนวณยอดตรงกับหน้า Checkout
        private const decimal TAX_RATE = 0.07m;

        public class ReceiptItem
        {
            public string ProductName { get; set; } = string.Empty;
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; } = 1;
            public decimal SubTotal => UnitPrice * Quantity;
        }

        // Constructor ใหม่รับข้อมูลจริงจาก CheckoutScreen
        public ReceiptScreen(List<ReceiptItem> items, decimal subtotal,
                             decimal shippingCost, string paymentMethod, DateTime paidDate)
        {
            InitializeComponent();
            InitializeDataGrid();

            // โหลดข้อมูลจริงแทน Sample
            foreach (var item in items)
                _items.Add(item);

            decimal tax = subtotal * TAX_RATE;
            decimal total = subtotal + shippingCost + tax;

            // 🌟 แก้ตรงนี้ให้เป็น ฿ ทั้งหมด (ของเดิมตรงนี้ยังเป็น .ToString("C2") อยู่)
            textBoxSubtotal.Text = $"฿{subtotal:N2}";
            textBoxShipping.Text = $"฿{shippingCost:N2}";
            textBoxTax.Text = $"฿{tax:N2}";
            textBoxTotal.Text = $"฿{total:N2}";

            textBoxPaymentMethod.Text = paymentMethod;
            textBoxPaidDate.Text = paidDate.ToString("MMMM dd, yyyy - h:mm tt");

            labelReceiptNumber.Text = $"Order #{GenerateOrderNumber()} | Invoice ID: INV-{GenerateInvoiceNumber()}";
            labelReceiptDate.Text = paidDate.ToString("MMMM dd, yyyy - h:mm tt");
        }

        public void SetReceiptData(List<ReceiptItem> items, decimal subtotal, decimal shippingCost, string paymentMethod, DateTime paidDate)
        {
            _items.Clear();
            foreach (var item in items)
            {
                _items.Add(item);
            }

            decimal tax = subtotal * TAX_RATE;
            decimal total = subtotal + shippingCost + tax;

            textBoxSubtotal.Text = $"฿{subtotal:N2}";
            textBoxShipping.Text = $"฿{shippingCost:N2}";
            textBoxTax.Text = $"฿{tax:N2}";
            textBoxTotal.Text = $"฿{total:N2}";

            textBoxPaymentMethod.Text = paymentMethod;
            textBoxPaidDate.Text = paidDate.ToString("MMMM dd, yyyy - h:mm tt");

            // Generate receipt number
            labelReceiptNumber.Text = $"Order #{GenerateOrderNumber()} | Invoice ID: INV-{GenerateInvoiceNumber()}";
            labelReceiptDate.Text = paidDate.ToString("MMMM dd, yyyy - h:mm tt");
        }

        private void InitializeDataGrid()
        {
            dataGridViewItems.DataSource = _items;
        }

        private string GenerateOrderNumber()
        {
            return new Random().Next(10000, 99999).ToString();
        }

        private string GenerateInvoiceNumber()
        {
            return new Random().Next(100, 999).ToString();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Print functionality will integrate with PrintDocument.\nThis is a placeholder for the print receipt action.",
                    "Print Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Print failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Download PDF functionality will generate and save receipt as PDF.\nThis is a placeholder for the download action.",
                    "Download PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Download failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelShippingText_Click(object sender, EventArgs e) { }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            // 2. เปิดหน้าเลือกสินค้า (หรือหน้าเริ่มต้น)
            ProductScreen productScreen = new ProductScreen();
            productScreen.Show();

            // 3. ปิดหน้าใบเสร็จปัจจุบัน
            this.Close();
        }

        private void dataGridViewItems_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void labelTitle_Click(object sender, EventArgs e) { }
        private void textBoxSubtotal_TextChanged(object sender, EventArgs e) { }
    }
}