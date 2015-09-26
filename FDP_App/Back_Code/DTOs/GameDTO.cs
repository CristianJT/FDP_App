namespace App.FDP
{
    public class GameDTO
    {
        public int id { get; set; }
        public int torneo_id { get; set; }
        public int fecha_numero { get; set; }
        public bool? es_fecha_especial { get; set; }
        public GameState? estado { get; set; }

        public GameDTO()
        {

        }

        public GameDTO(Game g)
        {
            id = g.Id;
            torneo_id = g.LeagueId;
            fecha_numero = g.GameNumber;

            if (g.IsSpecialGame.HasValue)
            {
                es_fecha_especial = g.IsSpecialGame;
            }

            if (g.State.HasValue)
            {
                estado = g.State;
            }
        }
    }
}
