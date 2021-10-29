using GameSync.Models;
using GameSync.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSync.Repositories
{
    public class UserGameRepository : IUserGameRepository
    {
        private readonly string _connectionString;
        public UserGameRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        private SqlConnection Connection
        {
            get { return new SqlConnection(_connectionString); }
        }
        public int Add(UserGame userGame)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO UserGame (UserProfile_id, Game_id)
                                        OUTPUT INSERTED.ID 
                                        VALUES (@UserProfile_id, @Game_id)";

                    cmd.Parameters.AddWithValue("@UserProfile_id", userGame.UserProfile_id);
                    cmd.Parameters.AddWithValue("@Game_id", userGame.Game_id);

                    return userGame.Id = (int)cmd.ExecuteScalar();
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
                    cmd.CommandText = "DELETE FROM UserGame WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        
    }
}
