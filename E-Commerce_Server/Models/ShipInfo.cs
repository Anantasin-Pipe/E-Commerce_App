using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Server.Models
{
    public enum DeliveryStatus
    {
        Preparing = 0, 
        Shipping = 1, 
        Delivered = 2  
    }

    [Table("ship_info")] // 🌟 แมปชื่อตาราง
    public class ShipInfo
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("receipt_id")]
        public int ReceiptId { get; set; }

        [Column("delivery_status")]
        public DeliveryStatus DeliveryStatus { get; set; } = DeliveryStatus.Preparing;

        [Column("delivery_time")]
        public DateTime? DeliveryTime { get; set; }

        [Column("tracking_number")]
        public string? TrackingNumber { get; set; }
    }
}