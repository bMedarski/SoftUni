using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Operations
{
    class Program
    {
        static void Main(string[] args)
        {

            double firstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());
            string operatorSign = Console.ReadLine();
            double result = 0;
            if (operatorSign == "+")
            {
                result = firstNum + secondNum;

                if (result % 2 == 0)
                {
                    Console.WriteLine("{0} + {1} = {2} - even", firstNum, secondNum, result);
                }
                else
                {
                    Console.WriteLine("{0} + {1} = {2} - odd", firstNum, secondNum, result);
                }
            }
            else if (operatorSign == "-")
            {
                result = firstNum - secondNum;
                if (result % 2 == 0)
                {
                    Console.WriteLine("{0} - {1} = {2} - even", firstNum, secondNum, result);
                }
                else
                {
                    Console.WriteLine("{0} - {1} = {2} - odd", firstNum, secondNum, result);
                }
            }
            else if (operatorSign == "*")
            {
                result = firstNum * secondNum;
                if (result % 2 == 0)
                {
                    Console.WriteLine("{0} * {1} = {2} - even", firstNum, secondNum, result);
                }
                else
                {
                    Console.WriteLine("{0} * {1} = {2} - odd", firstNum, secondNum, result);
                }
            }
            else if (operatorSign == "/")
            {
                if (secondNum == 0)
                {
                    Console.WriteLine("Cannot divide {0} by zero", firstNum);
                }
                else
                {
                    result = firstNum / secondNum;
                    Console.WriteLine("{0} / {1} = {2:F2}", firstNum, secondNum, result);
                }
            }

            else if (operatorSign == "%")
            {
                if (secondNum == 0)
                {
                    Console.WriteLine("Cannot divide {0} by zero", firstNum);
                }
                else
                {
                    result = firstNum % secondNum;
                    Console.WriteLine("{0} % {1} = {2}", firstNum, secondNum, result);
                }
            }
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace _17.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            var n1 = double.Parse(Console.ReadLine());
            var n2 = double.Parse(Console.ReadLine());
            string o = Console.ReadLine();

            if (o == "+")
            {
                var result = n1 + n2;
                if (result % 2 == 0)
                {
                    Console.WriteLine("{0} {1} {2} = {3} - even", n1, o, n2, result);
                }
                else
                {
                    Console.WriteLine("{0} + {1} = {2} - odd", n1, n2, result);
                }
            }
            else if (o == "-")
            {
                var result = n1 - n2;
                if (result % 2 == 0)
                {
                    Console.WriteLine("{0} - {1} = {2} - even", n1, n2, result);
                }
                else
                {
                    Console.WriteLine("{0} - {1} = {2} - odd", n1, n2, result);
                }
            }
            else if (o == "*")
            {
                var result = n1 * n2;
                if (result % 2 == 0)
                {
                    Console.WriteLine("{0} * {1} = {2} - even", n1, n2, result);
                }
                else
                {
                    Console.WriteLine("{0} * {1} = {2} - odd", n1, n2, result);
                }
            }
            else if (o == "/")
            {
                var result = n1 / n2;
                if (n2 != 0)
                {
                    Console.WriteLine("{0} / {1} = {2:F2}", n1, n2, result);
                }
                else
                {
                    Console.WriteLine("Cannot divide {0} by zero", n1);
                }
            }
            else if (o == "%")
            {
                var result = n1 % n2;
                if (n2 != 0)
                {
                    Console.WriteLine("{0} % {1} = {2}", n1, n2, result);
                }
                else
                {
                    Console.WriteLine("Cannot divide {0} by zero", n1);
                }
            }
        }
    }
}