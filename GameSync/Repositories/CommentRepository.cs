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
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(IConfiguration configuration) : base(configuration) { }
        public List<Comment> GetCommentsOnUserGame(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"Select  c.Id AS CommentId, 
		                                        c.UserGame_id,
		                                        c.UserProfile_id,
		                                        c.Content, 
                                                ug.Id as UserGameId,
                                                ug.Game_id,
                                                g.Id as GameId,
                                                g.Title,
                                                g.ImageLocation,
		                                        up.Id AS UserId,
		                                        up.UserName
                                        FROM Comment c
                                        JOIN UserProfile up ON up.Id = c.UserProfile_id
                                        JOIN UserGame ug ON ug.Id = c.UserGame_id
                                        JOIN Game g ON g.Id = ug.Game_id
                                        WHERE c.UserGame_id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Comment> comments = new List<Comment>();

                    while (reader.Read())
                    {
                        comments.Add(new Comment
                        {
                            Id = DbUtils.GetInt(reader, "CommentId"),
                            Content = DbUtils.GetString(reader, "Content"),
                            UserGame_id = DbUtils.GetInt(reader, "UserGame_id"),
                            UserGame = new UserGame
                            {
                                Id = DbUtils.GetInt(reader, "UserGameId"),
                                UserProfile_id = DbUtils.GetInt(reader, "UserProfile_Id"),
                                Game_id = DbUtils.GetInt(reader, "Game_Id"),
                                Game = new Game
                                {
                                    Id = DbUtils.GetInt(reader, "GameId"),
                                    Title = DbUtils.GetString(reader, "Title"),
                                    ImageLocation = DbUtils.GetString(reader, "ImageLocation")
                                }
                            },
                            UserProfile_id = DbUtils.GetInt(reader, "UserProfile_id"),
                            UserProfile = new UserProfile
                            {
                                Id = DbUtils.GetInt(reader, "UserId"),
                                UserName = DbUtils.GetString(reader, "UserName"),
                            }
                        });
                    }

                    reader.Close();
                    return comments;
                }
            }
        }
        public Comment GetCommentById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"Select  Id AS CommentId, 
		                                        UserGame_id,
		                                        UserProfile_id,
		                                        Content
                                        FROM Comment
                                        WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    Comment comment = null;

                    while (reader.Read())
                    {
                        comment = new Comment
                        {
                            Id = DbUtils.GetInt(reader, "CommentId"),
                            Content = DbUtils.GetString(reader, "Content"),
                            UserGame_id = DbUtils.GetInt(reader, "UserGame_id"),
                            UserProfile_id = DbUtils.GetInt(reader, "UserProfile_id"),

                        };
                    }

                    reader.Close();
                    return comment;
                }
            }
        }
        public void Add(Comment comment, int currentUser)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Comment (UserGame_id, 
					                                          UserProfile_id,
					                                          Content)
                                        OUTPUT INSERTED.ID
                                        VALUES			    (@UserGame_id,
					                                          @UserProfile_id,
					                                          @Content)";
                    cmd.Parameters.AddWithValue("@UserGame_id", comment.UserGame_id);
                    cmd.Parameters.AddWithValue("@UserProfile_id", currentUser);
                    cmd.Parameters.AddWithValue("@Content", comment.Content);

                    comment.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(Comment comment)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Comment SET
                                      Content = @content
                                      WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", comment.Id);
                    cmd.Parameters.AddWithValue("@Content", comment.Content);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Comment WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

