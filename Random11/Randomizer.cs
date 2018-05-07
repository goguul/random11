using Random11.Exceptions;
using Random11.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Random11
{
    public class Randomizer
    {
        private readonly List<Player> _players;
        private readonly IPlayingStrategy _playingStrategy;
        private int _retryCount = 5;

        public Randomizer(List<Player> players, IPlayingStrategy playingStrategy)
        {
            _players = players;
            _playingStrategy = playingStrategy;
        }

        public Team GenerateTeam()
        {
            var team = new Team();

            try
            {
                team.AddPlayers(_playingStrategy.GetPlayers(_players));
                team.SetCaptain(_playingStrategy.GetCaptain(team.Players));
                team.SetViceCaptain(_playingStrategy.GetViceCaptain(team.Players));

                if (team.Players.GroupBy(x => x.Team).Any(y => y.Count() > 7))
                {
                    throw new MaxPlayerExceededException("Max player exceeded from particular team");
                }
            }
            catch(Exception ex)
            {
                if (_retryCount == 0) throw ex;
                if (ex is MaxPlayerExceededException || ex is CreditNotAvailableException)
                {
                    GenerateTeam();
                    _retryCount--;
                }
            }

            return team;
        }
    }
}
