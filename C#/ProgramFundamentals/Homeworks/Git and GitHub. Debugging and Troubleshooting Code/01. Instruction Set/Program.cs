using System;
using System.Numerics;

class InstructionSet_broken
{
    static void Main()
    {
        string opCode = "";
        BigInteger result = 0;
        while (opCode != "END")
        {
            
            string[] codeArgs = opCode.Split(' ');

            
            switch (codeArgs[0])
            {
                case "INC":
                    {
                        int operandOne = int.Parse(codeArgs[1]);
                        result = (long)operandOne+1;
                        Console.WriteLine(result);
                        break;
                    }
                case "DEC":
                    {
                        int operandOne = int.Parse(codeArgs[1]);
                        result = (long)operandOne-1;
                        Console.WriteLine(result);
                        break;
                    }
                case "ADD":
                    {
                        int operandOne = int.Parse(codeArgs[1]);
                        int operandTwo = int.Parse(codeArgs[2]);
                        result = (long)operandOne + operandTwo;
                        Console.WriteLine(result);
                        break;
                    }
                case "MLA":
                    {
                        int operandOne = int.Parse(codeArgs[1]);
                        int operandTwo = int.Parse(codeArgs[2]);
                        result = (BigInteger)operandOne * operandTwo;
                        Console.WriteLine(result);
                        break;
                    }
                default:
                    {
                        
                        break;
                    }
                   
            }
           
            opCode = Console.ReadLine();

        }
        
    }
}