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
        private readonly IUserGameRepository _userGameRepository;
        public UserFriendController(IUserFriendRepository userFriendRepository, IUserProfileRepository userProfileRepository)
        {
            _userFriendRepository = userFriendRepository;
            _userProfileRepository = userProfileRepository;
        }

        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
        }
    }
}
