using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSync.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserProfile_id { get; set; }
        public int UserGame_id { get; set; }
        public string Content { get; set; }
    }
}
