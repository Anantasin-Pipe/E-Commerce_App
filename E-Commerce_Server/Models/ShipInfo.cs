namespace E_Commerce_Server.Models
{
    public enum DeliveryStatus
    {
        Preparing,
        Shipping,
        Delivered
    }

    public class ShipInfo
    {
        public int Id { get; set; }
        public int ReceiptId { get; set; }
        public int SellerId { get; set; }
        public int ShipId { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; } = DeliveryStatus.Preparing;
        public DateTime? DeliveryTime { get; set; }
        public string? TrackingNumber { get; set; }
    }
}