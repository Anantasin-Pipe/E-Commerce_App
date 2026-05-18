using System;

namespace ClientApp.Services
{
    public class OrderStatusDto
    {
        public string ReceiptId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public string? TrackingNumber { get; set; }
        public string? DeliveryTime { get; set; }
    }
}