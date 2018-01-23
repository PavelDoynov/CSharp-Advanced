/*
 * 07. Balanced Parentheses
 * 
 * Given a sequence consisting of parentheses, determine whether the expression is balanced. A sequence of parentheses 
 * is balanced if every open parenthesis can be paired uniquely with a closed parenthesis that occurs after the former. 
 * Also, the interval between them must be balanced. You will be given three types of parentheses: (, {, and [.
 * 
 * {[()]} - This is a balanced parenthesis.
 * {[(])} - This is not a balanced parenthesis.
 * 
 * Input Format:
 * •   Each input consists of a single line, the sequence of parentheses.
 * 
 * Constraints:
 * •   1 ≤ lens ≤ 1000, where lens is the length of the sequence.
 * •   Each character of the sequence will be one of {, }, (, ), [, ].
 * 
 * Output Format:
 * •   For each test case, print on a new line "YES" if the parentheses are balanced. 
 * Otherwise, print "NO". Do not print the quotes.
 * 
 * Example:
 * Input:      Output:           Input:      Output:           Input:          Output:
 * {[()]}      YES               {[(])}      NO                {{[[(())]]}}    YES
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;

namespace Balanced_Parentheses
{
    class MainClass
    {
        public static void Main()
        {
            char[] inputParentheses = Console.ReadLine().ToCharArray();

            Stack<char> parenthesesStack = new Stack<char>();

            bool checker = true;

            if (inputParentheses.Length % 2 != 0) 
            {
                Console.WriteLine("NO");
                return;
            }

            for (int i = 0; i < inputParentheses.Length; i++)
            {
                if (inputParentheses[i] == '(' || inputParentheses[i] == '{' || inputParentheses[i] == '[')
                { 
                    parenthesesStack.Push(inputParentheses[i]);
                }
                else if (inputParentheses[i] == ')' || inputParentheses[i] == '}' || inputParentheses[i] == ']')
                {
                    char currentCharArray = inputParentheses[i];

                    switch (currentCharArray) 
                    {
                        case ')':
                            currentCharArray = '(';
                            break;

                        case '}':
                            currentCharArray = '{';
                            break;

                        case ']':
                            currentCharArray = '[';
                            break;

                        default:
                            break;
                    }

                    char currentCharStack = parenthesesStack.Pop();

                    if (currentCharArray != currentCharStack) 
                    {
                        checker = false;
                        break;
                    }
                }
            }

            if (checker) 
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
