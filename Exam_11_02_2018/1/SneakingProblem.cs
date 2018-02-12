/*
 * 02. Sneaking
 * 
 * After our hero Sam got the recipe from the first problem, there is another thing he needs to check off from his to-do 
 * list. In order to make the recipe even more valuable, he needs to “eliminate” anyone who possesses the knowledge of it.
 * That person is Sam’s sworn enemy - Nikoladze. Sam needs to get through a rectangular room of patrolling enemies until 
 * he finally reaches Nikoladze.
 * 
 * A standard room looks like this:
 *   Room            Legent
 *   ......N...      S ⇒ Sam, the player character
 *   b.........      b/d ⇒ left/right-facing patrolling enemy
 *   ..d.......      N ⇒ Nikoladze
 *   ......d...      . ⇒ Empty space
 *   .....S....
 * 
 * Each turn proceeds as follows:
 * •   First, Enemies move either left or right, depending on which direction they are facing (b goes right, d goes left)
 *   o   If an enemy is standing on the edge of the room, he flips his direction (from d to b or from b to d) 
 *       and doesn’t move for the rest of the turn.
 * •   If an enemy is on the same row as Sam, and also facing Sam (eg. .b.S.), the enemy kills Sam.
 * •   After that, Sam moves in the direction he is instructed to (either U/D/L/R or W).
 *   o   U -> Up, D -> Down, L -> Left, R -> Right, W -> Wait (Sam doesn’t move)
 * •   If Sam moves onto an enemy (same row and column), Sam kills the enemy and leaves no trace of him.
 * •   If Sam is reaches the same row as Nikoladze, Sam kills Nikoladze (replacing him with an X)
 * 
 * Input
 * •   On the first line of input, you will receive n – the number of rows the room will consist of. Range: [2-20]
 * •   On the next n lines, you will receive the room, which Sam will have to navigate.
 * •   On the final line of input, you will receive a sequence of directions – one of (U, D, L, R, W)
 * 
 * Output
 * •   If Sam is killed, print “Sam died at {row}, {col}”
 * •   If Nikoladze is killed, print “Nikoladze killed!”
 * •   Then, in both cases, print the final state of the room on the console, with either Sam or Nikoladze’s symbols
 * replaced by an X.
 * 
 * Constraints
 * •   The room will always be rectangular.
 * •   There will always be enough moves for Sam to reach Nikoladze
 * •   There will be no case where Sam is instructed to move out of the bounds of the room.
 * •   There will be no case with two enemies on the same row.
 * •   There will be no case with an enemy and Nikoladze standing on the same row.
 * •   There will be no case where Sam reaches the same row and column as Nikoladze.
 * 
 * Example
 *  Input:          Output:                Comments:
 *  5               Sam died at 2, 5       Turn 1: Enemies move, then Sam steps on the enemy on the 4th row.
 *  ......N...      ......N...             Turn 2: Enemies move, then Sam moves.
 *  b.........      ...b......             Turn 3: Enemy 2 turns around, Sam goes on the same row as him.
 *  ..d.......      b....X....             Turn 4: Enemy sees Sam and kills him.
 *  ......d...      ..........
 *  .....S....      ..........
 *  UUUUR
 * 
 *  Input:          Output:                Comments:
 *  3               Nikoladze killed!      Turn 1: Enemies move, Sam waits.
 *  N......         X..S...                Turn 2: Enemies move, Sam goes up, steps on an enemy.
 *  .b.....         .......                Turn 3: Enemies move, Sam goes up, kills Nikoladze.
 *  ..dS...         b......
 *  WUUU
 * 
 *  Input:           Output:               Comments:
 *  6                Nikoladze killed!     Turn 1/2/3: Enemies move, Sam waits.
 *  .............    .............         Turn 4: Enemies move, Sam goes down.
 *  ....S........    .............         Turn 5/6/7: Enemies move, Sam waits.
 *  .b...........    ............b         Turn 8/9: Enemies move, Sam goes down.
 *  ...........d.    d............         Turn 10: Enemies move, Sam goes right.
 *  .............    .............         Turn 11: Enemies move, Sam goes down and kills Nikoladze.
 *  ....N........    ....XS.......
 *  WWWDWWWDDRD
 * 
 * https://github.com/PavelDoynov
 */


using System;

