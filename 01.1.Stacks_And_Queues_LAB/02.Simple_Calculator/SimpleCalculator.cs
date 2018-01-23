/*
 * 02. Simple Calculator
 * 
 * Create a simple calculator that can evaluate simple expressions with only addition and subtraction. 
 * There will not be any parentheses.
 * Solve the problem using a Stack.
 * 
 * Example
 * Input:                Output:            Input:       Output:
 * 2 + 5 + 10 - 2 - 1    14                 2 - 2 + 5    5
 * 
 * Hints
 * •   Use a Stack<string>
 * •   You can either
 *   o   add the elements and then Pop() them out
 *   o   or Push() them and reverse the stack
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class MainClass
    {
        public static void Main()
        {
            string[] input = Console.ReadLine()
                                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();
            
            Array.Reverse(input);

            Stack<string> resultStack = new Stack<string>(input);

            while (resultStack.Count > 1)
            {
                int currentFirstNumber = int.Parse(resultStack.Pop());
                string currentOperator = resultStack.Pop();
                int currentSecondNumber = int.Parse(resultStack.Pop());

                if (currentOperator == "+")
                {
                    int currentResult = currentFirstNumber + currentSecondNumber;
                    resultStack.Push(currentResult.ToString());
                }
                else if (currentOperator == "-")
                {
                    int currentResult = currentFirstNumber - currentSecondNumber;
                    resultStack.Push(currentResult.ToString());
                }

            }

            Console.WriteLine(int.Parse(resultStack.Pop()));
        }
    }
}
