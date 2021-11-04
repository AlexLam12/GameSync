using GameSync.Models;
using GameSync.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [HttpGet("myfriends")]
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
        [HttpPost]
        public IActionResult Post(UserFriend userFriend)
        {
            var loggedInUser = GetCurrentUserProfile();

            userFriend.UserProfile_id = loggedInUser.Id;

            _userFriendRepository.Add(userFriend);
            return CreatedAtAction("Get", new { id = userFriend.Id }, userFriend);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userFriendRepository.Delete(id);
            return NoContent();
        }
        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
        }
    }
}
