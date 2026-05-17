using ClientApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClientApp
{
    public partial class CartScreen : Form
    {
        private BindingList<CartItem> _items = new BindingList<CartItem>();
        private readonly CartApiService _cartApiService;

        //นี่คือคลาสที่ DataGridView เอาไปสร้างตาราง
        public class CartItem
        {
            [Browsable(false)] //สั่งซ่อน CartId
            public int CartId { get; set; }

            public bool Selected { get; set; } = true;

            [Browsable(false)] //สั่งซ่อน ProductId
            public int ProductId { get; set; }

            public string ProductName { get; set; } = string.Empty;
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; } = 1;

            public decimal SubTotal => UnitPrice * Quantity;
        }

        public CartScreen()
        {
            InitializeComponent();
            _cartApiService = new CartApiService();
            InitializeDataGrid();
            UpdateTotals();
            LoadCartFromDatabase();
        }

        private void InitializeDataGrid()
        {
            dataGridViewCart.DataSource = _items;
            dataGridViewCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCart.CellEndEdit += DataGridViewCart_CellEndEdit;
            dataGridViewCart.CurrentCellDirtyStateChanged += DataGridViewCart_CurrentCellDirtyStateChanged;
            dataGridViewCart.CellValueChanged += DataGridViewCart_CellValueChanged;
            _items.ListChanged += Items_ListChanged;

            //ซ่อนคอลัมน์ซ้ำอีกรอบ
            //if (dataGridViewCart.Columns["CartId"] != null)
            //    dataGridViewCart.Columns["CartId"].Visible = false;

            //if (dataGridViewCart.Columns["ProductId"] != null)
            //    dataGridViewCart.Columns["ProductId"].Visible = false;
        }

        private async void LoadCartFromDatabase()
        {
            try
            {
                string currentSessionId = AppSession.SessionId;
                // ดึงข้อมูลผ่าน API Service
                var cartItemsFromApi = await _cartApiService.GetCartItemsAsync(currentSessionId);

                _items.Clear();
                foreach (var dto in cartItemsFromApi)
                {
                    // แปลง DTO จาก API ให้เป็น CartItem ของหน้าจอ
                    _items.Add(new CartItem
                    {
                        CartId = dto.CartId,
                        ProductId = dto.ProductId,
                        ProductName = dto.ProductName,
                        UnitPrice = dto.UnitPrice,
                        Quantity = dto.Quantity
                    });
                }
                UpdateTotals();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewCart_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewCart.IsCurrentCellDirty)
            {
                dataGridViewCart.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DataGridViewCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // เช็กว่าไม่ใช่การคลิกที่หัวตาราง
            if (e.RowIndex >= 0)
            {
                // เมื่อมีการติ๊ก CheckBox หรือแก้ตัวเลขให้คำนวณยอดเงินใหม่ทันที
                UpdateTotals();
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

            //เปลี่ยนชื่อตัวแปรเป็น total เพื่อความเมคเซนส์ครับ
            decimal total = selectedItems.Sum(i => i.UnitPrice * i.Quantity);

            //Update ยอด Total 
            textBoxTotal.Text = $"฿{total:N2}";
        }

        private async void BtnRemove_Click(object sender, EventArgs e)
        {
            // ดึงรายการสินค้าทั้งหมดที่ถูก ติ๊กถูก มาเก็บไว้ใน List
            var itemsToRemove = _items.Where(i => i.Selected).ToList();

            if (itemsToRemove.Count == 0)
            {
                MessageBox.Show("Please check at least one item to remove.", "No items selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //ถามเพื่อความแน่ใจก่อนลบ
            var confirmResult = MessageBox.Show($"Are you sure you want to remove {itemsToRemove.Count} selected item(s)?",
                                                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                int successCount = 0;

                // วนลูปทีละชิ้นเพื่อสั่ง API ให้ลบออกจาก Database
                foreach (var item in itemsToRemove)
                {
                    try
                    {
                        bool isSuccess = await _cartApiService.RemoveFromCartAsync(item.CartId);

                        if (isSuccess)
                        {
                            // ถ้า Database ลบสำเร็จ ให้เอาออกจากตารางบนหน้าจอด้วย
                            _items.Remove(item);
                            successCount++;
                        }
                    }
                    catch (Exception ex)
                    {
                        // ถ้าชิ้นไหนลบ Error ก็ข้ามไปก่อน (อาจจะขึ้นแจ้งเตือนไว้)
                        Console.WriteLine($"Error removing cart item {item.CartId}: {ex.Message}");
                    }
                }

                // อัปเดตยอดเงินและสรุปผลหลังจากลบเสร็จสิ้น
                UpdateTotals();

                if (successCount > 0)
                {
                    MessageBox.Show($"Successfully removed {successCount} item(s) from cart.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to remove items.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                MessageBox.Show("Please select at least one item to checkout.",
                                "No items selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // แปลง CartItem เป็น CheckoutItem แล้วส่งไป
            var checkoutItems = selected.Select(i => new CheckoutScreen.CheckoutItem
            {
                CartId = i.CartId,
                ProductId = i.ProductId,
                ProductName = i.ProductName,
                UnitPrice = i.UnitPrice,
                Quantity = i.Quantity
            });

            CheckoutScreen checkout = new CheckoutScreen(checkoutItems); // ส่งผ่าน constructor
            checkout.Show();
            this.Hide();
        }

        private void panelCartSummary_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxSubtotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelTotalText_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}