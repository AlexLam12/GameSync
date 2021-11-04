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
    public class UserGameController : ControllerBase
    {
        private readonly IUserGameRepository _userGameRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        public UserGameController(IUserGameRepository userGameRepository, IUserProfileRepository userProfileRepository)
        {
            _userGameRepository = userGameRepository;
            _userProfileRepository = userProfileRepository;
        }
        [HttpPost]
        public IActionResult Post(UserGame userGame)
        {
            var loggedInUser = GetCurrentUserProfile();

            userGame.UserProfile_id = loggedInUser.Id;

            _userGameRepository.Add(userGame);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userGameRepository.Delete(id);
            return NoContent();
        }
        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
        }


    }
}
