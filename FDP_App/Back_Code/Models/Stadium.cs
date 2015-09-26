﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FDP
{
    public class Stadium
    {
        public Stadium()
        {
            Matches = new HashSet<Match>();
        }

        public int Id { get; set; }
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int? Size { get; set; }

        public virtual Team Team { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}
