using System.ComponentModel.DataAnnotations;


namespace Entities.Entities
{
    public class DDD : Base
    {

        [Display(Name = "Origem")]
        public int Origin { get; set; }
        
        [Display(Name = "Destino")]
        public int Destiny { get; set; }

        [Display(Name = "Preço por minuto")]
        public decimal PricePerMinute { get; set; }
                
    }
}
