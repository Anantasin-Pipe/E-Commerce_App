using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text; // 🌟 เพิ่มสำหรับ Encoding.UTF8
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientApp.Services
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Description { get; set; } = string.Empty;
    }

    public interface IProductApiService
    {
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<bool> AddProductAsync(ProductDto product);
        Task<bool> DeleteProductAsync(int productId);
    }

    public class ProductApiService : IProductApiService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://localhost:7241/api/products";

        public ProductApiService()
        {
            var handler = new HttpClientHandler();
            // Bypass SSL Certificate validation (ใช้สำหรับ Development เท่านั้น)
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            _httpClient = new HttpClient(handler);
        }

        public async Task<bool> AddProductAsync(ProductDto product)
        {
            try
            {
                // แปลงข้อมูล Object (ProductDto) ให้เป็น JSON string
                var json = JsonSerializer.Serialize(product);

                // สร้าง Content สำหรับแนบไปกับ HTTP Request
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // ส่งคำสั่ง POST ไปที่ API
                var response = await _httpClient.PostAsync(ApiBaseUrl, content);

                // ตรวจสอบว่า HTTP Status Code เป็น 2xx (Success) หรือไม่
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            try
            {
                // ส่งคำสั่ง DELETE ไปที่ API โดยต่อท้ายด้วย ID เช่น https://localhost:7241/api/products/1
                var response = await _httpClient.DeleteAsync($"{ApiBaseUrl}/{productId}");

                // ตรวจสอบว่า HTTP Status Code เป็น 2xx (Success) หรือไม่
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting product: {ex.Message}");
                return false;
            }
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(ApiBaseUrl);
                response.EnsureSuccessStatusCode();

                var jsonContent = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<List<ProductDto>>(jsonContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return products ?? new List<ProductDto>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching products from API: {ex.Message}", ex);
            }
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiBaseUrl}/{id}");
                response.EnsureSuccessStatusCode();

                var jsonContent = await response.Content.ReadAsStringAsync();
                var product = JsonSerializer.Deserialize<ProductDto>(jsonContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching product from API: {ex.Message}", ex);
            }
        }
    }
}