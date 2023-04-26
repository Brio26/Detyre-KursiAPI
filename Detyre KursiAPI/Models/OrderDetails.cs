using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Detyre_KursiAPI.Models
{
    public class OrderDetails
    {
        
        [Display(Name = "Id e Produktit")]
        public int ProduktId { get; set; }
        public Product? product { get; set; }
        public int PorosiId { get; set; }
        public Order? order { get; set; }
        public int? Pr_Sasia { get; set; }
        public double ShumaProdukt { get; set; }

    }
 
}
