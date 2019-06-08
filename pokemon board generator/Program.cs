/* Pokemon Bingo Board Generator v1.2.0
 * by Will Colding
 * 
 * Generates a custom board for use with Bingosync, with only Pokemon
 * appearing as squares. It is intended for races with the Ultraviolet 
 * romhack of FireRed by LocksmithArmy. Simply run it, pick your board
 * type, and paste the result into Bingosync. */

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace pokemon_board_generator
{
    class CLI { 

        [STAThreadAttribute]
        static void Main(string[] args)
        {
            SquarePool myBoard;
            SquarePool[] pools = new SquarePool[6]
                { DataSet.genIpokemon, DataSet.genIcleanedup, DataSet.genIfullyevolved, DataSet.genIIpokemon, DataSet.genIIIfullyevolved, DataSet.liquidcrystal};

            int userChoice = 2;

            Console.WriteLine("Pokemon Board Generator\n\n" +
                "Choose mode:\n" +
                "   1. Full 151\n" +
                "   2. Starters Evolved\n" +
                "   3. All Evolved\n" +
                "   4. Gen I + II Full\n" +
                "   5. Gen III All Evolved\n" +
                "   6. Liquid Crystal");
            Console.Write("? ");

            try
            {
                userChoice = Convert.ToInt32(Console.ReadLine()) - 1;
            }
            catch
            {

            }
            Console.WriteLine();

            if (userChoice < 0 || userChoice > pools.Length - 1)
            {
                Console.WriteLine("Invalid input. Choosing mode 3.");
                userChoice = 2;
            }
            else
            {
                Console.WriteLine("Mode {0} chosen.", userChoice + 1);
            }

            Console.WriteLine("Generating Pokemon board...");

            BoardGenerator.PickSquares(pools[userChoice], out myBoard, 25);
            string dump = myBoard.JSONout();

            // You can uncomment this if you want to see the board.
            // If you want a surprise, leave it alone!
            // Console.WriteLine(dump);

            Clipboard.SetText(dump);
            Console.WriteLine("Copied board to clipboard!");
            Console.Read();
        }
    }
}
