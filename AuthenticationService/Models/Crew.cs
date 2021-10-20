using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthenticationService.Models
{
    public class Crew
    {
        public int Id { get; set; }

        [Required]
        public string NazivEkipe { get; set; }

        public Crew() { }
        public Crew(int id, string naziv)
        {
            this.Id = id;
            this.NazivEkipe = naziv;
        }
    }
}