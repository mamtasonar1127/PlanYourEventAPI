using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlanYourEventAPI.Models
{
    public class EventDesp
    {
        [Key]
        public int EDId { get; set; }

        [Required]
        public string ED_Name { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Photo { get; set; }
        public int Event_Id { get; set; }
    }
}
