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
            public bool Selected { get; set; } = true;
            public int ProductId { get; set; }
            public string ProductName { get; set; } = string.Empty;
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; } = 1;
            public decimal SubTotal => UnitPrice * Quantity;
        }

        public CheckoutScreen()
        {
            InitializeComponent();
            InitializeDataGrid();
            InitializePaymentMethods();
            LoadSampleItems();
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
            dataGridViewItems.DataSource = _items;
            dataGridViewItems.CellEndEdit += DataGridViewItems_CellEndEdit;
            dataGridViewItems.CurrentCellDirtyStateChanged += DataGridViewItems_CurrentCellDirtyStateChanged;
            _items.ListChanged += Items_ListChanged;
        }

        private void InitializePaymentMethods()
        {
            comboBoxPaymentMethod.SelectedIndex = 0;
            comboBoxShipping.SelectedIndex = 0;
        }

        private void LoadSampleItems()
        {
            // Sample data - replace with real cart items
            _items.Add(new CheckoutItem { ProductId = 1, ProductName = "Blue T-Shirt", UnitPrice = 19.99m, Quantity = 2 });
            _items.Add(new CheckoutItem { ProductId = 2, ProductName = "Red Mug", UnitPrice = 8.50m, Quantity = 1 });
            _items.Add(new CheckoutItem { ProductId = 3, ProductName = "Notebook Set", UnitPrice = 12.75m, Quantity = 3 });
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
            var selected = _items.Where(i => i.Selected).ToList();
            if (!selected.Any())
            {
                MessageBox.Show("Please select at least one item to purchase.", "No items selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var paymentMethod = comboBoxPaymentMethod.SelectedItem?.ToString() ?? "Unknown";
            var total = textBoxTotal.Text;

            var confirm = MessageBox.Show(
                $"Confirm payment of {total} using {paymentMethod}?\n\nThis action cannot be undone.",
                "Confirm Payment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                // TODO: Integrate with API call for payment processing
                var receipt = new ReceiptScreen();
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
            this.Close();
        }

        private void comboBoxPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
