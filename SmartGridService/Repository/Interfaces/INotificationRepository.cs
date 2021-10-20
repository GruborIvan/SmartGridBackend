using SmartGridService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGridService.Repository.Interfaces
{
    public interface INotificationRepository
    {
        IQueryable<Notifikacija> GetByType(TipPoruke tip);
        void ReadAll(List<string> ajdijevi);
        IQueryable<Notifikacija> GetAllUnread();
        IQueryable<Notifikacija> GetAll();

        void AddNotification(Notifikacija poruka);
        void MarkNotificationRead(string notificationId);
    }
}
