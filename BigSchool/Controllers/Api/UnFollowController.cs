using BigSchool.DTOs;
using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BigSchool.Controllers.Api
{
    public class UnFollowController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public UnFollowController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [Authorize]
        [HttpPost]

        public IHttpActionResult UnFollow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();

            var FollowToDel = _dbContext
                .Followings
                .FirstOrDefault(a => a.FollowerId == userId && a.FolloweeId == followingDto.FolloweeId);

            if (FollowToDel == null)
            {
                return BadRequest("The Follow not exists!");
            }
            _dbContext.Followings.Remove(FollowToDel);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
