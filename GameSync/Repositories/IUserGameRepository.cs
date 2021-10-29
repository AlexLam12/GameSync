using GameSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSync.Repositories
{
    public interface IUserGameRepository
    {
        int Add(UserGame userGame);
        void Delete(int id);
        
    }
}
