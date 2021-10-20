using SmartGridService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGridService.Repository.Interfaces
{
    public interface IOpremaRepository
    {
        IEnumerable<Oprema> GetOprema();
        Oprema GetOpremaById(string id);
        void AddOprema(Oprema oprema);
        void UpdateOprema(Oprema oprema);
        void DeleteOprema(Oprema oprema);
    }
}
