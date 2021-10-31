using GameSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSync.Repositories
{
    public interface IUserFriendRepository
    {
        List<UserProfile> GetAllMyFriends(int userProfileId);
        List<UserProfile> GetAll();
        List<UserProfile> Search(string criterion);

    }
}
