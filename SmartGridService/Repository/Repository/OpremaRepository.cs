using SmartGridService.Models;
using SmartGridService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGridService.Repository.Repository
{
    public class OpremaRepository : IOpremaRepository
    {
        SmartGridDbContext db;

        public OpremaRepository()
        {
            db = new SmartGridDbContext();
        }

        public void AddOprema(Oprema oprema)
        {
            db.Oprema.Add(oprema);
            db.SaveChanges();
        }

        public void DeleteOprema(Oprema oprema)
        {
            db.Oprema.Remove(oprema);
            db.SaveChanges();
        }

        public IEnumerable<Oprema> GetOprema()
        {
            return db.Oprema;
        }

        public Oprema GetOpremaById(string id)
        {
            return db.Oprema.Find(id);
        }

        public void UpdateOprema(Oprema oprema)
        {
            Oprema o = db.Oprema.Find(oprema.IdOprema);
            o = oprema;
            db.SaveChanges();
        }
    }
}