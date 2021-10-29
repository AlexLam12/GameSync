using GameSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
