using SmartGridService.Models;
using SmartGridService.Repository.Interfaces;
using SmartGridService.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SmartGridService.Controllers
{
    public class PorukaController : ApiController
    {
        INotificationRepository repo;

        public PorukaController()
        {
            repo = new NotificationRepository();
        }

        public IQueryable<Notifikacija> GetByType(TipPoruke tip)
        {
            return repo.GetByType(tip);
        }

        public IEnumerable<Notifikacija> Get(string mode)
        {
            if (mode == "all")
            {
                return repo.GetAll();
            }
            else
            {
                return repo.GetAllUnread();
            }
        }

        [ResponseType(typeof(Notifikacija))]
        public IHttpActionResult Post(Notifikacija poziv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            repo.AddNotification(poziv);
            return CreatedAtRoute("DefaultApi", new { id = poziv.IdPoruke }, poziv);
        }

        public IHttpActionResult Put(List<string> ids)
        {
            if (ids == null)
            {
                return Ok();
            }
            if (ids.Count > 0)
            {
                repo.ReadAll(ids);
            }
            return Ok(repo.GetAllUnread());
        }

    }
}
