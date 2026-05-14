namespace E_Commerce_Server.Models
{
    public enum PaymentStatus
    {
        Pending,
        Success,
        Failed
    }

    public class Receipt
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int BankId { get; set; }
        public int PaymentId { get; set; }
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;
    }
}