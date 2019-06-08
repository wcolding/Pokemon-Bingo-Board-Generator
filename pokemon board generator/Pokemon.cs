using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_board_generator
{
    public class Pokemon
    {
        public readonly int number;
        public readonly string name;
        public readonly int evFrom;
        public GameVersion gameAccess;
        public Acquisition[] methods;

        public Pokemon(int Number, string Name, int EvolvesFrom)
        {
            number = Number;
            name = Name;
            evFrom = EvolvesFrom;

            methods = new Acquisition[PokemonAccess.VersionCount];
        }
    }

}
