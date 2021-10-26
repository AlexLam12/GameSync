using GameSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSync.Repositories
{
    public interface IGameRepository
    {
        List<Game> GetAll();
        List<Game> Search(string criterion);
        List<Game> GetAllMyGames(int userProfileId);
        Game GetById(int id);

    }
}
