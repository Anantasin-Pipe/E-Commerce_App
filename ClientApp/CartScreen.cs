using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class CartScreen : Form
    {
        private BindingList<CartItem> _items = new BindingList<CartItem>();

        public class CartItem
        {
            public bool Selected { get; set; } = true;
            public int ProductId { get; set; }
            public string ProductName { get; set; } = string.Empty;
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; } = 1;
            public decimal SubTotal => UnitPrice * Quantity;
        }

        public CartScreen()
        {
            InitializeComponent();
            InitializeDataGrid();
            LoadSampleItems();
            UpdateTotals();
        }

        private void InitializeDataGrid()
        {
            dataGridViewCart.DataSource = _items;
            dataGridViewCart.CellEndEdit += DataGridViewCart_CellEndEdit;
            dataGridViewCart.CurrentCellDirtyStateChanged += DataGridViewCart_CurrentCellDirtyStateChanged;
            _items.ListChanged += Items_ListChanged;
        }

        private void LoadSampleItems()
        {
            // Sample cart items - replace with real cart data
            _items.Add(new CartItem { ProductId = 1, ProductName = "Blue T-Shirt", UnitPrice = 19.99m, Quantity = 2 });
            _items.Add(new CartItem { ProductId = 2, ProductName = "Red Mug", UnitPrice = 8.50m, Quantity = 1 });
            _items.Add(new CartItem { ProductId = 3, ProductName = "Notebook Set", UnitPrice = 12.75m, Quantity = 3 });
        }

        private void DataGridViewCart_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewCart.IsCurrentCellDirty)
            {
                dataGridViewCart.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DataGridViewCart_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _items.Count) return;

            var item = _items[e.RowIndex];
            if (item.Quantity < 1) item.Quantity = 1;
            if (item.Quantity > 999) item.Quantity = 999;

            dataGridViewCart.InvalidateRow(e.RowIndex);
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

            textBoxSubtotal.Text = subtotal.ToString("C2");
            textBoxTotal.Text = subtotal.ToString("C2");
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridViewCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to remove.", "No item selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dataGridViewCart.SelectedRows[0];
            if (selectedRow.Index >= 0 && selectedRow.Index < _items.Count)
            {
                _items.RemoveAt(selectedRow.Index);
                MessageBox.Show("Item removed from cart.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            ProductScreen product = new ProductScreen();
            product.Show();
            this.Hide();
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            var selected = _items.Where(i => i.Selected).ToList();
            if (!selected.Any())
            {
                MessageBox.Show("Please select at least one item to checkout.", "No items selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CheckoutScreen checkout = new CheckoutScreen();
            // TODO: Pass selected items to checkout
            checkout.Show();
            this.Hide();
        }
    }
}
