using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                if (i != options.Count - 1)
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

    static class BoardGenerator
    {
        public static void PickSquares(SquarePool input, out SquarePool picked, int size, int lMax = 3, int seed = -1)
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
            int lCount = 0;

            for (int square = 0; square < size; square++)
            {
                curPokemon = rng.Next(0, workingInputPool.options.Count);
                workingOutputPool.options.Add(workingInputPool.options[curPokemon]);

                if (workingInputPool.options[curPokemon].lineage == ObjectiveType.Single)
                {
                    // Non-evolutionary Pokemon just get removed from the input pool
                    workingInputPool.options.RemoveAt(curPokemon);
                }
                else if (workingInputPool.options[curPokemon].lineage == ObjectiveType.Legendary)
                {
                    // Legendaries are limited to lMax value
                    lCount++;
                    if (lCount >= lMax)
                        workingInputPool.options.RemoveAll(option => option.lineage == ObjectiveType.Legendary);
                    else
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
    }
    }
