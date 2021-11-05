using GameSync.Models;
using System.Collections.Generic;

namespace GameSync.Repositories
{
    public interface IGameRepository
    {
        List<Game> GetAll();
        List<Game> Search(string criterion);
        List<Game> GetAllMyGames(int userProfileId);
        Game GetById(int id);
        UserGame GetUserGameById(int id);
    }
}
