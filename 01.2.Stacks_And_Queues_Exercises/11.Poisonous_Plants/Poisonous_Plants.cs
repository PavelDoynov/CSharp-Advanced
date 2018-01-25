/*
 * 11. Poisonous Plants
 * 
 * You are given N plants in a garden. Each of these plants has been added with some amount of pesticide.
 * After each day, if any plant has more pesticide than the plant at its left, being weaker (more GMO) than the left one, 
 * it dies. You are given the initial values of the amount of pesticide and the position of each plant. 
 * Print the number of days after which no plant dies, i.e. the time after which there are no plants with more pesticide
 * content than the plant to their left.
 * 
 * Input Format:
 * •   The input consists of an integer N representing the number of plants
 * •   The next single line consists of N integers where every integer represents the position and the amount of 
 * pesticides of each plant
 * 
 * Output Format:
 * •   Output a single value equal to the number of days after which no plants die
 * 
 * Constraints:
 * •   1 ≤ N ≤ 100000
 * •   Pesticides amount on a plant is between 0 and 1000000000
 * 
 * Example
 * Input:               Output:
 * 7                    2
 * 6 5 8 4 7 10 9
 * 
 * Explanation
 * Initially all plants are alive. 
 * Plants = {(6,1), (5,2), (8,3), (4,4), (7,5), (10,6), (9,7)}.
 * Plants[k] = (i,j) => jth plant has pesticide amount = i.
 * After the 1st day, 4 plants remain as plants 3, 5, and 6 die.
 * Plants = {(6,1), (5,2), (4,4), (9,7)}.
 * After the 2nd day, 3 plants survive as plant 7 dies. Plants = {(6,1), (5,2), (4,4)}.
 * After the 3rd day, 3 plants survive and no more plants die.
 * Plants = {(6,1), (5,2), (4,4)}.
 * After the 2nd day the plants stop dying.
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace Poisonous_Plants
{
    class MainClass
    {
        public static void Main()
        {
            int plantsNumber = int.Parse(Console.ReadLine());

            int[] plants = Console.ReadLine()
                                  .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToArray();

            int[] days = new int[plantsNumber];

            Stack<int> indexes = new Stack<int>();
            indexes.Push(0);

            for (int i = 1; i < plants.Length; i++)
            {
                int maxDays = 0;

                while (indexes.Count > 0 && plants[indexes.Peek()] >= plants[i])
                {
                    maxDays = Math.Max(maxDays, days[indexes.Pop()]);
                }

                if (indexes.Count > 0)
                {
                    days[i] = maxDays + 1;
                }

                indexes.Push(i);
            }

            Console.WriteLine(days.Max());
        }
    }
}
