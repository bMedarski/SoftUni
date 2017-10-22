
using System.Text;
    class TimeLimitRace : Race
    {
        private int goldTime;
        public TimeLimitRace(int length, string route, int prizePool, int goldTime) : base(length, route, prizePool)
        {
            this.GoldTime = goldTime;
        }
        
        public int GoldTime
        {
            get { return this.goldTime; }
            private set { this.goldTime = value; }
        }

        public override void AddParticipiant(ICar car)
        {
            if (base.participants.Count==0)
            {
               base.AddParticipiant(car); 
            }            
        }

        public override string StartRace()
        {
            var st = new StringBuilder();
            st.AppendLine($"{this.Route} - {this.Length}");
            if (this.participants.Count == 0)
            {
                return "Cannot start the race with zero participants.";
            }
            var performance = (this.participants[0].Horsepower / 100) * this.participants[0].Acceleration * this.Length;
            st.AppendLine($"{this.participants[0].Brand} {this.participants[0].Model} - {performance} s.");
            if (performance <= this.GoldTime)
            {
                st.Append($"Gold Time, ${this.PrizePool}.");
            }
            else if(performance>this.GoldTime&&performance<=this.GoldTime+15)
            {
                st.Append($"Silver Time, ${this.PrizePool*0.5}.");
            }else if (performance>this.GoldTime+15)
            {
                st.Append($"Bronze Time, ${this.PrizePool * 0.3}.");
            }
            
            this.participants.Clear();
            return st.ToString();
        }
    }
