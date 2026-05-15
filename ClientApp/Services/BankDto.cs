namespace ClientApp
{
    public class BankDto
    {
        public int Id { get; set; }

        // เปลี่ยนมาใช้ BankName แทน Name
        public string BankName { get; set; } = string.Empty;
    }
}