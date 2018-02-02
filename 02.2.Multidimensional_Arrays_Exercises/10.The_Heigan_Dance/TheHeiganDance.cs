/*
 * 10. The Heigan Dance
 * 
 * At last, level 80. And what do level eighties do? Go raiding. This is where you are now – trying not to be wiped by
 * the famous dance boss, Heigan the Unclean. The fight is pretty straightforward - dance around the Plague Clouds and
 * Eruptions, and you’ll be just fine.
 * 
 * Heigan’s chamber is a 15-by-15 two-dimensional array. The player always starts at the exact center. 
 * For each turn, Heigan uses a spell that hits a certain cell and the neighboring rows/columns. 
 * For example, if he hits (1,1), he also hits (0,0, 0,1, 0,2, 1,0 … 2,2). If the player’s current position is within 
 * the area of damage, the player tries to move. First, he tries to move up, if there’s damage/wall, he tries to move right,
 * then down, then left. If he cannot move in any direction, because the cell is damaged or there is a wall, 
 * the player stays in place and takes the damage.
 * 
 * Plague cloud does 3500 damage when it hits, and 3500 damage the next turn. Then it expires. 
 * Eruption does 6000 damage when it hits. If a spell hits a player that also has an active Plague Cloud from the
 * previous turn, the cloud damage is applied first. 
 * Both Heigan and the player may die in the same turn. If Heigan is dead, the spell he would have casted is ignored.
 * 
 * The player always starts at 18500 hit points; Heigan starts at 3,000,000 hit points. Each turn, the player does damage 
 * to Heigan. The fight is over either when the player is killed, or Heigan is defeated.
 * 
 * Input
 * •   On the first line you receive a floating-point number D – the damage done to Heigan each turn
 * •   On the next several lines – you receive input in format {spell} {row} {col} – {spell} is either Cloud or Eruption
 * 
 * Output
 * •       On the first line  
 *   o   If Heigan is defeated: “Heigan: Defeated!”
 *   o   Else: “Heigan: {remaining}”, where remaining is rounded to two digits after the decimal separator
 * •       On the second line:
 *   o   If the player is killed: “Player: Killed by {spell}”
 *   o   Else “Player: {remaining}”
 * •       On the third line: “Final position: {row,  col}” -> the last coordinates of the player
 * 
 * Constraints
 * •   D is a floating-point number in range [0 … 500000]
 * •   A damaging spell will always affect at least one cell
 * •   Allowed memory: 16 MB
 * •   Allowed working time: 0.25s
 * 
 * Example
 * Input:           Output:                            Input:           Output:
 * 10000            Heigan: 2960000.00                 500000           Heigan: Defeated!
 * Cloud 7 7        Player: Killed by Eruption         Cloud 7 6        Player: 12500
 * Eruption 6 7     Final position: 8, 7               Eruption 7 8     Final position: 7, 11
 * Eruption 8 7                                        Eruption 7 7
 * Eruption 8 7                                        Cloud 7 8
 *                                                     Eruption 7 9
 * Input:           Output:                            Eruption 6 14
 * 12500.66         Heigan: 2949997.36                 Eruption 7 11
 * Cloud 7 7        Player: Killed by Plague Cloud
 * Cloud 7 7        Final position: 7, 7
 * Cloud 7 7
 * Cloud 7 7
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Linq;

namespace _10.The_Heigan_Dance
{
    class Program
    {
        static void Main()
        {
            int[] playerCoor = new int[] { 7, 7 };

            double playerHealth = 18500;
            double heiganHealth = 3000000;

            bool spellCurse = false;
            string spell = null;

            double playerDamage = double.Parse(Console.ReadLine());

            while (true)
            {
                heiganHealth = heiganHealth - playerDamage;

                if (spellCurse)
                {
                    playerHealth -= 3500;
                    spellCurse = false;
                }

                if (heiganHealth <= 0 || playerHealth <= 0)
                {
                    break;
                }

                string[] commands = Console.ReadLine()
                                           .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                                           .ToArray();

                spell = commands[0];
                int damagedRow = int.Parse(commands[1]);
                int damagedCol = int.Parse(commands[2]);

                if (PlayerIsInDamagedArea(playerCoor[0], playerCoor[1], damagedRow, damagedCol))
                {
                    if (!PlayerIsInDamagedArea(playerCoor[0] - 1, playerCoor[1], damagedRow, damagedCol) && IsInTheMatrix(playerCoor[0] - 1)) // moving up
                    {
                        playerCoor[0]--;
                        spell = null;
                    }
                    else if (!PlayerIsInDamagedArea(playerCoor[0], playerCoor[1] + 1, damagedRow, damagedCol) && IsInTheMatrix(playerCoor[1] + 1)) // moving right
                    {
                        playerCoor[1]++;
                        spell = null;
                    }
                        else if (!PlayerIsInDamagedArea(playerCoor[0] + 1, playerCoor[1], damagedRow, damagedCol) && IsInTheMatrix(playerCoor[0] + 1)) // moving down
                    {
                        playerCoor[0]++;
                        spell = null;
                    }
                    else if (!PlayerIsInDamagedArea(playerCoor[0], playerCoor[1] - 1, damagedRow, damagedCol) && IsInTheMatrix(playerCoor[1] - 1)) // moving left
                    {
                        playerCoor[1]--;
                        spell = null;
                    }
                    else
                    {
                        if (spell == "Eruption")
                        {
                            playerHealth -= 6000;
                        }
                        else if (spell == "Cloud")
                        {
                            playerHealth -= 3500;
                            spellCurse = true;
                        }
                    }
                }
                if (playerHealth <= 0)
                {
                    break;
                }

            }
            if (spell == "Cloud")
            {
                spell = "Plague Cloud";
            }

            string heiganResult = null;
            if (heiganHealth <= 0)
            {
                heiganResult = "Defeated!";
            }
            else
            {
                heiganResult = $"{heiganHealth:f2}";
            }

            string playerResult = null;
            if (playerHealth <= 0)
            {
                playerResult = "Killed by " + spell;
            }
            else
            {
                playerResult = $"{playerHealth}";
            }

            Console.WriteLine($"Heigan: {heiganResult}");
            Console.WriteLine($"Player: {playerResult}");
            Console.WriteLine($"Final position: {string.Join(", ", playerCoor)}");
        }

        private static bool IsInTheMatrix(int playerCoor)
        {
            return playerCoor >= 0 && playerCoor < 15;
        }

        private static bool PlayerIsInDamagedArea(int playerCoorRow, int playerCoorCol, int damagedRow, int damagedCol)
        {
            return playerCoorCol <= damagedCol + 1 && playerCoorCol >= damagedCol - 1 
                && playerCoorRow <= damagedRow + 1 && playerCoorRow >= damagedRow - 1;
        }
    }
}
