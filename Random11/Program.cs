using Newtonsoft.Json;
using Random11.Strategy;
using System;
using System.Collections.Generic;
using System.IO;

namespace Random11
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlayingStrategy strategy = GetPlayingStrategy();
            var players = GetPlayers();
            try
            {
                var team = new Randomizer(players, strategy).GenerateTeam();
                WriteOutput(team);
            }
            catch (Exception ex)
            {
                Console.WriteLine("System unable to generate team. Try with another set of players.");
                Console.ReadKey();
            }            
        }

        private static List<Player> GetPlayers()
        {
            List<Player> players;
            using (StreamReader r = new StreamReader("input.json"))
            {
                string json = r.ReadToEnd();
                players = JsonConvert.DeserializeObject<List<Player>>(json);
            }

            return players;
        }

        private static IPlayingStrategy GetPlayingStrategy()
        {
            Console.Write("Choose your strategy (A)Batting, (B)Bowling, (C)Neutral. Enter A, B or C. Press (E) for Exit.");
            IPlayingStrategy playingStrategy = new NeutralStrategy();
            var input = Console.ReadKey().KeyChar.ToString().ToUpper();
            playingStrategy = input == "A" ? new BattingStrategy() as IPlayingStrategy : new BowlingStrategy() as IPlayingStrategy;
            return playingStrategy;
        }

        private static void WriteOutput(Team team)
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("Name".PadRight(25, ' ') + "Category".PadRight(20, ' ') + "Team".PadRight(20, ' ') + "Role".PadRight(20, ' '));
            Console.WriteLine("----------------------------------------------------------------------------------");
            foreach (var player in team.Players)
            {
                Console.WriteLine($"{player.Name.PadRight(25, ' ')}{player.Category.ToString().PadRight(20, ' ')}{player.Team.PadRight(20, ' ')}{player.Role?.ToString().PadRight(20, ' ')}");
            }
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine($"Credits Left : {team.CreditsLeft}");
            Console.ReadKey();
        }
    }
}
