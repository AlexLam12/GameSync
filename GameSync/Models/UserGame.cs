using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSync.Models
{
    public class UserGame
    {
        public int Id { get; set; }
        public int UserProfile_id { get; set; }
        public int Game_id { get; set; }
    }
}
