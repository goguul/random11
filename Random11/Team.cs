using System.Collections.Generic;
using Random11.Exceptions;
using System.Linq;
using Random11.Utilities;

namespace Random11
{
    public class Team
    {
        public List<Player> Players { get; set; }

        public double CreditsLeft { get; set; }

        public Team()
        {
            Players = new List<Player>();
            CreditsLeft = 100;
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
            if (CreditsLeft < player.Credits)
            {
                throw new CreditNotAvailableException("Credits not available");
            }
            CreditsLeft -= player.Credits;
        }

        public void AddPlayers(List<Player> players)
        {
            foreach (var player in players)
            {
                AddPlayer(player);
            }
        }

        public void RemovePlayer(Player player)
        {

        }

        public void SetCaptain(Player player)
        {
            Players.Where(x => x.Name == player.Name).First().Role = Role.Captain.ToString();
        }

        public void SetViceCaptain(Player player)
        {
            Players.Where(x => x.Name == player.Name).First().Role = Role.ViceCaptain.ToString();
        }
    }
}
