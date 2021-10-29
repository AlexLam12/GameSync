using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSync.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string NumPlayers { get; set; }
        public string ImageLocation { get; set; }
        public int Genre_id { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
