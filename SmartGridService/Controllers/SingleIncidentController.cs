using SmartGridService.Models;
using SmartGridService.Repository.Interfaces;
using SmartGridService.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGridService.Controllers
{
    public class SingleIncidentController : ApiController
    {
        IIncidentRepository _repo;

        public SingleIncidentController()
        {
            _repo = new IncidentRepository();
        }

        public IHttpActionResult Get(string incidentId)
        {
            Incident inc = _repo.GetIncidentById(incidentId);
            if (inc == null)
            {
                return NotFound();
            }
            return Ok(inc);
        }
    }
}
