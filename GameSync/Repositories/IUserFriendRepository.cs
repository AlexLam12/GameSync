using GameSync.Models;
using System.Collections.Generic;

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
