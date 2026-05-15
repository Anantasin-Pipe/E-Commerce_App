using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Json;
using System.Windows.Forms;
using ClientApp.Services;

namespace ClientApp
{
    public partial class CartScreen : Form
    {
        private BindingList<CartItem> _items = new BindingList<CartItem>();
        private readonly CartApiService _cartApiService;

        // 🌟 นี่คือคลาสที่ DataGridView เอาไปสร้างตาราง ต้องมาซ่อนตรงนี้ครับ
        public class CartItem
        {
            [Browsable(false)] // 🌟 สั่งซ่อน CartId
            public int CartId { get; set; }

            public bool Selected { get; set; } = true;

            [Browsable(false)] // 🌟 สั่งซ่อน ProductId
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

            // 🌟 ซ่อนคอลัมน์ซ้ำอีกรอบ (เผื่อกรณีที่หน้า Design ของ Visual Studio บังคับสร้างคอลัมน์ค้างไว้)
            if (dataGridViewCart.Columns["CartId"] != null)
                dataGridViewCart.Columns["CartId"].Visible = false;

            if (dataGridViewCart.Columns["ProductId"] != null)
                dataGridViewCart.Columns["ProductId"].Visible = false;
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

        //private async Task LoadCartFromDatabaseAsync()

        //{
        //    try
        //    {
        //        using (HttpClient client = new HttpClient())
        //        {
        //            // เปลี่ยน URL ให้ตรงกับพอร์ต API ของคุณ
        //            client.BaseAddress = new Uri("https://localhost:7241/");

        //            // ยิง GET ไปที่ CartsController ที่เราเพิ่งสร้าง
        //            var cartItemsFromApi = await client.GetFromJsonAsync<List<CartItem>>("api/Carts");

        //            if (cartItemsFromApi != null)
        //            {
        //                _items.Clear();
        //                foreach (var item in cartItemsFromApi)
        //                {
        //                    // ตั้งค่าเริ่มต้นให้ทุกชิ้นถูก Selected (ติ๊กถูก)
        //                    item.Selected = true;
        //                    _items.Add(item);
        //                }
        //                UpdateTotals();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error loading cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

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
                // เมื่อมีการติ๊ก CheckBox หรือแก้ตัวเลข ให้คำนวณยอดเงินใหม่ทันที
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
            decimal subtotal = selectedItems.Sum(i => i.UnitPrice * i.Quantity);

            textBoxSubtotal.Text = subtotal.ToString("C2");
            textBoxTotal.Text = subtotal.ToString("C2");
        }

        private async void BtnRemove_Click(object sender, EventArgs e)
        {
            // 🌟 1. ดึงรายการสินค้าทั้งหมดที่ถูก "ติ๊กถูก" (Selected == true) มาเก็บไว้ใน List
            // ดึงรายการสินค้าทั้งหมดที่ถูก "ติ๊กถูก" (Selected == true) มาเก็บไว้ใน List
            var itemsToRemove = _items.Where(i => i.Selected).ToList();

            if (itemsToRemove.Count == 0)
            {
                MessageBox.Show("Please check at least one item to remove.", "No items selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ถามเพื่อความแน่ใจก่อนลบ (บอกจำนวนชิ้นที่จะลบด้วย)
            var confirmResult = MessageBox.Show($"Are you sure you want to remove {itemsToRemove.Count} selected item(s)?",
                                                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                int successCount = 0;

                // 🌟 2. วนลูปทีละชิ้น เพื่อสั่ง API ให้ลบออกจาก Database
                // วนลูปทีละชิ้น เพื่อสั่ง API ให้ลบออกจาก Database
                foreach (var item in itemsToRemove)
                {
                    try
                    {
                        // สั่ง API ลบข้อมูล
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

                // 🌟 3. อัปเดตยอดเงินและสรุปผลหลังจากลบเสร็จสิ้น
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

            // แปลง CartItem → CheckoutItem แล้วส่งไป
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
    }
}