namespace _1
{
    class Program
    {
        static void Main()
        {
            char[][] roomMatrix = GetTheRoom();

            char[] command = Console.ReadLine().ToCharArray();

            int[] samCoordinations = new int[2];
            int[] nikoladzeCoordinations = new int[2];

            for (int row = 0; row < roomMatrix.Length; row++)
            {
                for (int col = 0; col < roomMatrix[row].Length; col++)
                {
                    if (roomMatrix[row][col] == 'S')
                    {
                        samCoordinations[0] = row;
                        samCoordinations[1] = col;
                    }

                    if (roomMatrix[row][col] == 'N')
                    {
                        nikoladzeCoordinations[0] = row;
                        nikoladzeCoordinations[1] = col;
                    }
                }
            }

            for (int step = 0; step < command.Length; step++)
            {
                
                char direction = command[step];

                roomMatrix = MoveEnemies(roomMatrix);


                if (direction == 'U')
                {
                    roomMatrix[samCoordinations[0]][samCoordinations[1]] = '.';
                    if (EnemyIsThere(samCoordinations, roomMatrix)) 
                    {
                        roomMatrix[samCoordinations[0]][samCoordinations[1]] = 'X';
                        Console.WriteLine($"Sam died at {string.Join(", ", samCoordinations)}");
                        ViewMatrix(roomMatrix);
                        break;
                    }
                    samCoordinations[0]--;
                    roomMatrix[samCoordinations[0]][samCoordinations[1]] = 'S';
                }
                else if (direction == 'D')
                {
                    roomMatrix[samCoordinations[0]][samCoordinations[1]] = '.';
                    if (EnemyIsThere(samCoordinations, roomMatrix))
                    {
                        roomMatrix[samCoordinations[0]][samCoordinations[1]] = 'X';
                        Console.WriteLine($"Sam died at {string.Join(", ", samCoordinations)}");
                        ViewMatrix(roomMatrix);
                        break;
                    }
                    samCoordinations[0]++;
                    roomMatrix[samCoordinations[0]][samCoordinations[1]] = 'S';
                }
                else if (direction == 'L')
                {
                    roomMatrix[samCoordinations[0]][samCoordinations[1]] = '.';
                    if (EnemyIsThere(samCoordinations, roomMatrix))
                    {
                        roomMatrix[samCoordinations[0]][samCoordinations[1]] = 'X';
                        Console.WriteLine($"Sam died at {string.Join(", ", samCoordinations)}");
                        ViewMatrix(roomMatrix);
                        break;
                    }
                    samCoordinations[1]--;
                    roomMatrix[samCoordinations[0]][samCoordinations[1]] = 'S';
                }
                else if (direction == 'R')
                {
                    roomMatrix[samCoordinations[0]][samCoordinations[1]] = '.';
                    if (EnemyIsThere(samCoordinations, roomMatrix))
                    {
                        roomMatrix[samCoordinations[0]][samCoordinations[1]] = 'X';
                        Console.WriteLine($"Sam died at {string.Join(", ", samCoordinations)}");
                        ViewMatrix(roomMatrix);
                        break;
                    }
                    samCoordinations[1]++;
                    roomMatrix[samCoordinations[0]][samCoordinations[1]] = 'S';
                }


                if (nikoladzeCoordinations[0] == samCoordinations[0])
                {
                    roomMatrix[nikoladzeCoordinations[0]][nikoladzeCoordinations[1]] = 'X';
                    roomMatrix[samCoordinations[0]][samCoordinations[1]] = 'S';
                    Console.WriteLine("Nikoladze killed!");
                    ViewMatrix(roomMatrix);
                    break;
                }


            }


        }

        private static void ViewMatrix(char[][] roomMatrix)
        {
            for (int row = 0; row < roomMatrix.Length; row++) 
            {
                for (int col = 0; col < roomMatrix[row].Length; col++)
                {
                    Console.Write($"{roomMatrix[row][col]}");
                }
                Console.WriteLine();
            }
        }

        private static bool EnemyIsThere(int[] samCoordinations, char[][] roomMatrix)
        {
            for (int col = 0; col < samCoordinations[1]; col++)
            {
                if (roomMatrix[samCoordinations[0]][col] == 'b')
                {
                    return true;
                }
            }

            for (int col = samCoordinations[1]+1; col < roomMatrix[samCoordinations[0]].Length; col++)
            {
                if (roomMatrix[samCoordinations[0]][col] == 'd')
                {
                    return true;
                }
            }

            return false;
        }

        private static char[][] MoveEnemies(char[][] roomMatrix)
        {
            for (int row = 0; row < roomMatrix.Length; row++)
            {
                for (int col = 0; col < roomMatrix[row].Length; col++)
                {
                    if (roomMatrix[row][col] == 'b')
                    {
                        if (col  == roomMatrix[row].Length - 1)
                        {
                            roomMatrix[row][col] = 'd';
                            break;
                        }
                        else
                        {
                            roomMatrix[row][col] = '.';
                            roomMatrix[row][col + 1] = 'b';
                            break;
                        }
                    }
                    else if (roomMatrix[row][col] == 'd')
                    {
                        if (col == 0) 
                        {
                            roomMatrix[row][col] = 'b';
                            break;
                        }
                        else
                        {
                            roomMatrix[row][col] = '.';
                            roomMatrix[row][col - 1] = 'd';
                            break;
                        }
                    }
                }
            }
            return roomMatrix;
        }

        private static char[][] GetTheRoom()
        {
            int rowNumber = int.Parse(Console.ReadLine());

            char[][] matrix = new char[rowNumber][];

            for (int row = 0; row < matrix.Length; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                matrix[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++) 
                {

                    matrix[row][col] = input[col];
                }
            }

            return matrix;
        }
    }
}
