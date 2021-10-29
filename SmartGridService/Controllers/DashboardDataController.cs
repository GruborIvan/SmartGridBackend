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
    public class DashboardDataController : ApiController
    {
        IDashboardDataRepository repo;

        public DashboardDataController()
        {
            repo = new DashboardDataRepository();
        }

        public IHttpActionResult Get()
        {
            return Ok(repo.CalculateDashboardData());
        }

    }
}
