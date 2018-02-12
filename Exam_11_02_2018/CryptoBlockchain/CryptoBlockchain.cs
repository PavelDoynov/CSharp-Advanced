/*
 * 03. Crypto Blockchain
 * 
 * The next task for our hero Sam is to hack the main top-secret facility server, used to manage all of Nikoladze’s social 
 * media. He’s already reached the server, and now it’s time to decrypt the information on it to see if it’s valuable or not.
 * Luckily, you’re Sam’s top unpaid intern, and he has tasked you with figuring out the algorithm to decrypting the data.
 * 
 * So, plug in some headphones and put on some hacker music. It’s time to decrypt the Crypto Blockchain.
 * The Crypto Blockchain is a special sequence of characters, which is comprised of several lines. 
 * Each line is always 16 characters long. Inside these lines, there are several Crypto Blocks and some garbage data 
 * around them. Here’s what a sample Crypto Blockchain looks like:
 * 
 * OktJULP\{FT*n*uk
 * _123120137130v}M
 * OoHw_[1291201341
 * 34r`wkR]00000000
 * 
 * The first step is to condense the Crypto Blockchain into one line.
 * The next step is to search for special substrings inside it, called Crypto Blocks. Each valid Crypto Block has the 
 * following characteristics:
 * •   It’s enclosed in either brackets {} or square brackets [].
 *   o   If it contains mixed opening/closing brackets (such as {] or [}, ignore that Crypto Block entirely)
 * •   It contains any printable ASCII character inside it
 * •   It contains at least three digits in a row.
 *   o   If the number of digits it contains cannot be split into threes (e.g. 8 digits), ignore the Crypto Block.
 * 
 * We’re looking for the digits inside each Crypto Block, which are actually encoded ASCII characters. Each character is 
 * represented by 3 digits (converted to a number), and the sequence of digits can be split into threes to figure out the 
 * sequence of characters present in that crypto block.
 * 
 * Once we find the digits in one crypto block, we split them into threes and convert them to a string of characters by 
 * subtracting the length of the entire crypto block from each number individually.
 * The final step is performing this algorithm over all the crypto blocks individually and concatenating the result.
 * 
 * Input
 * •   On the first line of input, you will receive n – the number of rows the room will consist of
 * •   On the next n lines, you will receive the Crypto Blockchain, a sequence of 16 characters.
 * 
 * Output
 * •   Print the decrypted and concatenated text.
 * 
 * Constraints
 * •   Crypto blocks will always contain zero or one sequence of numbers.
 * •   There will always be a valid crypto block in each crypto blockchain.
 * 
 * Example
 * Input:              Output:         Comments:
 * 4                   darkness        Block 1: {FT*n*uk_123120137130v}
 * OktJULP\{FT*n*uk                    Numbers: 123, 120, 137, 130. Crypto Block Length: 23
 * _123120137130v}M                    Subtracted ASCII codes: 100, 97, 114, 107 ⇒ dark
 * OoHw_[1291201341
 * 34r`wkR]00000000                    Block 2: [129120134134r`wkR]
 *                                     Numbers: 129, 120, 134, 134. Crypto Block Length: 19
 *                                     Subtracted ASCII codes: 110, 101, 115, 115 ⇒ ness
 * 
 * 
 * Input:              Output:               Comments:
 * 7                   Psst, over here!      Block 1: [>K.l ~T117152152153081069148155138z]
 * [>K.l ~T11715215                          Numbers: 117, 152, 152, 153, … Crypto Block Length: 37
 * 2153081069148155                          Subtracted ASCII codes: 80, 115, 115, 116, … ⇒ Psst, ove
 * 138z]#YQej@<+;|[
 * 1370551271241371                          Block 2: [137055127124137124056]
 * 24056]aG\'#|J q{                          Numbers: 137, 55, 127, 124, … Crypto Block Length: 23
 * L|y!111632]!u<@:                          Subtracted ASCII codes: 114, 32, 104, 101, … ⇒ r here!
 * <-&D000000000000
 *                                           Block 3: {L|y!111632]
 *                                           Brackets are different ⇒ ignore
 * 
 * 
 * Input:              Output:                 Comments:
 * 4                   Look what >I< found     Block 1: [099134134130055142127]
 * [099134134130055                            Numbers: 99, 134, 134, 130, … Crypto Block Length: 23
 * 142127]{12614506                            Subtracted ASCII codes: 76, 111, 111, 107, … ⇒ Look wh
 * 1091102089061131
 * 140}[128121111]0                            Block 2: {126145061091102089061131140
 *                                             Numbers: 126, 145, 61, 91, … Crypto Block Length: 29
 *                                             Subtracted ASCII codes: 97, 116, 32, 62, … ⇒ at >I< fo
 * 
 *                                             Block 3: [128121111
 *                                             Numbers: 128, 121, 111. Crypto Block Length: 11
 *                                             Subtracted ASCII codes: 117, 110, 100, … ⇒ und
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace CryptoBlockchain
{
    class Program
    {
        static void Main()
        {
            StringBuilder input = new StringBuilder();

            int numberOfInput = int.Parse(Console.ReadLine());

            while (numberOfInput != 0)
            {
                input.Append(Console.ReadLine());

                numberOfInput--;
            }

            string code = input.ToString();

            string pattern = @"{\D*(\d+)\D*}|\[\D*(\d+)\D*]";
            Regex regex = new Regex(pattern);
            MatchCollection match = Regex.Matches(code, pattern);

            List<char> chars = new List<char>();

            foreach (Match item in match)
            {
                int currentMatchCount = item.ToString().Length;

                string numbers;
                if (item.Groups[1].Length > 0 && item.Groups[2].Length == 0)
                {
                    numbers = item.Groups[1].ToString();
                }
                else
                {
                    numbers = item.Groups[2].ToString();
                }

                for (int i = 0; i <= numbers.Length - 2; i += 3) 
                {
                    string number = $"{numbers[i]}{numbers[i + 1]}{numbers[i + 2]}";
                    int asciiChar = int.Parse(number) - currentMatchCount;
                    chars.Add((char)asciiChar);       
                }
            }

            Console.WriteLine(string.Join("", chars));
        }
    }
}
