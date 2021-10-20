using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthenticationService.Models.DTOs
{
    public class CrewPostDTO
    {
        [Required]
        public int CrewId { get; set; }

        [Required]
        public int UserId { get; set; }

        public CrewPostDTO()
        {

        }
    }
}