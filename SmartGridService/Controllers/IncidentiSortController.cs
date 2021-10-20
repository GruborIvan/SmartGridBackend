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
    public class IncidentiSortController : ApiController
    {
        IIncidentRepository proxy;

        public IncidentiSortController()
        {
            proxy = new IncidentRepository();
        }

        public IQueryable<Incident> GetSortedIncidents(string columnName = "ID")
        {
            return proxy.SortByColumn(columnName);
        }
    }
}
