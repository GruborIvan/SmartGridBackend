using AuthenticationService.Models;
using AuthenticationService.Models.DTOs;
using AuthenticationService.Repository.Interfaces;
using AuthenticationService.Repository.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuthenticationService.Controllers
{
    public class EkipaController : ApiController
    {
        ICrewRepository _repository;

        public EkipaController()
        {
            _repository = new CrewRepository();
        }

        public IEnumerable<Crew> Get()
        {
            return _repository.GetAll();
        }

        public IHttpActionResult PostAssignUserToCrew([FromBody] CrewPostDTO dto)
        {
            _repository.AssignUserToCrew(dto);
            return Ok();
        }

    }
}
