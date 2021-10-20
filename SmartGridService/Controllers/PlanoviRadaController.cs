using SmartGridService.Models;
using SmartGridService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGridService.Controllers
{
    public class PlanoviRadaController : ApiController
    {
        IPlanRadaRepository repo;

        public PlanoviRadaController()
        {
            repo = new Repository.Repository.PlanRadaRepository();
        }

        public IQueryable<PlanRada> Get(string columnName = "ID")
        {
            return repo.SortByColumn(columnName);
        }

        public IHttpActionResult Post([FromBody] PlanRada planRada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.AddPlanRada(planRada);
            return CreatedAtRoute("DefaultApi", new { id = planRada.IdPlana }, planRada);
        }

    }
}
