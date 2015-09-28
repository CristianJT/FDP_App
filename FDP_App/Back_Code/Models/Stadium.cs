using System.Collections.Generic;

namespace App.FDP
{
    public class Stadium
    {
        public Stadium()
        {
            Matches = new HashSet<Match>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int? Size { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
    }
}
