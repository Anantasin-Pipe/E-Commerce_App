using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using ClientApp.Services;

namespace ClientApp
{
    public partial class CheckoutScreen : Form
    {
        private BindingList<CheckoutItem> _items = new BindingList<CheckoutItem>();
        private const decimal TAX_RATE = 0.10m;
        private readonly CartApiService _cartApiService;

        public class CheckoutItem
        {
            [Browsable(false)]
            public int CartId { get; set; } // ✅ เพิ่มเพื่อใช้ลบออกจาก Database

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

            textBoxSubtotal.Text = subtotal.ToString("C2");
            textBoxTax.Text = tax.ToString("C2");
            textBoxTotal.Text = total.ToString("C2");
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
            textBoxShippingCost.Text = cost.ToString("C2");
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

            // ดึงชื่อวิธีชำระเงิน
            string paymentMethod = "Unknown";
            if (comboBoxPaymentMethod.SelectedItem is PaymentMethodDto selectedPayment)
                paymentMethod = selectedPayment.Name;

            if (paymentMethod == "Bank Transfer")
            {
                string selectedBank = comboBoxBank.SelectedItem?.ToString() ?? "";
                paymentMethod = $"Bank Transfer ({selectedBank})";
            }

            var confirm = MessageBox.Show(
                $"Confirm payment of {textBoxTotal.Text} using {paymentMethod}?\n\nThis action cannot be undone.",
                "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            // ✅ ปิดปุ่มไว้ก่อนเพื่อไม่ให้กดซ้ำ
            btnPay.Enabled = false;

            try
            {
                // ✅ 1. ลบสินค้าที่ checkout ออกจาก Database ทีละชิ้น
                foreach (var item in selected)
                {
                    try
                    {
                        await _cartApiService.RemoveFromCartAsync(item.CartId);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to remove CartId {item.CartId}: {ex.Message}");
                    }
                }

                // ✅ 2. แปลงข้อมูลส่งไป ReceiptScreen
                var receiptItems = selected.Select(i => new ReceiptScreen.ReceiptItem
                {
                    ProductName = i.ProductName,
                    UnitPrice = i.UnitPrice,
                    Quantity = i.Quantity
                }).ToList();

                decimal subtotal = selected.Sum(i => i.UnitPrice * i.Quantity);
                decimal shippingCost = GetShippingCost();

                // ✅ 3. เปิด ReceiptScreen
                var receipt = new ReceiptScreen(receiptItems, subtotal, shippingCost, paymentMethod, DateTime.Now);
                receipt.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Payment failed: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnPay.Enabled = true; // เปิดปุ่มคืนถ้า error
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            CartScreen cart = new CartScreen();
            cart.Show();
            this.Hide();
        }

        private void comboBoxPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPayment = comboBoxPaymentMethod.SelectedItem as PaymentMethodDto;

            if (selectedPayment != null && selectedPayment.Name == "Bank Transfer")
            {
                labelBank.Visible = true;
                comboBoxBank.Visible = true;

                if (comboBoxBank.Items.Count == 0)
                {
                    comboBoxBank.Items.AddRange(new string[]
                    {
                        "Bangkok Bank",
                        "Kasikornbank",
                        "Krung Thai Bank",
                        "TMRW (TMB)",
                        "Siam Commercial Bank"
                    });
                    comboBoxBank.SelectedIndex = 0;
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
    }
}