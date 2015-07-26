using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Fixture
    {
        public Fixture()
        {
            this.SpecialGame = 0;
            this.Games = new HashSet<Game>();
        }

        [Key, ForeignKey("League")]
        public int LeagueId { get; set; }
        public int TotalGames { get; set; }
        public int SpecialGame { get; set; }

        public virtual League League { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
