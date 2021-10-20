using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartGridService.Models
{
    public class Notifikacija
    {
        [Key]
        public string IdPoruke { get; set; }
        [Required]
        public string IdKorisnika { get; set; }
        [Required]
        public string Sadrzaj { get; set; }
        [Required]
        public TipPoruke Tip { get; set; }
        [Required]
        public bool Procitana { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }

        public Notifikacija()
        {

        }
    }
}