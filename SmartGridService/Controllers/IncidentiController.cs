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
    [RoutePrefix("Incidenti")]
    public class IncidentiController : ApiController
    {
        IIncidentRepository proxy;

        public IncidentiController()
        {
            proxy = new IncidentRepository();
        }

        //[System.Web.Http.Authorize]
        public IEnumerable<Incident> Get()
        {
            return proxy.GetIncidenti();
        }

        public IHttpActionResult GetIncident(string incidentId)
        {
            Incident i = proxy.GetIncidentById(incidentId);
            if (i == null)
            {
                return NotFound();
            }
            return Ok(i);
        }

        //[System.Web.Http.Authorize]
        public IQueryable<Incident> Get(string username)
        {
            return proxy.GetMyIncidenti(username);
        }

        // [System.Web.Http.Authorize]
        [ResponseType(typeof(Models.Incident))]
        public IHttpActionResult Put(string id, [FromBody] Incident incident)
        {
            if (incident.ID != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                proxy.UpdateIncident(incident);
            }
            catch (Exception e) { return BadRequest(); }
            return Ok(proxy.GetIncidentById(id));
        }

        //[System.Web.Http.Authorize]
        [ResponseType(typeof(Models.Incident))]
        public IHttpActionResult Post(Incident incident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            proxy.AddIncident(incident);
            return CreatedAtRoute("DefaultApi", new { id = incident.ID }, incident);
        }

    }
}
