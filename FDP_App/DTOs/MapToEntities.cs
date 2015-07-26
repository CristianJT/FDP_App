using Entities.Models;
using System.Collections.Generic;

namespace FDP_App.DTOs
{
    public class MapToEntities
    {
        

        public void TeamDTOtoEntity(ref Team team, TeamsDTO teamDTO)
        {
            team.TeamId = teamDTO.TeamId;
            team.Name = teamDTO.Name;
            team.Stadium = teamDTO.Stadium;
            team.City = teamDTO.City;
            team.IsTopDivision = teamDTO.IsTopDivision;
        }
    }
}
