using AuthenticationService.Models;
using AuthenticationService.Repository;
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
    public class ClanoviEkipeController : ApiController
    {
        IUserInfoRepository repo;
        ICrewRepository repo2;

        public ClanoviEkipeController()
        {
            this.repo = new UserInfoRepository();
            this.repo2 = new CrewRepository();
        }

        public IEnumerable<UserInfo> GetNonAssignedUsers()
        {
            return repo2.GetUnassignedCrewMembers();
        }

    }
}
