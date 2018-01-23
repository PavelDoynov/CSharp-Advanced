/*
 * 03. Decimal to Binary Converter
 * 
 * Create a simple program that can convert a decimal number to its binary representation. Implement an elegant solution
 * using a Stack.
 * Print the binary representation back at the terminal.
 * 
 * Example
 * Input:     Output:          Input:     Output:
 * 10         1010             1024       10000000000
 * 
 * Hints
 * •   If the given number is 0, just print 0
 * •   Else, while the number is greater than zero, divide it by 2 and push the remainder into the stack
 * •   When you are done dividing, pop all remainders from the stack – that is the binary representation
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;

namespace Decimal_to_Binary_Converter
{
    class MainClass
    {
        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            if (input != 0)
            {
                Stack<bool> binary = new Stack<bool>();

                while (input != 0)
                {
                    int result = input % 2;
                    input /= 2;

                    if (result == 0)
                    {
                        binary.Push(false);
                    }
                    else if (result == 1)
                    {
                        binary.Push(true);
                    }
                }

                while (binary.Count != 0)
                {
                    bool trueFalse = binary.Pop();

                    if (trueFalse)
                    {
                        Console.Write("1");
                    }
                    else
                    {
                        Console.Write("0");
                    }
                }
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
