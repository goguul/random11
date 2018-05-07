using Random11.Extensions;
using Random11.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Random11.Strategy
{
    public class BowlingStrategy : StrategyBase, IPlayingStrategy
    {
        public List<Player> GetPlayers(List<Player> players)
        {
            var noOfBatsmen = 3;
            var noOfAllrounder = 2;
            var noOfBowlers = 5;
            return GetPlayers(players, noOfBatsmen, noOfAllrounder, noOfBowlers);
        }

        public Player GetCaptain(List<Player> players)
        {
            return players.Where(x => x.Category == Category.WicketKeeper
                                 || x.Category == Category.Bowler
                                 || x.Category == Category.AllRounder).RandomItem();
        }

        public Player GetViceCaptain(List<Player> players)
        {
            return players.Where(x => x.Category == Category.WicketKeeper
                                 || x.Category == Category.Bowler
                                 || x.Category == Category.AllRounder).RandomItem();
        }
    }
}
