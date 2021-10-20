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
    public class PoziviSortController : ApiController
    {
        IPozivRepository repo;

        public PoziviSortController()
        {
            repo = new PozivRepository();
        }

        public IEnumerable<Poziv> Get(string columnName = "Razlog")
        {
            return repo.GetPoziviSorted(columnName);
        }
    }
}
