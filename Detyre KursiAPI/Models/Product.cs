using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;

namespace Detyre_KursiAPI.Models
{
    public class Product
    {

        [Key]
        [Required]
        public int Id { get; set; }
        public string? Emri { get; set; }
        [Required]
        [Range(0.01, double.MaxValue)]
        [Column(TypeName = "decimal(8, 2)")]
        [ReadOnly(true)]
        public double Cmimi { get; set; }
        [Range(1, Int32.MaxValue)]
        public int? Sasia { get; set; }
        public string? Pershkrimi { get; set; }
        public List<OrderDetails>? orderDetails { get; set; }

    }
}
