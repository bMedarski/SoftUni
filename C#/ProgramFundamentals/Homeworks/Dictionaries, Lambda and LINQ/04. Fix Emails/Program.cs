using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            string email = "";           
            int count = 1;
            Dictionary<string, string> adresses = new Dictionary<string, string>();

            while (name != "stop")
            {
                if (count % 2 != 0)
                {
                    name = Console.ReadLine();
                }
                else
                {
                    email = Console.ReadLine();
                    if (CheckDonain(email))
                    {
                        adresses[name] = email;
                    }                  
                }
                count++;
            }
            foreach (var i in adresses)
            {
                Console.WriteLine($"{i.Key} -> {i.Value}");
            }

        }
        static bool CheckDonain(string email)
        {
            email.ToLower();
            char[] arr = email.ToCharArray(); //us uk
            Array.Reverse(arr);
            char first = arr[0];
            char second = arr[1];
            if (((first == 's')&&(second=='u'))||((first == 'k') && (second == 'u')))
            {
                return false;
            }else
            {
                return true;
            }
         
        }
    }
}
