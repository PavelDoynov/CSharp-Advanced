/*
 * 04. Hit List
 * 
 * One final task for Sam before he gets to go home... Data mining!
 * Sam will receive info about one or several people in the format 
 * •   “{name}={key}:{value};{key}:{value};…”.
 * 
 * The goal here is to group the info for every person by their name. If a key is received multiple times, keep only
 * the most recent value.
 * On the last line, you will receive “Kill {name}”. Your task is to find all the info on that name and print it, 
 * ordered alphabetically by key.
 * Then, Sam needs to build a so-called info index on them. The info index is comprised of the sum of all the keys’ lengths
 * and values’ lengths of that person’s info.
 * If the info index is larger or equal to the target info index (given on the first line of input), print “Proceed”. 
 * Otherwise, print “Need {infoNeeded} more info.“.
 * 
 * Input
 * •   On the first line, you will receive the target info index, an integer in the range [25-90]
 * •   Until you receive the text “end transmissions”, keep reading new lines with information.
 * •   On the final line, you will receive “Kill {name}”
 * 
 * Output
 * •   On the first line, print “Info on {name}:”.
 * •   On the next lines, print “---{info}: {value}”
 * •   On the next line, print “Info index: {infoIndex}” with the info index of the selected person.
 * •   On the final line, print either “Proceed” or “Need {infoNeeded} more info.”, depending on whether the info is 
 * enough to carry out the hit or not.
 * 
 * Constraints
 * •   There will always be at least one name in the input.
 * •   Each name will always have one or several key/value pairs associated with it.
 * 
 * Example
 * Input:                           Output:
 * 30                               Info on Kobin:
 * Kobin=age:20;salary:700          ---age: 20
 * Grimsdottir=salary:5000          ---education: High School
 * Kobin=education:High School      ---salary: 700
 * end transmissions                Info index: 34
 * Kill Kobin                       Proceed
 * 
 * Input:                           Output;
 * 20                               Info on Lambert:
 * Lambert=age:57;salary:7000       ---age: 57
 * Grimsdottir=salary:5000          ---salary: 7000
 * John=salary:1550                 Info index: 15
 * John=lastName:Smith              Need 5 more info.
 * John=salary:1800
 * Kobin=education:High School
 * end transmissions
 * Kill Lambert
 * 
 * Input:                                Output:
 * 25                                    Info on Bill:
 * Bill=salary:900;lastName:Billov       ---lastName: Billov
 * Kobin=salary:1300                     ---salary: 900
 * Kobin=education:High School           Info index: 23
 * end transmissions                     Need 2 more info.
 * Kill Bill
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace HitList
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, List<string[]>> data = new Dictionary<string, List<string[]>>();

            int infoIndex = int.Parse(Console.ReadLine());

            string command;

            while ((command = Console.ReadLine()) != "end transmissions")
            {
                string[] args = command
                    .Split(new string[] { "=", ";" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = args[0];

                for (int keyValueArgs = 1; keyValueArgs < args.Length; keyValueArgs++)
                {
                    string[] currentArgs = args[keyValueArgs]
                        .Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string[] info = new string[] { currentArgs[0], currentArgs[1] };

                    if (!data.ContainsKey(name))
                    {
                        data[name] = new List<string[]>();
                        data[name].Add(info);
                    }
                    else
                    {
                        data[name].Add(info);
                    }
                }
            }

            string[] killCommand = Console.ReadLine()
                                          .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                          .ToArray();
            
            int infoCounter = 0;

            if (data.ContainsKey(killCommand[1]))
            {
                Console.WriteLine($"Info on {killCommand[1]}:");

                foreach (var name in data) 
                {
                    if (name.Key == killCommand[1]) 
                    {
                        foreach (var info in name.Value.OrderBy(x => x[0]))
                        {
                            infoCounter += info[0].Length + info[1].Length;
                                
                            Console.WriteLine($"---{info[0]}: {info[1]}");
                        }
                    }
                }

                Console.WriteLine($"Info index: {infoCounter}");

                if (infoCounter >= infoIndex)
                {
                    Console.WriteLine("Proceed");
                }
                else
                {
                    Console.WriteLine($"Need {infoIndex - infoCounter} more info.");
                }
            }
        }
    }
}
