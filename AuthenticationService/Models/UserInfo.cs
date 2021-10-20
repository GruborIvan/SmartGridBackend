using AuthenticationService.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationService.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public VrsteKorisnika VrsteKorisnika { get; set; }
        public string NazivProfilneSlike { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public int IsAdminApproved { get; set; }
        public int EkipaId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public UserInfo(string username)
        {
            Username = username;
        }

        public UserInfo()
        {

        }
    }
}