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

        /// ดึงข้อมูลสินค้าทั้งหมดในตะกร้า
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

        /// เพิ่มสินค้าลงตะกร้า
        public async Task<bool> AddToCartAsync(int productId, int quantity, string sessionId)
        {
            try
            {
                var requestData = new
                {
                    ProductId = productId,
                    Quantity = quantity,
                    SessionId = sessionId
                };

                var response = await _httpClient.PostAsJsonAsync(BaseUrl, requestData);

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
                MessageBox.Show($"App Error:\n{ex.Message}", "App Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// ลบสินค้าออกจากตะกร้า
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

        /// ส่งข้อมูลไปบันทึกใบเสร็จ
        public async Task<bool> CheckoutAsync(List<int> cartIds, int? bankId, int paymentId, string receiptId)
        {
            try
            {
                var requestData = new
                {
                    CartIds = cartIds,
                    BankId = bankId,
                    PaymentId = paymentId,
                    ReceiptId = receiptId
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
                string url = "https://localhost:7241/api/Banks";

                var banks = await _httpClient.GetFromJsonAsync<List<BankDto>>(url);
                return banks ?? new List<BankDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching banks: {ex.Message}");
                throw;
            }
        }

        // เพิ่มการรับค่า sessionId
        public async Task<List<OrderStatusDto>> GetOrderStatusesAsync(string sessionId)
        {
            try
            {
                //  ส่ง sessionId ไปกับ URL
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
        }
    }
