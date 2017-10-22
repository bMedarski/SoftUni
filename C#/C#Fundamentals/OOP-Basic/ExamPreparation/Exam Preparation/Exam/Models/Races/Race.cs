using System.Collections.Generic;
using System.Text;

    public abstract class Race : IRace
    {
        private int length;
        private string route;
        private int prizePool;
        protected List<ICar> participants;

        public Race(int length, string route, int prizePool)
        {
            this.Length = length;
            this.Route = route;
            this.PrizePool = prizePool;
            this.participants = new List<ICar>();
        }

        public int Length
        {
            get { return this.length; }
            set { this.length = value; }
        }

        public string Route
        {
            get { return this.route; }
            set { this.route = value; }
        }

        public int PrizePool
        {
            get { return this.prizePool; }
            set { this.prizePool = value; }
        }

        public virtual void AddParticipiant(ICar car)
        {
            this.participants.Add(car);
        }

        public virtual string StartRace()
        {
            return "";
        }

        public bool CheckForParticipiant(int id)
        {
            var currentCar = Data.cars[id];
            foreach (var car in this.participants)
            {
                if (car == currentCar)
                {
                    return true;
                }
            }
            return false;            
        }
        public override string ToString()
        {
            var st = new StringBuilder();
            st.AppendLine($"{this.Route} - {this.Length}");
            return st.ToString();
        }
    }


