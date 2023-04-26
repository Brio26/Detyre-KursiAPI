using System.ComponentModel.DataAnnotations;

namespace Detyre_KursiAPI.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public DateTime DataPorosis { get; set; }
        public List<OrderDetails>? orderDetails { get; set; }
        public double ShumaT { get; set; }
    }
}
