using System.Collections.Generic;

namespace Random11.Strategy
{
    public interface IPlayingStrategy
    {
        List<Player> GetPlayers(List<Player> players);
        Player GetCaptain(List<Player> players);
        Player GetViceCaptain(List<Player> players);
    }
}
