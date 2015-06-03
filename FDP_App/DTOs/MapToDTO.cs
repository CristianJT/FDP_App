﻿using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace FDP_App.DTOs
{
    public class MapToDTO
    {
        public IEnumerable<LeaguesDTO> GetAllLeaguesAsDTO(IEnumerable<League> l)
        {
            var leagues = from x in l
                          select new LeaguesDTO(x);
            return leagues.AsEnumerable();
        }

        public LeaguesDetailDTO GetLeagueAsDTO(League l)
        {
            return new LeaguesDetailDTO(l);
        }

        public IEnumerable<TeamsDTO> GetAllTeamsAsDTO(IEnumerable<Team> t)
        {
            var teams = from x in t
                        select new TeamsDTO(x);
            return teams.AsEnumerable();
        }
    }
}