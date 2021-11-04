using GameSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSync.Repositories
{
    public interface IUserFriendRepository
    {
        List<UserFriend> GetAllMyFriends(int userProfileId);
        List<UserProfile> GetAll();
        List<UserProfile> Search(string criterion);
        int Add(UserFriend userFriend);
        void Delete(int id);

    }
}
