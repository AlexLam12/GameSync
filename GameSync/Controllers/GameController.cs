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
        public class GameController : ControllerBase
        {
            private readonly IGameRepository _gameRepository;
            private readonly IUserProfileRepository _userProfileRepository;


            public GameController(IGameRepository gameRepository, IUserProfileRepository userProfileRepository)
            {
                _gameRepository = gameRepository;
                _userProfileRepository = userProfileRepository;
            }

        [HttpGet]
            public IActionResult GetAll()
            {
                return Ok(_gameRepository.GetAll());
            }

        [HttpGet("myGames")]
            public IActionResult Get()
            {
                var loggedInUser = GetCurrentUserProfile();
  
                return Ok(_gameRepository.GetAllMyGames(loggedInUser.Id));
            }
        [HttpGet("search")]
        public IActionResult Search(string q)
        {
            if (string.IsNullOrEmpty(q))
            {
                return Ok(_gameRepository.GetAll());
            }

            return Ok(_gameRepository.Search(q));
        }
        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
        }
    }
}
