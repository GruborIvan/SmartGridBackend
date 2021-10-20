﻿using SmartGridService.Models;
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
    public class NaloziRadaController : ApiController
    {
        INalogRadaRepository repo;

        public NaloziRadaController()
        {
            repo = new NalogRadaRepository();
        }

        public IEnumerable<NalogRada> Get(string columnName = "ID")
        {
            return repo.SortByColumn(columnName);
        }

        public IHttpActionResult Post([FromBody] NalogRada nalogRada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.AddNalogRada(nalogRada);
            return Ok();
        }

    }
}
