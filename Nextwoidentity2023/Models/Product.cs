using System.ComponentModel.DataAnnotations.Schema;

namespace Nextwoidentity2023.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string? Name { get; set; }
        
        public string? Description { get; set; }
        public int Price { get; set; }
        [ForeignKey("Category")]
        public int CattegoryId { get; set; }
        public Category? Category { get; set; }
    }
}
