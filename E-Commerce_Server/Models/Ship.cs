namespace E_Commerce_Server.Models
{
    public class Ship
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? DeliveryRate { get; set; }
    }
}