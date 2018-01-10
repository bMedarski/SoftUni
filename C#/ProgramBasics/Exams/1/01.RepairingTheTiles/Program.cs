using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RepairingTheTiles
{
    class Program
    {
        static void Main(string[] args)
        {

            int lenghtPloshtadka = int.Parse(Console.ReadLine());
            double widthPlochka = double.Parse(Console.ReadLine());
            double lengthPlochka = double.Parse(Console.ReadLine());
            int widthPeika = int.Parse(Console.ReadLine());
            int lengthPeika = int.Parse(Console.ReadLine());

            int ploshtPloshtadka = lenghtPloshtadka * lenghtPloshtadka;
            int ploshtPeika = widthPeika * lengthPeika;
            double ploshtPlochka = widthPlochka * lengthPlochka;
            double countPlochki = (ploshtPloshtadka - ploshtPeika) / ploshtPlochka;
            double vreme = countPlochki * 0.2;

            Console.WriteLine(countPlochki);
            Console.WriteLine(vreme);
        }
    }
}
