using E_Commerce_Server.Data;
using E_Commerce_Server.Services;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add DbContext
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Host=localhost;Database=ecommerce;Username=postgres;Password=1234";
            builder.Services.AddDbContext<ECommerceDbContext>(options =>
                options.UseNpgsql(connectionString)
            );

            // Add services
            builder.Services.AddScoped<IProductService, ProductService>();

            // Add CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowClientApp", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowClientApp");
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
