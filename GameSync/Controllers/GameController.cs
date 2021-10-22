using GameSync.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace GameSync.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class GameController : ControllerBase
        {
            private readonly IGameRepository _gameRepository;

            public GameController(IGameRepository gameRepository)
            {
                _gameRepository = gameRepository;
            }

        [HttpGet]
            public IActionResult GetAll()
            {
                return Ok(_gameRepository.GetAll());
            }

        [HttpGet("MyGames")]
            public IActionResult Get()
            {
                return Ok(_gameRepository.GetAllMyGames());
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
    }
}
