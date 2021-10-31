using GameSync.Models;
using GameSync.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GameSync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserFriendController : ControllerBase
    {
        private readonly IUserFriendRepository _userFriendRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        public UserFriendController(IUserFriendRepository userFriendRepository, IUserProfileRepository userProfileRepository)
        {
            _userFriendRepository = userFriendRepository;
            _userProfileRepository = userProfileRepository;
        }
        [HttpGet("myFriends")]
        public IActionResult Get()
        {
            var loggedInUser = GetCurrentUserProfile();

            return Ok(_userFriendRepository.GetAllMyFriends(loggedInUser.Id));
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userFriendRepository.GetAll());
        }
        [HttpGet("search")]
        public IActionResult Search(string q)
        {
            if (string.IsNullOrEmpty(q))
            {
                return Ok(_userFriendRepository.GetAll());
            }

            return Ok(_userFriendRepository.Search(q));
        }
        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
        }
    }
}
