using AuthenticationService.Models;
using AuthenticationService.Models.DTOs;
using AuthenticationService.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AuthenticationService.Repository.Repo
{
    public class UserInfoRepository : IUserInfoRepository
    {
        ApplicationDbContext db;

        public UserInfoRepository()
        {
            db = new ApplicationDbContext();
        }

        public void ApproveByAdmin(string username, int val)
        {
            UserInfo uinfo = db.UserInfos.Where(x => x.Username == username).FirstOrDefault();
            uinfo.IsAdminApproved = val;
            db.Entry<UserInfo>(uinfo).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
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

        public IQueryable<UserInfo> GetCrewMembers()
        {
            return db.UserInfos.Where(x => x.VrsteKorisnika == VrsteKorisnika.CLANEKIPE).Where(x => x.EkipaId == 0);
        }

        public UserInfo GetUserInfoByUsername(string username)
        {
            return db.UserInfos.Where(x => x.Username == username).FirstOrDefault();
        }

        public IQueryable<UserInfo> GetUsersForApprove()
        {
            return db.UserInfos.Where(x => x.IsAdminApproved == 1);
        }

        public void PostUser(UserInfo userInfo)
        {
            if (userInfo.VrsteKorisnika == VrsteKorisnika.ADMINISTRATOR || userInfo.Username == "ivan.grubor@gmail.com")
            {
                userInfo.IsAdminApproved = 0;
            }
            else
            {
                userInfo.IsAdminApproved = 1;
            }
            db.UserInfos.Add(userInfo);
            db.SaveChanges();
        }

        public void UpdateUser(UserDTO userInfo)
        {
            UserInfo uInfo = db.UserInfos.Where(x => x.Username == userInfo.Username).First();
            uInfo.Username = userInfo.Username;
            uInfo.DatumRodjenja = userInfo.DatumRodjenja;
            uInfo.NazivProfilneSlike = userInfo.NazivProfilneSlike;
            uInfo.Ime = userInfo.Ime;
            uInfo.Prezime = userInfo.Prezime;
            if (uInfo.VrsteKorisnika != VrsteKorisnika.ADMINISTRATOR)
            {
                uInfo.IsAdminApproved = 1;
            }
            uInfo.VrsteKorisnika = userInfo.UserType;
            db.Entry<UserInfo>(uInfo).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}