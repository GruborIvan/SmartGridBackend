using SmartGridService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGridService.Repository.Interfaces
{
    public interface IPozivRepository
    {
        IEnumerable<Poziv> GetPozivi();
        IEnumerable<Poziv> GetPoziviForIncident(string incidentId);
        IEnumerable<Poziv> GetPoziviSorted(string columnName);
        void AddPoziv(Poziv poziv);
    }
}
