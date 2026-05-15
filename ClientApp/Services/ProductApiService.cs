using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Json;
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

        Task<bool> DeleteProductAsync(int id);

    }

    public class ProductApiService : IProductApiService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://localhost:7241/api/products";

        public ProductApiService()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            _httpClient = new HttpClient(handler);
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

        // 🌟 2. เพิ่มฟังก์ชันนี้เพื่อยิง API สั่งลบข้อมูล
        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                // ส่งคำสั่งลบ ไปที่ URL: api/products/{id}
                var response = await _httpClient.DeleteAsync($"{ApiBaseUrl}/{id}");

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting product from API: {ex.Message}", ex);
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
        public async Task<bool> AddProductAsync(ProductDto product)
        {
            try
            {
                // ส่งข้อมูล Object product ไปที่ API แบบ POST
                var response = await _httpClient.PostAsJsonAsync(ApiBaseUrl, product);

                // คืนค่า true ถ้า API ตอบกลับมาว่าบันทึกสำเร็จ (Status Code 200-299)
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // ถ้ามีปัญหา เช่น Server ล่ม หรือต่อเน็ตไม่ได้ จะโยน Error ออกไปให้หน้าจอจัดการ
                throw new Exception($"Error adding product to API: {ex.Message}", ex);
            }
        }
    }
}