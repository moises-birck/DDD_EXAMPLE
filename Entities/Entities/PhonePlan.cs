using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entities
{
    public class PhonePlan : Base
    {
        [Display(Name = "Minuto")]
        public int Minute { get; set; }
        

        [Display(Name = "Acréscimo em %")]
        public int Addition { get; set; }
    }
}
