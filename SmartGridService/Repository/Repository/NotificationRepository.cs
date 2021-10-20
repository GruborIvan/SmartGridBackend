using SmartGridService.Models;
using SmartGridService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGridService.Repository.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        SmartGridDbContext db;

        public NotificationRepository()
        {
            db = new SmartGridDbContext();
        }

        public void AddNotification(Notifikacija poruka)
        {
            db.Notifikacije.Add(poruka);
            db.SaveChanges();
        }

        public IQueryable<Notifikacija> GetAll()
        {
            return db.Notifikacije;
        }

        public IQueryable<Notifikacija> GetAllUnread()
        {
            return db.Notifikacije.Where(x => x.Procitana == false);
        }

        public IQueryable<Notifikacija> GetByType(TipPoruke tip)
        {
            return db.Notifikacije.Where(x => x.Tip == tip);
        }

        public void MarkNotificationRead(string notificationId)
        {
            Notifikacija p = db.Notifikacije.Find(notificationId);
            p.Procitana = true;
            db.Entry<Notifikacija>(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void ReadAll(List<string> ajdijevi)
        {
            foreach (string item in ajdijevi)
            {
                Notifikacija p = db.Notifikacije.ToList().Find(x => x.IdPoruke == item);
                p.Procitana = true;
                db.Entry<Notifikacija>(p).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}