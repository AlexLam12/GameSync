using GameSync.Models;
using GameSync.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

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
                        ORDER BY FriendUserName
                    ";

                    var reader = cmd.ExecuteReader();

                    var friends = new List<UserFriend>();
                    while (reader.Read())
                    {
                        friends.Add(new UserFriend()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            UserProfile = new UserProfile
                            {
                                UserName = DbUtils.GetString(reader, "FriendUserName"),
                                Name = DbUtils.GetString(reader, "FriendName")
                            },
                            
                        });
                    }

                    reader.Close();

                    return friends;
                }
            }
        }
        public List<UserProfile> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                          SELECT Id, UserName, Name, Email
                            FROM UserProfile
                        ORDER BY UserName
                    ";

                    var reader = cmd.ExecuteReader();

                    var users = new List<UserProfile>();
                    while (reader.Read())
                    {
                        users.Add(new UserProfile()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            UserName = DbUtils.GetString(reader, "UserName"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Email = DbUtils.GetString(reader, "Email")
                        });
                    }

                    reader.Close();

                    return users;
                }
            }
        }
        public List<UserProfile> Search(string criterion)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, UserName, Name, Email
                                            FROM UserProfile
                                         WHERE UserName LIKE @criterion
                                         ORDER BY UserName
                                        ";

                    cmd.Parameters.AddWithValue("@criterion", $"%{criterion}%");
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<UserProfile> users = new List<UserProfile>();

                    while (reader.Read())
                    {
                        users.Add(new UserProfile()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            UserName = DbUtils.GetString(reader, "UserName"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Email = DbUtils.GetString(reader, "Email")
                        });
                    }

                    reader.Close();

                    return users;
                }
            }
        }
        public int Add(UserFriend userFriend)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO UserFriend (UserProfile_id, Friend_id)
                                        OUTPUT INSERTED.ID 
                                        VALUES (@UserProfile_id, @Friend_id)";

                    cmd.Parameters.AddWithValue("@UserProfile_id", userFriend.UserProfile_id);
                    cmd.Parameters.AddWithValue("@Friend_id", userFriend.Friend_id);

                    return userFriend.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM UserFriend WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
