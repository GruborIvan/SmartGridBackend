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
    public class PoziviController : ApiController
    {
        IPozivRepository proxy;

        public PoziviController()
        {
            proxy = new PozivRepository();
        }


        //[System.Web.Http.Authorize]
        public IEnumerable<Poziv> Get()
        {
            return proxy.GetPozivi();
        }

        //[System.Web.Http.Authorize]
        [ResponseType(typeof(Poziv))]
        public IEnumerable<Poziv> Get(string incidentId)
        {
            return proxy.GetPoziviForIncident(incidentId);
        }


        // [System.Web.Http.Authorize]
        [ResponseType(typeof(Models.Poziv))]
        public IHttpActionResult Post(Poziv poziv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            proxy.AddPoziv(poziv);
            return CreatedAtRoute("DefaultApi", new { id = poziv.Id }, poziv);
        }
    }
}
