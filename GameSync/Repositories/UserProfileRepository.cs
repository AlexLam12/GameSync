using Microsoft.Extensions.Configuration;
using GameSync.Models;
using GameSync.Utils;

namespace GameSync.Repositories
{
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public UserProfileRepository(IConfiguration configuration) : base(configuration) { }

        public UserProfile GetByFirebaseUserId(string firebaseUserId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT up.Id, up.FirebaseUserId, up.Name, up.UserName, 
                               up.Email, up.CreateDateTime
                         FROM UserProfile up
                         WHERE FirebaseUserId = @FirebaseuserId";

                    DbUtils.AddParameter(cmd, "@FirebaseUserId", firebaseUserId);

                    UserProfile userProfile = null;

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        userProfile = new UserProfile()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            UserName = DbUtils.GetString(reader, "UserName"),
                            Email = DbUtils.GetString(reader, "Email"),
                            CreateDateTime = DbUtils.GetDateTime(reader, "CreateDateTime")

                        };
                    }
                    reader.Close();

                    return userProfile;
                }
            }
        }

        public void Add(UserProfile userProfile)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO UserProfile (FirebaseUserId, Name,  UserName, 
                                                                 Email, CreateDateTime)
                                        OUTPUT INSERTED.ID
                                        VALUES (@FirebaseUserId, @Name, @UserName, 
                                                @Email, sysdatetime())";
                    DbUtils.AddParameter(cmd, "@FirebaseUserId", userProfile.FirebaseUserId);
                    DbUtils.AddParameter(cmd, "@UserName", userProfile.UserName);
                    DbUtils.AddParameter(cmd, "@Name", userProfile.Name);
                    DbUtils.AddParameter(cmd, "@Email", userProfile.Email);

                    userProfile.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
