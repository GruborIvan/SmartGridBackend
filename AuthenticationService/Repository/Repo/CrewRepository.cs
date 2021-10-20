using AuthenticationService.Models;
using AuthenticationService.Models.DTOs;
using AuthenticationService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AuthenticationService.Repository.Repo
{
    public class CrewRepository : ICrewRepository
    {
        ApplicationDbContext db;
        public CrewRepository()
        {
            db = new ApplicationDbContext();
        }

        public void AssignUserToCrew(CrewPostDTO dto)
        {
            UserInfo uInfo = db.UserInfos.Find(dto.UserId);
            if (uInfo != null)
            {
                try
                {
                    uInfo.EkipaId = dto.CrewId;
                    db.Entry<UserInfo>(uInfo).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (DBConcurrencyException e)
                {
                    Trace.TraceInformation(e.Message);
                }
            }
        }

        public IEnumerable<Crew> GetAll()
        {
            return db.Crews;
        }

        public Crew GetEkipaById(int id)
        {
            return db.Crews.Find(id);
        }

    }
}