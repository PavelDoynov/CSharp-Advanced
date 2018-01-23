/*
 * 03. Maximum Element
 * 
 * You have an empty sequence, and you will be given N queries. Each query is one of these three types:
 * 1 x - Push the element x into the stack.
 * 2 - Delete the element present at the top of the stack.
 * 3 - Print the maximum element in the stack.
 * 
 * Input Format:
 * •   The first line of input contains an integer, N
 * •   The next N lines each contain an above-mentioned query. (It is guaranteed that each query is valid.)
 * 
 * Output Format:
 * •   For each type 3 query, print the maximum element in the stack on a new line
 * 
 * Constraints:
 * •   1 ≤ N ≤ 105
 * •   1 ≤ x ≤ 109
 * •   1 ≤ type ≤ 3
 * 
 * Example
 * Input:         Output:
 * 9              26
 * 1 97           91
 * 2
 * 1 20
 * 2
 * 1 26
 * 1 20
 * 3
 * 1 91
 * 3
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Linq;
using System.Collections.Generic;

namespace Maximum_Element
{
    class MainClass
    {
        public static void Main()
        {
            int counter = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();

            int currentNumber = 0;
            int maxNumber = 0;

            while (counter != 0)
            {
                int[] input = Console.ReadLine()
                                     .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToArray();

                if (input[0] == 1)
                {
                    numbers.Push(input[1]);
                    currentNumber = input[1];

                    if (currentNumber > maxNumber)
                    {
                        maxNumber = currentNumber;
                    }
                }
                else if (input[0] == 2)
                {
                    int deleteNumber = numbers.Pop();

                    if (deleteNumber == maxNumber)
                    {
                        maxNumber = numbers.Max();
                    }
                }
                else if (input[0] == 3)
                {
                    Console.WriteLine($"{maxNumber}");
                }

                counter--;
            }
        }
    }
}
