using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ClientApp.Services
{
    public class SellerApiService
    {
        private readonly HttpClient _httpClient;

        private const string BaseUrl = "https://localhost:7241/api/OrderStatus";

        public SellerApiService()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            _httpClient = new HttpClient(handler);
        }

        /// Seller ดึงออเดอร์ทั้งหมดของร้านค้า
        public async Task<List<OrderStatusDto>> GetAllOrdersForSellerAsync()
        {
            try
            {
                var url = $"{BaseUrl}/all";
                var result = await _httpClient.GetFromJsonAsync<List<OrderStatusDto>>(url);
                return result ?? new List<OrderStatusDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Fetching All Orders: {ex.Message}");
                return new List<OrderStatusDto>();
            }
        }

        /// Seller อัปเดตสถานะและเลขพัสดุ
        public async Task<string> UpdateOrderStatusAsync(string receiptId, int newStatus, string trackingNumber)
        {
            try
            {
                var url = $"{BaseUrl}/update/{receiptId}"; // 🌟 สั้นและกระชับขึ้น
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