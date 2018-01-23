/*
 * 05. Calculate Sequence with Queue
 * 
 * We are given the following sequence of numbers:
 * •   S1 = N
 * •   S2 = S1 + 1
 * •   S3 = 2*S1 + 1
 * •   S4 = S1 + 2
 * •   S5 = S2 + 1
 * •   S6 = 2*S2 + 1
 * •   S7 = S2 + 2
 * •   S8 = S3 + 1
 * •   …
 * 
 * Using the Queue<T> class, write a program to print its first 50 members for given N.
 * 
 * Constraints:
 * •   -4000000000 ≤ N ≤ 2000000000
 * 
 * Example:
 * Input:       Output:
 * 2            2 3 5 4 4 7 5 6 11 7 5 9 6 …
 * 
 * Input:       Output:
 * -1           -1 0 -1 1 1 1 2 …
 * 
 * Input:       Output:
 * 1000         1000 1001 2001 1002 1002 2003 1003 …
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;

namespace Calculate_Sequence_with_Queue
{
    class MainClass
    {
        public static void Main()
        {
            long number = long.Parse(Console.ReadLine());

            Queue<long> numbers = new Queue<long>();
            Queue<long> result = new Queue<long>();

            numbers.Enqueue(number);

            while (result.Count != 50)
            {

                long firstResult = numbers.Peek() + 1;
                numbers.Enqueue(firstResult);

                long secondResult = (2 * numbers.Peek()) + 1;
                numbers.Enqueue(secondResult);

                long thirdResult = numbers.Peek() + 2;
                numbers.Enqueue(thirdResult);

                result.Enqueue(numbers.Dequeue());
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
