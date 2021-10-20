using SmartGridService.Models;
using SmartGridService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGridService.Repository.Repository
{
    public class PozivRepository : IPozivRepository
    {
        SmartGridDbContext db;

        public PozivRepository()
        {
            db = new SmartGridDbContext();
        }

        public void AddPoziv(Poziv poziv)
        {
            db.Pozivi.Add(poziv);
            db.SaveChanges();
        }

        public IEnumerable<Poziv> GetPozivi()
        {
            return db.Pozivi;
        }

        public IEnumerable<Poziv> GetPoziviForIncident(string incidentId)
        {
            return db.Pozivi.Where(x => x.IncidentId == incidentId);
        }

        public IEnumerable<Poziv> GetPoziviSorted(string columnName)
        {
            List<Poziv> pozivi = db.Pozivi.ToList();

            switch (columnName)
            {
                case "Razlog": return pozivi.OrderBy(x => x.Razlog);
                case "UsernameKor": return pozivi.OrderBy(x => x.UsernameKor);
                case "Kvar": return pozivi.OrderBy(x => x.Kvar);
                case "IncidentId": return pozivi.OrderBy(x => x.IncidentId);
                default: return pozivi;
            }
        }

    }
}