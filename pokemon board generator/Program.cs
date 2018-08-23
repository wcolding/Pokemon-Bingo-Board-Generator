/* Pokemon Bingo Board Generator v1.1
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
    public class SquarePool
    {
        public List<Square> options;
        
        public string JSONout()
        {
            if (options.Count < 25)
                return "List not fully populated!";

            string output = "[\n";
            
            for (int i = 0; i < options.Count; i++)
            {
                output += String.Format(" {{\"name\": \"{0}\"}}", options[i].name);

                if (i != options.Count-1)
                    output += ",";
                output += "\n";
            }

            output += "]";
            return output;
        }
    }

    public class Square
    {
        public string name;
        public ObjectiveType lineage;

        public Square(string _n, ObjectiveType _l)
        {
            name = _n;
            lineage = _l;
        }
    }
    
    class BoardGenerator
    {
        static void PickSquares(SquarePool input, out SquarePool picked, int size, int seed=-1)
        {
            SquarePool workingInputPool = input;
            SquarePool workingOutputPool = new SquarePool();
            workingOutputPool.options = new List<Square>();

            if (seed == -1)
            {
                seed = (int)System.DateTime.UtcNow.Millisecond;
            }

            Random rng = new Random(seed);

            // Pick a Pokemon from the input pool
            int curPokemon;
            
            for (int square = 0; square < size; square++)
            {
                curPokemon = rng.Next(0, workingInputPool.options.Count);
                workingOutputPool.options.Add(workingInputPool.options[curPokemon]);
                
                if (workingInputPool.options[curPokemon].lineage == ObjectiveType.Single)
                {
                    // Non-evolutionary Pokemon just get removed from the input pool
                    workingInputPool.options.RemoveAt(curPokemon);
                }
                else
                {
                    // Evolutionary Pokemon get removed with their entire lineage
                    ObjectiveType family = workingInputPool.options[curPokemon].lineage;
                    workingInputPool.options.RemoveAll(option => option.lineage == family);
                }
            }

            picked = workingOutputPool;
        }

        [STAThreadAttribute]
        static void Main(string[] args)
        {
            SquarePool myBoard;
            SquarePool[] pools = new SquarePool[5]
                { DataSet.genIpokemon, DataSet.genIcleanedup, DataSet.genIfullyevolved, DataSet.genIIpokemon, DataSet.genIIIfullyevolved};

            int userChoice = 2;

            Console.WriteLine("Pokemon Board Generator\n\n" +
                "Choose mode:\n" +
                "   1. Full 151\n" +
                "   2. Starters Evolved\n" +
                "   3. All Evolved\n" +
                "   4. Gen I + II Full\n" +
                "   5. Gen III All Evolved");
            Console.Write("? ");

            try {
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

            PickSquares(pools[userChoice], out myBoard, 25);
            string dump = myBoard.JSONout();

            // You can uncomment this if you want to see the board.
            // If you want a surprise, leave it alone!
            //Console.WriteLine(dump);

            Clipboard.SetText(dump);
            Console.WriteLine("Copied board to clipboard!");
            Console.Read();
        }
    }
}
