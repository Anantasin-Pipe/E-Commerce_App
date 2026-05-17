using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms; // 🌟 เผื่อเรียกใช้ MessageBox

namespace ClientApp.Services
{
    // คลาสสำหรับรับข้อมูลที่รวมกันมาจาก API (Cart + Product)
    public class CartItemDto
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public string receiptId { get; set; }
        public string SessionId { get; set; }
    }

    public class CartApiService
    {
        private readonly HttpClient _httpClient;

        private const string BaseUrl = "https://localhost:7241/api/Carts";

        public CartApiService()
        {
            var handler = new HttpClientHandler();
            // ยอมรับ Certificate ในเครื่องตัวเอง ป้องกัน Error SSL ตอนรัน Debug
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            _httpClient = new HttpClient(handler);
        }

        /// <summary>
        /// ดึงข้อมูลสินค้าทั้งหมดในตะกร้า
        /// </summary>
        public async Task<List<CartItemDto>> GetCartItemsAsync(string sessionId)
        {
            try
            {
                var url = $"{BaseUrl}?sessionId={sessionId}";
                var items = await _httpClient.GetFromJsonAsync<List<CartItemDto>>(url);
                return items ?? new List<CartItemDto>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot load cart: {ex.Message}");
            }
        }

        /// <summary>
        /// เพิ่มสินค้าลงตะกร้า (ใช้เรียกตอนกด Add to Cart ที่หน้า ProductScreen)
        /// </summary>
        public async Task<bool> AddToCartAsync(int productId, int quantity, string sessionId)
        {
            try
            {
                var requestData = new
                {
                    ProductId = productId,
                    Quantity = quantity,
                    SessionId = sessionId
                    // 🌟 แก้ไข: เอา ReceiptId ออกจากตรงนี้ เพราะตอนหยิบลงตะกร้ายังไม่เกิดใบเสร็จ
                };

                var response = await _httpClient.PostAsJsonAsync(BaseUrl, requestData);

                // 🌟 1. ถ้าส่งไม่สำเร็จ (ไม่ใช่ Status 200) ให้โชว์ Error จาก Server เลย
                if (!response.IsSuccessStatusCode)
                {
                    string errorText = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Server ฟ้องว่า:\n{errorText}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                // 🌟 2. ถ้าแอปพังเอง (เช่น เน็ตหลุด) ให้โชว์ข้อความนี้
                MessageBox.Show($"App Error:\n{ex.Message}", "App Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// ลบสินค้าออกจากตะกร้า (ใช้ตอนกดปุ่ม Remove ในหน้า CartScreen)
        /// </summary>
        public async Task<bool> RemoveFromCartAsync(int cartId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{BaseUrl}/{cartId}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// ส่งข้อมูลไปบันทึกใบเสร็จ (Checkout)
        /// </summary>
        // 🌟 แก้ไข: เพิ่ม string receiptId เข้ามาในฟังก์ชันนี้
        public async Task<bool> CheckoutAsync(List<int> cartIds, int? bankId, int paymentId, string receiptId)
        {
            try
            {
                var requestData = new
                {
                    CartIds = cartIds,
                    BankId = bankId,
                    PaymentId = paymentId,
                    ReceiptId = receiptId // 🌟 แก้ไข: แพ็ค ReceiptId ส่งไปให้ API ด้วย
                };

                // ส่งไปที่ CheckoutController
                var checkoutUrl = "https://localhost:7241/api/Checkout";
                var response = await _httpClient.PostAsJsonAsync(checkoutUrl, requestData);

                if (!response.IsSuccessStatusCode)
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Server Error:\n{error}", "Checkout Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"App Error:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task<List<BankDto>> GetBanksAsync()
        {
            try
            {
                // 🌟 ใส่ URL แบบเต็มๆ (อย่าลืมเช็กเลข 7241 ว่าตรงกับ Port ของ Server คุณไหม)
                string url = "https://localhost:7241/api/Banks";

                var banks = await _httpClient.GetFromJsonAsync<List<BankDto>>(url);
                return banks ?? new List<BankDto>();
            }
            catch (Exception ex)
            {
                // แอบดัก Error ไว้เผื่อ Server ปิดอยู่
                Console.WriteLine($"Error fetching banks: {ex.Message}");
                throw; // โยน Error กลับไปให้หน้าจอ Checkout โชว์
            }
        }

        // 🌟 เพิ่มการรับค่า sessionId
        public async Task<List<OrderStatusDto>> GetOrderStatusesAsync(string sessionId)
        {
            try
            {
                // 🌟 ส่ง sessionId ไปกับ URL
                string url = $"https://localhost:7241/api/OrderStatus?sessionId={sessionId}";
                var result = await _httpClient.GetFromJsonAsync<List<OrderStatusDto>>(url);
                return result ?? new List<OrderStatusDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<OrderStatusDto>();
            }
        }

        // ==========================================
        // 🌟 โซนฟังก์ชันสำหรับฝั่ง SellerApp (เพิ่มเข้ามาใหม่)
        // ==========================================

        /// <summary>
        /// Seller: ดึงออเดอร์ทั้งหมดของร้านค้า
        /// </summary>
        public async Task<List<OrderStatusDto>> GetAllOrdersForSellerAsync()
        {
            try
            {
                string url = "https://localhost:7241/api/OrderStatus/all";
                var result = await _httpClient.GetFromJsonAsync<List<OrderStatusDto>>(url);
                return result ?? new List<OrderStatusDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Fetching All Orders: {ex.Message}");
                return new List<OrderStatusDto>();
            }
        }

        /// <summary>
        /// Seller: อัปเดตสถานะและเลขพัสดุ
        /// </summary>
        public async Task<string> UpdateOrderStatusAsync(string receiptId, int newStatus, string trackingNumber)
        {
            try
            {
                string url = $"https://localhost:7241/api/OrderStatus/update/{receiptId}";
                var requestData = new
                {
                    NewStatus = newStatus,
                    TrackingNumber = trackingNumber
                };

                var response = await _httpClient.PutAsJsonAsync(url, requestData);

                if (response.IsSuccessStatusCode)
                {
                    return "SUCCESS";
                }
                else
                {
                    // 🌟 อ่านข้อความ Error จริงที่ Server บ่นออกมา
                    string errorContent = await response.Content.ReadAsStringAsync();
                    return errorContent;
                }
            }
            catch (Exception ex)
            {
                return $"APP_ERROR: {ex.Message}";
            }
        }
    }
}