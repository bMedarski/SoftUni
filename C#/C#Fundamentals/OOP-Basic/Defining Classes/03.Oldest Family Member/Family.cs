using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Oldest_Family_Member
{
    public class Family
    {
        private List<Person> familyMembers = new List<Person>();

        public void AddMember(Person member)
        {
            familyMembers.Add(member);
        }

        public void GetOldestMember()
        {
            var oldest = familyMembers.OrderByDescending(x => x.Age).First();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}
