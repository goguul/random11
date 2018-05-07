using Random11.Extensions;
using System.Collections.Generic;

namespace Random11.Strategy
{
    public class NeutralStrategy : StrategyBase, IPlayingStrategy
    {
        public List<Player> GetPlayers(List<Player> players)
        {
            var noOfBatsmen = 4;
            var noOfAllrounder = 2;
            var noOfBowlers = 4;
            return GetPlayers(players, noOfBatsmen, noOfAllrounder, noOfBowlers);
        }

        public Player GetCaptain(List<Player> players)
        {
            return players.RandomItem();
        }

        public Player GetViceCaptain(List<Player> players)
        {
            return players.RandomItem();
        }
    }
}
