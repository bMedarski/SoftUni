using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FootballTeamGen
{
    public class Player
    {
        //The stats a player has are endurance, sprint, dribble, passing and shooting. Each stat can be in the range [0..100]. 
        private string name;
        private decimal endurance;
        private decimal sprint;
        private decimal dribble;
        private decimal passing;
        private decimal shooting;

        public Player(string name, decimal endurance, decimal sprint, decimal dribble, decimal passing, decimal shooting)
        {
            this.Name = name;
            this.Dribble = dribble;
            this.Endurance = endurance;
            this.Passing = passing;
            this.Sprint = sprint;
            this.Shooting = shooting;
        }

        public string Name
        {
            get { return this.name; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                { this.name = value; }

            }
        }

        private decimal Endurance
        {
            get { return this.endurance; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Endurance should be between 0 and 100.");
                }
                this.endurance = value;
            }
        }

        private decimal Sprint
        {
            get { return this.sprint; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Sprint should be between 0 and 100.");
                }
                sprint = value;
            }
        }

        private decimal Dribble
        {
            get { return dribble; }
            set {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Dribble should be between 0 and 100.");
                }
                dribble = value; }
        }

        private decimal Passing
        {
            get { return passing; }
            set {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Passing should be between 0 and 100.");
                }
                passing = value; }
        }

        private decimal Shooting
        {
            get { return shooting; }
            set {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Shooting should be between 0 and 100.");
                }
                shooting = value; }
        }

        public decimal OverallStats()
        {
            decimal stats = 0;
            stats = Math.Round((Dribble + Endurance + Shooting + Sprint + Passing) / 5);
            return stats;
        }
    }
}
