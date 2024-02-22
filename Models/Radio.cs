using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRadio.Models
{
    public class Radio
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? TypeOfRadio { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
