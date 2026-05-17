using ClientApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using static ClientApp.ReceiptScreen;

namespace ClientApp
{
    public partial class CheckoutScreen : Form
    {
        private BindingList<CheckoutItem> _items = new BindingList<CheckoutItem>();
        private const decimal TAX_RATE = 0.07m;
        private readonly CartApiService _cartApiService;

        public class CheckoutItem
        {
            [Browsable(false)]
            public int CartId { get; set; }

            [Browsable(false)]
            public bool Selected { get; set; } = true;

            [Browsable(false)]
            public int ProductId { get; set; }

            public string ProductName { get; set; } = string.Empty;
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; } = 1;
            public decimal SubTotal => UnitPrice * Quantity;
        }

        public class PaymentMethodDto
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
        }

        public CheckoutScreen(IEnumerable<CheckoutItem> items)
        {
            InitializeComponent();
            _cartApiService = new CartApiService();
            InitializeDataGrid();
            InitializePaymentMethods();

            foreach (var item in items)
                _items.Add(item);

            UpdateTotals();
        }

        public void SetItems(IEnumerable<CheckoutItem> items)
        {
            _items.Clear();
            foreach (var item in items)
                _items.Add(item);
            UpdateTotals();
        }

        private void InitializeDataGrid()
        {
            dataGridViewItems.AutoGenerateColumns = false;
            dataGridViewItems.DataSource = _items;
            dataGridViewItems.CellEndEdit += DataGridViewItems_CellEndEdit;
            dataGridViewItems.CurrentCellDirtyStateChanged += DataGridViewItems_CurrentCellDirtyStateChanged;
            _items.ListChanged += Items_ListChanged;
        }

        private void InitializePaymentMethods()
        {
            var payments = new List<PaymentMethodDto>
            {
                new PaymentMethodDto { Id = 1, Name = "Credit Card" },
                new PaymentMethodDto { Id = 2, Name = "Debit Card" },
                new PaymentMethodDto { Id = 3, Name = "Bank Transfer" },
                new PaymentMethodDto { Id = 4, Name = "Digital Wallet" },
                new PaymentMethodDto { Id = 5, Name = "Cash on Delivery" }
            };

            comboBoxPaymentMethod.DataSource = payments;
            comboBoxPaymentMethod.DisplayMember = "Name";
            comboBoxPaymentMethod.ValueMember = "Id";

            comboBoxShipping.Items.Clear();
            comboBoxShipping.Items.Add("Standard (฿5.00)");
            comboBoxShipping.Items.Add("Express (฿15.00)");
            comboBoxShipping.Items.Add("Overnight (฿25.00)");

            if (comboBoxShipping.Items.Count > 0)
                comboBoxShipping.SelectedIndex = 0;
        }

        private void DataGridViewItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewItems.IsCurrentCellDirty)
                dataGridViewItems.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DataGridViewItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _items.Count) return;

            var item = _items[e.RowIndex];
            if (item.Quantity < 1) item.Quantity = 1;
            if (item.Quantity > 999) item.Quantity = 999;

            dataGridViewItems.InvalidateRow(e.RowIndex);
            UpdateTotals();
        }

        private void Items_ListChanged(object sender, ListChangedEventArgs e)
        {
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            var selectedItems = _items.Where(i => i.Selected).ToList();
            decimal subtotal = selectedItems.Sum(i => i.UnitPrice * i.Quantity);
            decimal shippingCost = GetShippingCost();
            decimal tax = subtotal * TAX_RATE;
            decimal total = subtotal + tax + shippingCost;

            textBoxSubtotal.Text = $"฿{subtotal:N2}";
            textBoxTax.Text = $"฿{tax:N2}";
            textBoxTotal.Text = $"฿{total:N2}";
        }

        private decimal GetShippingCost()
        {
            return comboBoxShipping.SelectedIndex switch
            {
                0 => 5.00m,
                1 => 15.00m,
                2 => 25.00m,
                _ => 5.00m
            };
        }

        private void ComboBoxShipping_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal cost = GetShippingCost();
            textBoxShippingCost.Text = $"฿{cost:N2}";
            UpdateTotals();
        }

        private async void BtnPay_Click(object sender, EventArgs e)
        {
            var selected = _items.Where(i => i.Selected).ToList();
            if (!selected.Any())
            {
                MessageBox.Show("Please select at least one item to purchase.",
                    "No items selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 🌟 1. ดึงข้อมูล PaymentMethod
            string paymentMethod = "Unknown";
            int paymentId = 1;

            if (comboBoxPaymentMethod.SelectedItem is PaymentMethodDto selectedPayment)
            {
                paymentMethod = selectedPayment.Name;
                paymentId = selectedPayment.Id;
            }

            if (paymentMethod == "Bank Transfer")
            {
                // ดึงชื่อธนาคารมาโชว์ในกล่องข้อความยืนยัน
                string selectedBankName = comboBoxBank.Text;
                paymentMethod = $"Bank Transfer ({selectedBankName})";
            }

            var confirm = MessageBox.Show(
                $"Confirm payment of {textBoxTotal.Text} using {paymentMethod}?\n\nThis action cannot be undone.",
                "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            btnPay.Enabled = false;

            try
            {
                // ✅ 2. ดึง CartId ของทุกชิ้นที่ลูกค้าเลือก
                List<int> cartIdsToCheckout = selected.Select(i => i.CartId).ToList();

                // 🌟 3. ดึง BankId แบบ Dynamic
                int? bankId = null;

                if (paymentMethod.StartsWith("Bank Transfer") && comboBoxBank.SelectedValue != null)
                {
                    // ถ้าเลือก Bank Transfer ต้องเอาค่าจาก ComboBox
                    if (comboBoxBank.SelectedValue != null)
                    {
                        bankId = (int)comboBoxBank.SelectedValue;
                    }
                    else
                    {
                        // ถ้าเลือกโอนเงินแต่ไม่เลือกธนาคาร อาจจะค้างไว้ที่ 0 หรือแจ้งเตือน
                        bankId = 0;
                    }
                }

                // ✅ 4. ส่งข้อมูลไปให้ API บันทึกใบเสร็จ
                bool isCheckoutSuccess = await _cartApiService.CheckoutAsync(cartIdsToCheckout, bankId, paymentId);

                if (isCheckoutSuccess)
                {
                    // ✅ 5. แปลงข้อมูลส่งไปแสดงที่หน้า ReceiptScreen (ตัวที่หายไป เอามาใส่คืนแล้วครับ!)
                    var receiptItems = selected.Select(i => new ReceiptScreen.ReceiptItem
                    {
                        ProductName = i.ProductName,
                        UnitPrice = i.UnitPrice,
                        Quantity = i.Quantity
                    }).ToList();

                    decimal subtotal = selected.Sum(i => i.UnitPrice * i.Quantity);
                    decimal shippingCost = GetShippingCost();

                    // 🌟 6. เปิดหน้าต่างใบเสร็จ
                    var receipt = new ReceiptScreen(receiptItems, subtotal, shippingCost, paymentMethod, DateTime.Now);
                    receipt.Show();
                    this.Hide();
                }
                else
                {
                    // ถ้าไม่สำเร็จ ให้เปิดปุ่มคืน
                    btnPay.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Payment failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnPay.Enabled = true;
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            CartScreen cart = new CartScreen();
            cart.Show();
            this.Hide();
        }

        private async Task LoadBanksAsync()
        {
            try
            {
                // เรียกใช้ Service ที่สร้างไว้เพื่อไปดึงข้อมูลจาก BanksController
                var banks = await _cartApiService.GetBanksAsync();

                if (banks != null && banks.Any())
                {
                    comboBoxBank.DataSource = banks;
                    comboBoxBank.DisplayMember = "BankName"; // แสดงชื่อธนาคารใน ComboBox
                    comboBoxBank.ValueMember = "Id";     // เก็บค่า Id ไว้เบื้องหลัง
                }
                else
                {
                    // 🌟 ถ้า API ดึงมาได้ แต่ข้อมูลเป็น 0 จะเด้งอันนี้
                    MessageBox.Show("ตารางธนาคารใน Database ว่างเปล่าครับ ลองเพิ่มข้อมูลดูนะครับ", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เชื่อมต่อ API ธนาคารไม่สำเร็จ:\n{ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void comboBoxPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPayment = comboBoxPaymentMethod.SelectedItem as PaymentMethodDto;

            if (selectedPayment != null && selectedPayment.Name == "Bank Transfer")
            {
                labelBank.Visible = true;
                comboBoxBank.Visible = true;

                // ถ้ายังไม่มีข้อมูลใน ComboBox ให้ไปโหลดมาจาก Database
                if (comboBoxBank.DataSource == null)
                {
                    await LoadBanksAsync();
                }
            }
            else
            {
                labelBank.Visible = false;
                comboBoxBank.Visible = false;
            }
        }

        private void dataGridViewItems_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void labelPaymentMethod_Click(object sender, EventArgs e) { }

        private void textBoxShippingCost_TextChanged(object sender, EventArgs e)
        {

        }
    }
}