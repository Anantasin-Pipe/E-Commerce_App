using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Server.Models
{
    public enum PaymentStatus
    {
        Pending,
        Success,
        Failed
    }

    [Table("receipt")]
    public class Receipt
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("cart_id")] 
        public int CartId { get; set; }

        [Column("bank_id")] 
        public int? BankId { get; set; }

        [Column("payment_id")]
        public int PaymentId { get; set; }
    }
}