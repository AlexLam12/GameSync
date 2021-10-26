using GameSync.Models;
using GameSync.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGameController : ControllerBase
    {
        private readonly IUserGameRepository _userGameRepository;
        public UserGameController(IUserGameRepository userGameRepository)
        {
            _userGameRepository = userGameRepository;
        }
        [HttpPost]
        public IActionResult Post(UserGame userGame)
        {
            _userGameRepository.Add(userGame);
            return CreatedAtAction("Get", new { id = userGame.Id }, userGame);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userGameRepository.Delete(id);
            return NoContent();
        }
    }
}
