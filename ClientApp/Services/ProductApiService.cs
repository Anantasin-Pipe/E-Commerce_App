using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientApp.Services
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Description { get; set; } = string.Empty;
    }

    public interface IProductApiService
    {
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto?> GetProductByIdAsync(int id);
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