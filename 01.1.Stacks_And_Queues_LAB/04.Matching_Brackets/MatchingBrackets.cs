﻿/*
 * 04. Matching Brackets
 * 
 * We are given an arithmetic expression with brackets. Scan through the string and extract each sub-expression.
 * Print the result back at the terminal.
 * 
 * Example
 * Input:                                        Output:
 * 1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5           (2 + 3)
 *                                               (3 + 1)
 *                                               (2 - (2 + 3) * 4 / (3 + 1))
 * 
 * Input:                      Output:
 * (2 + 3) - (2 + 3)           (2 + 3)
 *                             (2 + 3)
 * 
 * Hints
 * •   Scan through the expression searching for brackets
 *   o   If you find an opening bracket, push the index into the stack
 *   o   If you find a closing bracket pop the topmost element from the stack. This is the index of the opening bracket.
 *   o   Use the current and the popped index to extract the sub-expression
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;

namespace Matching_Brackets
{
    class MainClass
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Stack<int> bracketStack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    bracketStack.Push(i);
                }
                else if (input[i] == ')')
                {
                    int startIndex = bracketStack.Pop();
                    int currentIndex = i + 1 - startIndex;

                    string currentText = input.Substring(startIndex, currentIndex);
                    Console.WriteLine(currentText);
                }
            }
        }
    }
}
