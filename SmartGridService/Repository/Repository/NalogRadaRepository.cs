using SmartGridService.Models;
using SmartGridService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGridService.Repository.Repository
{
    public class NalogRadaRepository : INalogRadaRepository
    {
        SmartGridDbContext db;

        public NalogRadaRepository()
        {
            db = new SmartGridDbContext();
        }

        public void AddNalogRada(NalogRada nalogRada)
        {
            db.NaloziRada.Add(nalogRada);
            db.SaveChangesAsync();
        }

        public IQueryable<NalogRada> SortByColumn(string columnName)
        {
            switch (columnName)
            {
                case "ID":
                    return db.NaloziRada.OrderBy(x => x.IdNaloga);
                case "Tip":
                    return db.NaloziRada.OrderBy(x => x.Type);
                case "CreatedTime":
                    return db.NaloziRada.OrderBy(x => x.CreatedTime);
                case "StartDate":
                    return db.NaloziRada.OrderBy(x => x.PocetakRada);
                case "EndDate":
                    return db.NaloziRada.OrderBy(x => x.KrajRada);
                default:
                    return db.NaloziRada;
            }
        }
    }
}