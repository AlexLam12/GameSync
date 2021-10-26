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
        public void Add(UserGame userGame)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO UserGame (UserProfile_id, Game_Id)
                                        OUTPUT INSERTED.ID 
                                        VALUES (@UserProfile_id, @Game_Id)";

                    cmd.Parameters.AddWithValue("@UserProfile_id", userGame.UserProfile_id);
                    cmd.Parameters.AddWithValue("@Game_Id", userGame.Game_id);

                    userGame.Id = (int)cmd.ExecuteScalar();
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
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
