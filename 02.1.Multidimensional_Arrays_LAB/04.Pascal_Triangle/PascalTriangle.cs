/*
 * 04. Pascal Triangle
 * 
 * The triangle may be constructed in the following manner: In row 0 (the topmost row), there is a unique nonzero entry 1. 
 * Each entry of each subsequent row is constructed by adding the number above and to the left with
 * the number above and to the right, treating blank entries as 0. For example, the initial number in the 
 * first (or any other) row is 1 (the sum of 0 and 1), whereas the numbers 1 and 3 in the third row are added to produce 
 * the number 4 in the fourth row.
 * If you want more info about it: https://en.wikipedia.org/wiki/Pascal's_triangle
 * Print each row elements separated with whitespace.
 * 
 * Example
 * Input:       Output:                                                 Input:       Output:                          
 * 13           1                                                       4            1
 *              1 1                                                                  1 1
 *              1 2 1                                                                1 2 1
 *              1 3 3 1                                                              1 3 3 1
 *              1 4 6 4 1 
 *              1 5 10 10 5 1 
 *              1 6 15 20 15 6 1 
 *              1 7 21 35 35 21 7 1 
 *              1 8 28 56 70 56 28 8 1  
 *              1 9 36 84 126 126 84 36 9 1 
 *              1 10 45 120 210 252 210 120 45 10 1 
 *              1 11 55 165 330 462 462 330 165 55 11 1 
 *              1 12 66 220 495 792 924 792 495 220 66 12 1
 * 
 * Hints
 * •   The input number n will be 1 <= n <= 60
 * •   Think about proper type for elements in array
 * •   Don’t be scary to use more and more arrays
 * 
 * https://github.com/PavelDoynov
 */


using System;

namespace Pascal_Triangle
{
    class MainClass
    {
        public static void Main()
        {
            int height = int.Parse(Console.ReadLine());

            long[][] jaggedArray = new long[height][];
            int arrLenght = 1;

            for (int arr = 0; arr < jaggedArray.Length; arr++)
            {
                jaggedArray[arr] = new long[arrLenght];
                arrLenght++;

                int lastIndex = jaggedArray[arr].Length - 1;
                jaggedArray[arr][0] = 1;
                jaggedArray[arr][lastIndex] = 1;

                if (jaggedArray[arr].Length > 2)
                { 
                    for (int currentIndex = 1; currentIndex < jaggedArray[arr].Length - 1; currentIndex++)
                    {
                        jaggedArray[arr][currentIndex] = jaggedArray[arr - 1][currentIndex - 1] + 
                            jaggedArray[arr - 1][currentIndex]; 
                    }
                }
            }

            foreach (var arr in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
