using Random11.Extensions;
using Random11.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Random11.Strategy
{
    public abstract class StrategyBase
    {
        protected List<Player> GetPlayers(List<Player> players, int noOfBatsmen, int noOfAllrounder, int noOfBowlers)
        {
            var result = new List<Player>();

            var wicketKeeper = players.Where(x => x.Category == Category.WicketKeeper).RandomItem();
            result.Add(wicketKeeper);

            var batsmens = players.Where(x => x.Category == Category.Batsman).RandomItems(noOfBatsmen);
            result.AddRange(batsmens);

            var allrounders = players.Where(x => x.Category == Category.AllRounder).RandomItems(noOfAllrounder);
            result.AddRange(allrounders);

            var bowlers = players.Where(x => x.Category == Category.Bowler).RandomItems(noOfBowlers);
            result.AddRange(bowlers);
            return result;
        }
    }
}
