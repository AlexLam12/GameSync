using GameSync.Models;

namespace GameSync.Repositories
{
    public interface IUserGameRepository
    {
        int Add(UserGame userGame);
        void Delete(int id);
        
    }
}
