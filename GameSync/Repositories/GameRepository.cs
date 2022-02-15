using GameSync.Models;
using GameSync.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;


namespace GameSync.Repositories
{
    public class GameRepository : BaseRepository, IGameRepository
    {
        public GameRepository(IConfiguration configuration) : base(configuration) { }
        public List<Game> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                          SELECT Id, Title, NumPlayers, ImageLocation
                            FROM Game
                        ORDER BY Title
                    ";

                    var reader = cmd.ExecuteReader();

                    var games = new List<Game>();
                    while (reader.Read())
                    {
                        games.Add(new Game()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Title = DbUtils.GetString(reader, "Title"),
                            NumPlayers = DbUtils.GetString(reader, "NumPlayers"),
                            ImageLocation = DbUtils.GetString(reader, "ImageLocation")
                        });
                    }

                    reader.Close();

                    return games;
                }
            }
        }

        public List<Game> Search(string criterion)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Title, NumPlayers, ImageLocation
                                            FROM Game
                                         WHERE Title LIKE @criterion
                                         ORDER BY Title
                                        ";

                    cmd.Parameters.AddWithValue("@criterion", $"%{criterion}%");
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Game> games = new List<Game>();

                    while (reader.Read())
                    {
                        games.Add(new Game()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Title = DbUtils.GetString(reader, "Title"),
                            NumPlayers = DbUtils.GetString(reader, "NumPlayers"),
                            ImageLocation = DbUtils.GetString(reader, "ImageLocation")
                        });
                    }

                    reader.Close();

                    return games;
                }
            }
        }

        public List<Game> GetAllMyGames(int userProfileId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                          SELECT ug.Id, ug.UserProfile_id, ug.Game_id, 
                                 g.Id as GameId, g.Title, g.NumPlayers, g.ImageLocation, 
                                 up.Id as UserProfileId
                            FROM UserGame ug
                            Left JOIN UserProfile up on ug.UserProfile_id = up.Id
                            Left JOIN Game g on ug.Game_id = g.id
                        WHERE up.Id = @id
                        ORDER BY Title
                    ";
                    cmd.Parameters.AddWithValue("@id", userProfileId);
                    var reader = cmd.ExecuteReader();

                    var games = new List<Game>();
                    while (reader.Read())
                    {
                        games.Add(new Game()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Title = DbUtils.GetString(reader, "Title"),
                            NumPlayers = DbUtils.GetString(reader, "NumPlayers"),
                            ImageLocation = DbUtils.GetString(reader, "ImageLocation")
                        });
                    }

                    reader.Close();

                    return games;
                }
            }
        }
        public Game GetById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = GameQuery + " WHERE q.id = @Id";

                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    Game game = null;

                    while (reader.Read())
                    {
                        if (game == null)
                        {
                            game = new Game()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Title = DbUtils.GetString(reader, "Title"),
                                NumPlayers = DbUtils.GetString(reader, "NumPlayers"),
                                ImageLocation = DbUtils.GetString(reader, "ImageLocation"),
                                Genre_id = DbUtils.GetInt(reader, "Genre_id")
                            };
                        }
                    }

                    reader.Close();

                    return game;
                }
            }
        }
        public UserGame GetUserGameById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                          SELECT ug.Id as UserGameId, ug.UserProfile_id, ug.Game_id, 
                                 g.Id as GameId, g.Title, g.NumPlayers, g.ImageLocation, 
                                 up.Id as UserProfileId, up.UserName
                            FROM UserGame ug
                            Left JOIN UserProfile up on ug.UserProfile_id = up.Id
                            Left JOIN Game g on ug.Game_id = g.id
                        WHERE ug.Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();

                    UserGame userGame = null;

                    if (reader.Read())
                    {
                        userGame = new UserGame
                        {
                            Id = DbUtils.GetInt(reader, "UserGameId"),
                            UserProfile_id = DbUtils.GetInt(reader, "UserProfile_Id"),
                            UserProfile = new UserProfile
                            {
                                Id = DbUtils.GetInt(reader, "UserProfileId"),
                                UserName = DbUtils.GetString(reader, "UserName"),
                            },
                            Game_id = DbUtils.GetInt(reader, "Game_Id"),
                            Game = new Game
                            {
                                Id = DbUtils.GetInt(reader, "GameId"),
                                Title = DbUtils.GetString(reader, "Title"),
                                NumPlayers = DbUtils.GetString(reader, "NumPlayers"),
                                ImageLocation = DbUtils.GetString(reader, "ImageLocation")
                            }
                        };
                    }

                    reader.Close();

                    return userGame;
                }
            }
        }

        private string GameQuery
        {
            get
            {
                return @"
                          SELECT Id, Title, NumPlayers, ImageLocation, Genre_id
                            FROM Game
                        ORDER BY Title
                    ";
            }
        }
    }
}
