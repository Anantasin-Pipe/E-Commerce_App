using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Server.Models
{
    [Table("product")]
    public class Product
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("image_url")]
        public string ImageUrl { get; set; } = string.Empty;

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("price")]
        public int Price { get; set; }

        [Column("description")]
        public string Description { get; set; } = string.Empty;
    }
}