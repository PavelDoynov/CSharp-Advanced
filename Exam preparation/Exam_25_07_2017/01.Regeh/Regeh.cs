/*
 * 01. Regeh
 * 
 * You need to read a line from the console and match everything that is in square brackets. 
 * However, there are some rules that you need to follow:
 * •   You must have no whitespaces inside the match.
 * •   Inside the match you must have [(ASCII Symbols)<(Some digits)REGEH(Some digits)>(ASCII Symbols)] 
 * •   If you have nested brackets you need to match the inner most.
 * 
 *                   [asdSd[asdasd<4REGEH23>asdUsd]
 * 
 * After you find a match you must extract the numbers between the “<”, “>” brackets. Then use this number like index to
 * get character from input. Every index is the sum of all previous indexes. When the index is larger than the string 
 * length start from the beginning of the string. Continue that process until you traverse the string enough times for the
 * index to fit.
 * 
 * Input
 * •   On the first line you will receive input that may contain any character.
 * 
 * Output
 * •   You must print on the console a single line with characters, that you find in the string.
 * 
 * Constraints
 * -   The line may contain any character
 * -   Line length will be 1 < n < 1000000
 * -   Time limit: 0.3 sec. Memory limit: 16 MB.
 * 
 * Example
 * Input:                                                                              Output:
 * [atdSd[asdasd<4REGEH22>asdosy]   ***oopprefs[ew<16REGEH30>rdtr]pppp555b             Soft
 * 
 * Input:                                                                              Output:
 * [aаdSd[asdasd<4REGEH22>asdosy]   ***oopprefs[ew<16REGEH30>rdtr]ppp555b              SoftUni!
 * [tU<1REGEH15>s]trneti!t[dsaf<3REGEH1>fdwss]
 * 
 * Input:                                                                              Output:
 * [atdSd[<4REGEH22>asdosy]   ***oopprefs[ew<16REGEH>rdtr]pppp555b
 * 
 * Input:                                                                              Output:
 * [atdSd[<422>asdosy]   ***oopprefs[ew<16REGEH>]pppp
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

namespace _01.Regeh
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            string pattern = @"\[[a-zA-Z]+<(\d+)REGEH(\d+)>[a-zA-Z]+]";
            Regex regex = new Regex(pattern);

            Queue<int> indexes = new Queue<int>();

            bool isMatch = regex.IsMatch(input);

            if (isMatch) 
            {
                MatchCollection matches = Regex.Matches(input, pattern);

                foreach (Match match in matches)
                {
                    indexes.Enqueue(int.Parse(match.Groups[1].ToString()));
                    indexes.Enqueue(int.Parse(match.Groups[2].ToString()));
                }
            }

            StringBuilder result = new StringBuilder();
            int currentIndex = 0;

            while (indexes.Count != 0)
            {
                currentIndex += indexes.Dequeue();

                char letter = input[currentIndex % input.Length];

                result.Append(letter);
            }

            Console.WriteLine(result);
        }
    }
}
