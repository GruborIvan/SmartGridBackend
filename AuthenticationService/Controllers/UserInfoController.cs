using AuthenticationService.Models;
using AuthenticationService.Models.DTOs;
using AuthenticationService.Repository;
using AuthenticationService.Repository.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AuthenticationService.Controllers
{
    public class UserInfoController : ApiController
    {
        IUserInfoRepository _repository;

        public UserInfoController()
        {
            _repository = new UserInfoRepository();
        }

        public IHttpActionResult Get(string username)
        {
            UserInfo uifo = _repository.GetUserInfoByUsername(username);
            if (uifo == null)
            {
                return NotFound();
            }
            if (uifo.IsAdminApproved == 1)
            {
                return Unauthorized();
            }
            return Ok(uifo);
        }

        public IHttpActionResult PostApproveAdmin(string username, int val)
        {
            _repository.ApproveByAdmin(username, val);
            return Ok();
        }

        public IQueryable<UserInfo> GetUsersForApprove()
        {
            return _repository.GetUsersForApprove();
        }

        public IHttpActionResult Post([FromBody] UserInfo uInfo)
        {
            if (uInfo.Username == "ivan.grubor@gmail.com")
            {
                return Ok();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.PostUser(uInfo);
            return CreatedAtRoute("DefaultApi", new { id = uInfo.Id }, uInfo);
        }

        public IHttpActionResult Put([FromBody] UserDTO uInfo)
        {
            _repository.UpdateUser(uInfo);
            return Ok(_repository.GetUserInfoByUsername(uInfo.Username));
        }

    }
}
