/*
 * 04. Add VAT
 * 
 * Write a program that reads one line of double prices separated by ", ". Print the prices with added VAT for all of them.
 * Format them to 2 signs after the decimal point. The order of the prices must be the same.
 * VAT is equal to 20% of the price.
 * 
 * Example
 * Input:              Output:         Input:          Output:
 * 1.38, 2.56, 4.4     1.66            1, 3, 5, 7      1.20
 *                     3.07                            3.60
 *                     5.28                            6.00
 *                                                     8.40
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Linq;

namespace _04.Add_VAT
{
    class Program
    {
        static void Main()
        {
            Console.ReadLine()
                   .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(num => double.Parse(num) * 0.2 + double.Parse(num))
                   .ToList()
                   .ForEach(num => Console.WriteLine($"{num:f2}"));
        }
    }
}
