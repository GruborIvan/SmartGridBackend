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
    public class SafetyDocumentsController : ApiController
    {
        ISafetyDocumentRepository repo;

        public SafetyDocumentsController()
        {
            repo = new SafetyDocumentsRepository();
        }

        public IEnumerable<SafetyDocument> Get(string columnName = "ID")
        {
            return repo.SortByColumn(columnName);
        }

        public IHttpActionResult GetById(int id)
        {
            SafetyDocument sd = repo.GetById(id);
            if (sd == null)
            {
                return NotFound();
            }
            return Ok(sd);
        }

        public IHttpActionResult Post([FromBody] SafetyDocument safetyDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.AddSafetyDocument(safetyDocument);
            return CreatedAtRoute("DefaultApi", new { id = safetyDocument.Id }, safetyDocument);
        }

    }
}
