using GameSync.Models;
using System.Collections.Generic;


namespace GameSync.Repositories
{
    public interface ICommentRepository
    {
        List<Comment> GetCommentsOnUserGame(int id);
        Comment GetCommentById(int id);
        void Add(Comment comment, int currentUser);
        void Update(Comment comment);
        void Delete(int id);
    }
}
