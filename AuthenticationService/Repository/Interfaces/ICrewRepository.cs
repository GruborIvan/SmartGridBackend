using AuthenticationService.Models;
using AuthenticationService.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationService.Repository.Interfaces
{
    public interface ICrewRepository
    {
        IEnumerable<Crew> GetAll();
        Crew GetEkipaById(int id);
        void AssignUserToCrew(CrewPostDTO dto);
        IEnumerable<UserInfo> GetUnassignedCrewMembers();
    }
}