using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ClientApp
{
    public partial class CheckoutScreen : Form
    {
        private BindingList<CheckoutItem> _items = new BindingList<CheckoutItem>();
        private const decimal TAX_RATE = 0.10m; // 10% tax

        public class CheckoutItem
        {
            [Browsable(false)]
            public bool Selected { get; set; } = true;

            [Browsable(false)]
            public int ProductId { get; set; }

            public string ProductName { get; set; } = string.Empty;
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; } = 1;
            public decimal SubTotal => UnitPrice * Quantity;
        }

        // 🌟 1. สร้างกล่องรับข้อมูล Payment ให้ตรงกับ Database
        public class PaymentMethodDto
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
        }

        // เพิ่ม constructor ใหม่ที่รับ items เข้ามา
        public CheckoutScreen(IEnumerable<CheckoutItem> items)
        {
            InitializeComponent();
            InitializeDataGrid();
            InitializePaymentMethods();

            // โหลดของจริงแทน Sample
            foreach (var item in items)
                _items.Add(item);

            UpdateTotals();
        }

        public void SetItems(IEnumerable<CheckoutItem> items)
        {
            _items.Clear();
            foreach (var item in items)
            {
                _items.Add(item);
            }
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
            // 🌟 2. จำลองข้อมูลที่ได้มาจาก Database
            var payments = new List<PaymentMethodDto>
            {
                new PaymentMethodDto { Id = 1, Name = "Credit Card" },
                new PaymentMethodDto { Id = 2, Name = "Debit Card" },
                new PaymentMethodDto { Id = 3, Name = "Bank Transfer" },
                new PaymentMethodDto { Id = 4, Name = "Digital Wallet" },
                new PaymentMethodDto { Id = 5, Name = "Cash on Delivery" }
            };

            // ผูกข้อมูลเข้ากับ ComboBox
            comboBoxPaymentMethod.DataSource = payments;
            comboBoxPaymentMethod.DisplayMember = "Name"; // สั่งให้หน้าจอโชว์ชื่อ (เช่น "Credit Card")
            comboBoxPaymentMethod.ValueMember = "Id";     // สั่งให้เบื้องหลังแอบจำ ID เอาไว้ (เช่น 1)

            if (comboBoxShipping.Items.Count > 0)
            {
                comboBoxShipping.SelectedIndex = 0;
            }
        }


        private void DataGridViewItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewItems.IsCurrentCellDirty)
            {
                dataGridViewItems.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DataGridViewItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _items.Count) return;

            var item = _items[e.RowIndex];

            // Validate quantity
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
                0 => 5.00m,      // Standard
                1 => 15.00m,     // Express
                2 => 25.00m,     // Overnight
                _ => 5.00m
            };
        }

        private void ComboBoxShipping_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal cost = GetShippingCost();
            textBoxShippingCost.Text = cost.ToString("C2");
            UpdateTotals();
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            // 1. เช็กว่ามีของในตะกร้าไหม (ถึงซ่อน Checkbox ไว้ ค่ามันก็เป็น true อยู่เสมอ)
            var selected = _items.Where(i => i.Selected).ToList();
            if (!selected.Any())
            {
                MessageBox.Show("Please select at least one item to purchase.",
                                "No items selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. ดึงชื่อวิธีชำระเงิน
            string paymentMethod = "Unknown";
            if (comboBoxPaymentMethod.SelectedItem is PaymentMethodDto selectedPayment)
            {
                paymentMethod = selectedPayment.Name; // ได้คำว่า "Credit Card", "Bank Transfer", ฯลฯ
            }

            // 3. ถ้าเป็นโอนเงิน ให้เอาชื่อธนาคารมาต่อท้าย
            if (paymentMethod == "Bank Transfer")
            {
                string selectedBank = comboBoxBank.SelectedItem?.ToString() ?? "";
                paymentMethod = $"Bank Transfer ({selectedBank})";
            }

            var total = textBoxTotal.Text;

            // 4. ถามยืนยันการจ่ายเงิน
            var confirm = MessageBox.Show(
                $"Confirm payment of {total} using {paymentMethod}?\n\nThis action cannot be undone.",
                "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            // 5. ดำเนินการส่งข้อมูลไปหน้าใบเสร็จ
            try
            {
                // แปลง CheckoutItem → ReceiptItem
                var receiptItems = selected.Select(i => new ReceiptScreen.ReceiptItem
                {
                    ProductName = i.ProductName,
                    UnitPrice = i.UnitPrice,
                    Quantity = i.Quantity
                }).ToList();

                decimal subtotal = selected.Sum(i => i.UnitPrice * i.Quantity);
                decimal shippingCost = GetShippingCost();

                // ส่งข้อมูลทั้งหมดไป ReceiptScreen
                var receipt = new ReceiptScreen(receiptItems, subtotal, shippingCost, paymentMethod, DateTime.Now);
                receipt.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Payment failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            // Navigate back to CartScreen instead of closing
            CartScreen cart = new CartScreen();
            cart.Show();
            this.Hide();
        }

        private void comboBoxPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 🌟 3. ดึงข้อมูลตัวที่ถูกเลือกออกมาทั้งก้อน
            var selectedPayment = comboBoxPaymentMethod.SelectedItem as PaymentMethodDto;

            // เช็กชื่อว่าตรงกับ "Bank Transfer" ไหม
            if (selectedPayment != null && selectedPayment.Name == "Bank Transfer")
            {
                labelBank.Visible = true;
                comboBoxBank.Visible = true;

                // ตรวจสอบและใส่ข้อมูลธนาคาร
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

        private void dataGridViewItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelPaymentMethod_Click(object sender, EventArgs e)
        {

        }
    }
}
