using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartGridService.Models
{
    public class Resolution
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Cause { get; set; }

        [Required]
        public string SubCause { get; set; }

        [Required]
        public string Construction { get; set; }

        [Required]
        public string Material { get; set; }

        [Required]
        public string IncidentId { get; set; }

        public Resolution()
        {

        }
    }
}