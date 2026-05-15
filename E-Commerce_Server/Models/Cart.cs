using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Server.Models
{
    [Table("cart")]
    public class Cart
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("session_id")]
        public string? SessionId { get; set; }

    }
}