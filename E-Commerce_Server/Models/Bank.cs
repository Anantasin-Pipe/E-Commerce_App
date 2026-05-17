using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Server.Models
{
    [Table("bank")]
    public class Bank
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")] 
        public string BankName { get; set; } = string.Empty;
    }
}