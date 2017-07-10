using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FootballTeamGen
{
    public class Team
    {
        private string name;
        private int rating;
        private IList<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.rating = 0;
            this.players = new List<Player>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)||string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("A name should not be empty. ");
                }
                { this.name = value; }

            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
            //Console.WriteLine(string.Join(", ",this.players));
        }

        public void RemovePlayer(Player player)
        {
            
            if (!this.players.Any(x => x.Name == player.Name))
            {
                
                throw new ArgumentException($"Player {player.Name} is not in {this.Name} team.");
                
            }
            else
            {
                
               this.players.Remove(player); 
            }
                ///Potencial problem
        }
        public decimal OverallTeamRating()
        {
            if (this.players.Count==0)
            {
                return 0;
            }
            return Math.Round(this.players.Select(x => x.OverallStats()).Sum() / this.players.Count);
        }
        

    }
}
