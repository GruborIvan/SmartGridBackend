using AuthenticationService.Models;
using AuthenticationService.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationService.Repository
{
    public interface IUserInfoRepository
    {
        UserInfo GetUserInfoByUsername(string username);
        IQueryable<UserInfo> GetCrewMembers();
        IQueryable<UserInfo> GetUsersForApprove();
        void ApproveByAdmin(string username, int val);
        void PostUser(UserInfo userInfo);
        void UpdateUser(UserDTO userInfo);
        void AssignUserToCrew(CrewPostDTO dto);
    }
}