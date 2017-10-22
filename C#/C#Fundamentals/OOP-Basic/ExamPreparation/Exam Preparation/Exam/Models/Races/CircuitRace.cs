using System;
using System.Linq;
using System.Text;


    class CircuitRace : Race
    {
        private int laps;
        public CircuitRace(int length, string route, int prizePool, int laps) : base(length, route, prizePool)
        {
            this.Laps = laps;
        }

        public int Laps
        {
            get { return this.laps; }
            private set { this.laps = value; }
        }
        public override string StartRace()
        {
            var st = new StringBuilder();
            int winning = 0;
            int end = Math.Min(this.participants.Count, 4);
            int durabilityLost = this.Laps * 100;
            st.AppendLine($"{this.Route} - {this.Length*this.Laps}");
            if (this.participants.Count == 0)
            {
                return "Cannot start the race with zero participants.";
            }

            this.participants = this.participants.OrderByDescending(x => (x.Horsepower / x.Acceleration) + (x.Suspension + x.Durability)).ToList();
            for (int i = 1; i <= end; i++)
            {
                if (i == 1)
                {
                    winning = (int)(this.PrizePool * 0.4);
                }
                else if (i == 2)
                {
                    winning = (int)(this.PrizePool * 0.3);
                }
                else if (i == 3)
                {
                    winning = (int)(this.PrizePool * 0.2);
                }else if (i == 4)
                {
                    winning = (int)(this.PrizePool * 0.1);
                }
                st.Append($"{i}. {this.participants[i - 1].Brand} {this.participants[i - 1].Model} " +
                          $"{(this.participants[i - 1].Horsepower / this.participants[i - 1].Acceleration) + (this.participants[i - 1].Suspension + this.participants[i - 1].Durability- durabilityLost)}PP - ${winning}");
                if (i < end)
                {
                    st.AppendLine();
                }
            }
            foreach (var car in this.participants)
            {
                car.Durability -= durabilityLost;
            }
            this.participants.Clear();
            return st.ToString();
        }
    }

