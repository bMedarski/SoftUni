using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match_Tickets
{
    class matchTickets
    {
        static void Main(string[] args)
        {

            double budjet = double.Parse(Console.ReadLine());
            string bilet = Console.ReadLine();
            int hora = int.Parse(Console.ReadLine());
            double biletBudjet = 0;
            if (hora<=4)
            {
                biletBudjet = budjet - budjet * 0.75;
            }
            else if (hora>4&&hora<=9)
            {
                biletBudjet = budjet - budjet * 0.60;
            }
            else if (hora > 9 && hora <= 24)
            {
                biletBudjet = budjet - budjet * 0.50;
            }
            else if (hora > 24 && hora <= 49)
            {
                biletBudjet = budjet - budjet * 0.40;
            }
            else if (hora>49)
            {
                biletBudjet = budjet - budjet * 0.25;
            }
            double ticketPrise = 0;
        
            if (bilet=="VIP")
            {
                ticketPrise = (499.99 * hora);
           

            }
            else
            {
                ticketPrise =(249.99 * hora);
                
            }
            //Console.WriteLine(ticketPrise);

            if (biletBudjet > ticketPrise)
            {
                Console.WriteLine("Yes! You have {0:F2} leva left.", (ticketPrise - biletBudjet)*-1);
            }
            else
            {
                Console.WriteLine("Not enough money! You need {0:F2} leva.",(biletBudjet- ticketPrise)*-1);
            }

        }
    }
}
