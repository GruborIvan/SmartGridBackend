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
    public class OpremaController : ApiController
    {
        IOpremaRepository repo;

        public OpremaController()
        {
            repo = new OpremaRepository();
        }

        public IEnumerable<Oprema> Get()
        {
            return repo.GetOprema();
        }

        // [System.Web.Http.Authorize]
        public IEnumerable<Oprema> GetOprema(string incId)
        {
            List<Oprema> opr = repo.GetOprema().ToList();
            return opr.Where(x => x.IncidentId == incId);
        }

        [ResponseType(typeof(Models.Oprema))]
        public IHttpActionResult Put(string id, [FromBody] Oprema ekipa)
        {
            if (ekipa.IdOprema != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                repo .UpdateOprema(ekipa);
            }
            catch (Exception e) { return BadRequest(); }
            return Ok(repo.GetOpremaById(id));
        }

        // [System.Web.Http.Authorize]
        [ResponseType(typeof(Models.Oprema))]
        public IHttpActionResult Post(Oprema oprema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            repo.AddOprema(oprema);
            return CreatedAtRoute("DefaultApi", new { id = oprema.IdOprema }, oprema);
        }


        // [System.Web.Http.Authorize]
        [ResponseType(typeof(Oprema))]
        public IHttpActionResult Get(string id)
        {
            Oprema ek = repo.GetOpremaById(id);
            if (ek == null)
            {
                return NotFound();
            }
            return Ok(ek);
        }


        // [System.Web.Http.Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(string id)
        {
            Oprema oprema = repo.GetOpremaById(id);

            if (oprema == null)
            {
                return NotFound();
            }

            repo.DeleteOprema(oprema);
            return Ok();
        }

    }
}
