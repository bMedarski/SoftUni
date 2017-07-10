using System;
using System.Linq;
using System.Text;

namespace Exam.Models.Races
{
    public class DragRace : Race
    {
        public DragRace(int length, string route, int prizePool) : base(length, route, prizePool)
        {
        }
        public override string StartRace()
        {
            var st = new StringBuilder();
            int winning = 0;
            int end = Math.Min(this.participants.Count, 3);
            st.AppendLine($"{this.Route} - {this.Length}");
            if (this.participants.Count == 0)
            {
                return "Cannot start the race with zero participants.";
            }
            
            this.participants = this.participants.OrderByDescending(x => (x.Horsepower / x.Acceleration)).ToList();
            for (int i = 1; i <= end; i++)
            {
                if (i == 1)
                {
                    winning = (int)(this.PrizePool * 0.5);
                }
                else if (i == 2)
                {
                    winning = (int)(this.PrizePool * 0.3);
                }
                else if (i == 3)
                {
                    winning = (int)(this.PrizePool * 0.2);
                    
                }
                st.Append($"{i}. {this.participants[i-1].Brand} {this.participants[i-1].Model} " +
                          $"{this.participants[i-1].Horsepower/this.participants[i-1].Acceleration}PP - ${winning}");
                if (i < end)
                {
                    st.AppendLine();
                }                
            }
            this.participants.Clear();
            return st.ToString();
        }
    }
}
