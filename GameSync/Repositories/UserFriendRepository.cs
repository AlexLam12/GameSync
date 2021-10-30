using GameSync.Models;
using GameSync.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSync.Repositories
{
    public class UserFriendRepository : BaseRepository, IUserFriendRepository
    {
        public UserFriendRepository(IConfiguration configuration) : base(configuration) { }
        public List<UserFriend> GetAllMyFriends(int userProfileId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                          SELECT uf.Id, uf.UserProfile_id, uf.Friend_id, 
                                 upf.Id as FriendId, upf.UserName as FriendUserName, upf.Name as FriendName, 
                                 up.Id as UserProfileId
                            FROM UserFriend uf
                            Left JOIN UserProfile up on uf.UserProfile_id = up.Id
                            Left JOIN UserProfile upf on uf.Friend_id = upf.id
                        ORDER BY UserName
                    ";

                    var reader = cmd.ExecuteReader();

                    var friends = new List<Friend>();
                    while (reader.Read())
                    {
                        friends.Add(new Friend()
                        {
                            Id = DbUtils.GetInt(reader, "FriendId"),
                            UserName = DbUtils.GetString(reader, "FriendUserName"),
                            Name = DbUtils.GetString(reader, "FriendName")
                            
                        });
                    }

                    reader.Close();

                    return friends;
                }
            }
        }
    }
}
