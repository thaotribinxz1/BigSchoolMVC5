using BigSchool.DTOs;
using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;



namespace BigSchool.Controllers
{
    public class FollowingsController : ApiController
    {
        // GET: Followings
        private readonly ApplicationDbContext _dbcontext;
        public FollowingsController()
        {
            _dbcontext = new ApplicationDbContext();
        }
        
       [HttpPost]
       [Authorize]
       public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbcontext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeID))
                return BadRequest("following already exist!");
            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeID

            };
            _dbcontext.Followings.Add(following);
            _dbcontext.SaveChanges();
            return Ok();
        }
       
       

    }
}