/*
 * 08. Radioactive Mutant Vampire Bunnies
 * 
 * Browsing through GitHub, you come across an old JS Basics teamwork game. It is about very nasty bunnies that multiply
 * extremely fast. There’s also a player that has to escape from their lair. You really like the game so you decide to 
 * port it to C# because that’s your language of choice. The last thing that is left is the algorithm that decides if the 
 * player will escape the lair or not.
 * 
 * First, you will receive a line holding integers N and M, which represent the rows and columns in the lair. 
 * Then you receive N strings that can only consist of “.”, “B”, “P”. The bunnies are marked with “B”, the player is 
 * marked with “P”, and everything else is free space, marked with a dot “.”. 
 * They represent the initial state of the lair. There will be only one player. Then you will receive a string with 
 * commands such as LLRRUUDD – where each letter represents the next move of the player (Left, Right, Up, Down).
 * 
 * After each step of the player, each of the bunnies spread to the up, down, left and right 
 * (neighboring cells marked as “.” changes their value to B). If the player moves to a bunny cell or a bunny reaches the 
 * player, the player has died. If the player goes out of the lair without encountering a bunny, the player has won.
 * 
 * When the player dies or wins, the game ends. All the activities for this turn continue 
 * (e.g. all the bunnies spread normally), but there are no more turns. There will be no stalemates where the moves of 
 * the player end before he dies or escapes.
 * 
 * Finally, print the final state of the lair with every row on a separate line. On the last line, 
 * print either “dead: {row} {col}” or “won: {row} {col}”. Row and col are the coordinates of the cell where the player 
 * has died or the last cell he has been in before escaping the lair.
 * 
 * Input
 * •   On the first line of input, the numbers N and M are received – the number of rows and columns in the lair
 * •   On the next N lines, each row is received in the form of a string. 
 * The string will contain only “.”, “B”, “P”. All strings will be the same length. 
 * There will be only one “P” for all the input
 * •   On the last line, the directions are received in the form of a string, containing “R”, “L”, “U”, “D”
 * 
 * Output
 * •   On the first N lines, print the final state of the bunny lair
 * •   On the last line, print the outcome – “won:” or “dead:” + {row} {col}
 * 
 * Constraints
 * •   The dimensions of the lair are in range [3…20]
 * •   The directions string length is in range [1…20]
 * 
 * Example
 * Input:             Output:                Input:             Output:
 * 5 8                BBBBBBBB               4 5                .B...
 * .......B           BBBBBBBB               .....              BBB..
 * ...B....           BBBBBBBB               .....              BBBB.
 * ....B..B           .BBBBBBB               .B...              BBB..
 * ........           ..BBBBBB               ...P.              dead: 3 1 
 * ..P.....           won: 3 0               LLLLLLLL
 * ULLL
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Linq;
using System.Collections.Generic;

namespace Radioactive_Mutant_Vampire_Bunnies
{
    class MainClass
    {
        public static void Main()
        {
            char[,] bunniesMatrix = FillMatrix();

            Queue<char> playerMoveDirection = FillPlayerMoveDirection();

            int[] playerCoordinates = GetPlayerCoordinates(bunniesMatrix);

            bool isDead = false; // If player is dead/lose the game
            bool isWon = false;  // If player is won the game

            //--------------------------------The Logic--------------------------------------------
            //-------------------------------------------------------------------------------------
            while (playerMoveDirection.Count != 0)
            {
                char playerMoveOneStep = playerMoveDirection.Dequeue(); //We get the current direction to move the player
                int playerRowPosition = playerCoordinates[0];           //Player current row
                int playerColPosition = playerCoordinates[1];           //Player current col


                // We're starting to move the player with one step -------------------------------

                if (bunniesMatrix[playerRowPosition, playerColPosition] == 'P')
                {
                    if (playerMoveOneStep == 'U')
                    {
                        if (playerRowPosition == 0)
                        {
                            bunniesMatrix[playerRowPosition, playerColPosition] = '.';
                            isWon = true;
                        }
                        else
                        {
                            if (playerRowPosition - 1 >= 0 && bunniesMatrix[playerRowPosition - 1, playerColPosition] != 'B')
                            {
                                bunniesMatrix[playerRowPosition - 1, playerColPosition] = 'P';
                                bunniesMatrix[playerRowPosition, playerColPosition] = '.';
                                //playerRowPosition = playerRowPosition - 1;
                            }
                            else if (playerRowPosition - 1 >= 0 && bunniesMatrix[playerRowPosition - 1, playerColPosition] == 'B')
                            {
                                //playerRowPosition = playerRowPosition - 1;
                                isDead = true;
                            }
                            playerRowPosition--;
                        }
                    }
                    if (playerMoveOneStep == 'L')
                    {
                        if (playerColPosition == 0)
                        {
                            bunniesMatrix[playerRowPosition, playerColPosition] = '.';
                            isWon = true;
                        }
                        else
                        {
                            if (playerColPosition - 1 >= 0 && bunniesMatrix[playerRowPosition, playerColPosition - 1] != 'B')
                            {
                                bunniesMatrix[playerRowPosition, playerColPosition - 1] = 'P';
                                bunniesMatrix[playerRowPosition, playerColPosition] = '.';
                                //playerColPosition = playerColPosition - 1;
                            }
                            else if (playerColPosition - 1 >= 0 && bunniesMatrix[playerRowPosition, playerColPosition - 1] == 'B')
                            {
                                //playerColPosition = playerColPosition - 1;
                                isDead = true;
                            }
                            playerColPosition--;
                        }
                    }
                    if (playerMoveOneStep == 'D')
                    {
                        if (playerRowPosition == bunniesMatrix.GetLength(0) - 1)
                        {
                            bunniesMatrix[playerRowPosition, playerColPosition] = '.';
                            isWon = true;
                        }
                        else
                        {
                            if (playerRowPosition + 1 <= bunniesMatrix.GetLength(0) - 1
                                && bunniesMatrix[playerRowPosition + 1, playerColPosition] != 'B')
                            {
                                bunniesMatrix[playerRowPosition + 1, playerColPosition] = 'P';
                                bunniesMatrix[playerRowPosition, playerColPosition] = '.';
                                // playerRowPosition = playerRowPosition + 1;
                            }
                            else if (playerRowPosition + 1 <= bunniesMatrix.GetLength(0) - 1
                                && bunniesMatrix[playerRowPosition + 1, playerColPosition] == 'B')
                            {
                                //playerRowPosition = playerRowPosition + 1;
                                isDead = true;
                            }
                            playerRowPosition++;
                        }
                    }
                    if (playerMoveOneStep == 'R')
                    {
                        if (playerColPosition == bunniesMatrix.GetLength(1) - 1)
                        {
                            bunniesMatrix[playerRowPosition, playerColPosition] = '.';
                            isWon = true;
                        }
                        else
                        {
                            if (playerColPosition + 1 <= bunniesMatrix.GetLength(1) - 1
                                && bunniesMatrix[playerRowPosition, playerColPosition + 1] != 'B')
                            {
                                bunniesMatrix[playerRowPosition, playerColPosition + 1] = 'P';
                                bunniesMatrix[playerRowPosition, playerColPosition] = '.';
                                //playerColPosition = playerColPosition + 1;
                            }
                            else if (playerColPosition + 1 <= bunniesMatrix.GetLength(1) - 1
                                && bunniesMatrix[playerRowPosition, playerColPosition + 1] == 'B')
                            {
                                //playerColPosition = playerColPosition + 1;
                                isDead = true;
                            }
                            playerColPosition++;
                        }
                    }

                    playerCoordinates[0] = playerRowPosition; //We save the new player row coordinate
                    playerCoordinates[1] = playerColPosition; //We save the new player col coordinate
                }


                // We're starting to mutliply Bunnies ---------------------------------------------

                Stack<int[]> bunniesPositions = new Stack<int[]>(); /*We make a stack to save the bunnies multiply
                                                                      new positions */
                for (int row = 0; row < bunniesMatrix.GetLength(0); row++)
                {
                    for (int col = 0; col < bunniesMatrix.GetLength(1); col++)
                    {
                        if (bunniesMatrix[row, col] == 'B')
                        {
                            if (row - 1 >= 0 && bunniesMatrix[row - 1, col] == 'P')
                            {
                                int[] currentArrPos = { row - 1, col };
                                bunniesPositions.Push(currentArrPos);
                                isDead = true;
                            }
                            else if (row - 1 >= 0 && bunniesMatrix[row - 1, col] != 'B')
                            {
                                int[] currentArrPos = { row - 1, col };
                                bunniesPositions.Push(currentArrPos);
                                //isDead = true;
                            }
                            if (row + 1 <= bunniesMatrix.GetLength(0) - 1 && bunniesMatrix[row + 1, col] == 'P')
                            {
                                int[] currentArrPos = { row + 1, col };
                                bunniesPositions.Push(currentArrPos);
                                isDead = true;
                            }
                            else if (row + 1 <= bunniesMatrix.GetLength(0) - 1 && bunniesMatrix[row + 1, col] != 'B')
                            {
                                int[] currentArrPos = { row + 1, col };
                                bunniesPositions.Push(currentArrPos);
                                //isDead = true;
                            }
                            if (col - 1 >= 0 && bunniesMatrix[row, col - 1] == 'P')
                            {
                                int[] currentArrPos = { row, col - 1 };
                                bunniesPositions.Push(currentArrPos);
                                isDead = true;
                            }
                            else if (col - 1 >= 0 && bunniesMatrix[row, col - 1] != 'B')
                            {
                                int[] currentArrPos = { row, col - 1 };
                                bunniesPositions.Push(currentArrPos);
                                //isDead = true;
                            }
                            if (col + 1 <= bunniesMatrix.GetLength(1) - 1 && bunniesMatrix[row, col + 1] == 'P')
                            {
                                int[] currentArrPos = { row, col + 1 };
                                bunniesPositions.Push(currentArrPos);
                                isDead = true;
                            }
                            else if (col + 1 <= bunniesMatrix.GetLength(1) - 1 && bunniesMatrix[row, col + 1] != 'B')
                            {
                                int[] currentArrPos = { row, col + 1 };
                                bunniesPositions.Push(currentArrPos);
                                //isDead = true;
                            }
                        }
                    }
                }

                while (bunniesPositions.Count != 0) // We put the bunnies in new positions
                {
                    int[] currentPosition = bunniesPositions.Pop();

                    for (int row = 0; row < bunniesMatrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < bunniesMatrix.GetLength(1); col++)
                        {
                            if (row == currentPosition[0] && col == currentPosition[1])
                            {
                                bunniesMatrix[row, col] = 'B';
                            }
                        }
                    }
                }

                if (isDead || isWon) // If player is won, or lose the game we're quit the while loop
                {
                    break;
                }

            } // End of while loop ----------------------------------------------------------------


            //--------------------------------End Logic--------------------------------------------

            ViewMatrix(bunniesMatrix);

            if (isDead)
            {
                Console.WriteLine($"dead: {string.Join(" ", playerCoordinates)}");
            }
            else
            {
                Console.WriteLine($"won: {string.Join(" ", playerCoordinates)}");
            }
        }

        //-----------------------------Created Methods------------------------------------------

        private static int[] GetPlayerCoordinates(char[,] bunniesMatrix)
        {
            int[] currentCoordinates = new int[2];
            for (int row = 0; row < bunniesMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < bunniesMatrix.GetLength(1); col++)
                {
                    if (bunniesMatrix[row, col] == 'P')
                    {
                        currentCoordinates[0] = row;
                        currentCoordinates[1] = col;
                    }
                }
            }
            return currentCoordinates;
        }

        private static void ViewMatrix(char[,] bunniesMatrix)
        {
            for (int row = 0; row < bunniesMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < bunniesMatrix.GetLength(1); col++)
                {
                    Console.Write($"{bunniesMatrix[row, col]}");
                }
                Console.WriteLine();
            }
        }

        private static Queue<char> FillPlayerMoveDirection()
        {
            Queue<char> playerCoordinates = new Queue<char>();
            char[] inputCoordinates = Console.ReadLine().ToArray();
            for (int chars = 0; chars < inputCoordinates.Length; chars++)
            {
                playerCoordinates.Enqueue(inputCoordinates[chars]);
            }
            return playerCoordinates;
        }

        private static char[,] FillMatrix()
        {
            int[] matrixDimensions = Console.ReadLine()
                                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();

            char[,] matrix = new char[matrixDimensions[0], matrixDimensions[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            return matrix;
        }
    }
}
