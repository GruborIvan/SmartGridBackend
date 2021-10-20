using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartGridService.Models
{
    public class Poziv
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Razlog { get; set; }

        [Required]
        [StringLength(255)]
        public string Komentar { get; set; }

        [Required]
        [StringLength(255)]
        public string Kvar { get; set; }

        [StringLength(255)]
        public string UsernameKor { get; set; }


        public string IncidentId { get; set; }

        public Poziv() { }

        public Poziv(int id, string razlog, string komentar, string kvar, string idk)
        {
            this.Id = id;
            this.Razlog = razlog;
            this.Komentar = komentar;
            this.Kvar = kvar;
            this.UsernameKor = idk;

        }
    }
}