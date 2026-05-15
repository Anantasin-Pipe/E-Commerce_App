using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Server.Models
{
    // 🌟 ใส่ชื่อตารางให้ตรงกับใน Database ของคุณ (เช่น "bank" หรือ "banks")
    [Table("bank")]
    public class Bank
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")] // สมมติว่าคอลัมน์ชื่อธนาคารของคุณชื่อ name
        public string BankName { get; set; } = string.Empty;
    }
}