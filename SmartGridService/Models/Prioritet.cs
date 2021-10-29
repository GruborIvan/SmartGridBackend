using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartGridService.Models
{
    public class Prioritet
    {
        [Required]
        public string Ulica { get; set; }

        [Required]
        public int RedPrioriteta { get; set; }
    }
}