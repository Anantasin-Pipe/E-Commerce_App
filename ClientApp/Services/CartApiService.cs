using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

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
    }

    public class CartApiService
    {
        private readonly HttpClient _httpClient;

        private const string BaseUrl = "https://localhost:7241/api/Carts";

        public CartApiService()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// ดึงข้อมูลสินค้าทั้งหมดในตะกร้า
        /// </summary>
        public async Task<List<CartItemDto>> GetCartItemsAsync()
        {
            try
            {
                var items = await _httpClient.GetFromJsonAsync<List<CartItemDto>>(BaseUrl);
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
        public async Task<bool> AddToCartAsync(int productId, int quantity)
        {
            try
            {
                var payload = new { ProductId = productId, Quantity = quantity };
                var response = await _httpClient.PostAsJsonAsync(BaseUrl, payload);
                return response.IsSuccessStatusCode;
            }
            catch
            {
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
    }
}