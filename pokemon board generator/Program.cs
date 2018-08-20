/* Pokemon Bingo Board Generator v1.0
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
            string output = "[\n";

            if (options.Count < 1)
                return "List not populated!";

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

    public enum ObjectiveType
    {
        SingleEv = 0,
        Bulbasaur,
        Charmander,
        Squirtle,
        Caterpie,
        Weedle,
        Pidgey,
        Rattata,
        Spearow,
        Ekans,
        Pikachu,
        Sandshrew,
        Nidoran_M,
        Nidoran_F,
        Clefairy,
        Vulpix,
        Jigglypuff,
        Zubat,
        Oddish,
        Paras,
        Venonat,
        Diglett,
        Meowth,
        Psyduck,
        Mankey,
        Growlithe,
        Poliwag,
        Abra,
        Machop,
        Bellsprout,
        Tentacool,
        Geodude,
        Ponyta,
        Slowpoke,
        Magnemite,
        Doduo,
        Seel,
        Grimer,
        Shellder,
        Gastly,
        Drowzee,
        Krabby,
        Voltorb,
        Exeggcute,
        Cubone,
        Koffing,
        Rhyhorn,
        Horsea,
        Goldeen,
        Staryu,
        Magikarp,
        Eevee,
        Omanyte,
        Kabuto,
        Dratini
    };

    class BoardGenerator
    {

        static SquarePool genIpokemon = new SquarePool()
        { 
            options = new List<Square>{
            new Square("Bulbasaur", ObjectiveType.Bulbasaur),
            new Square("Ivysaur", ObjectiveType.Bulbasaur),
            new Square("Venusaur", ObjectiveType.Bulbasaur),
            new Square("Charmander", ObjectiveType.Charmander),
            new Square("Charmeleon", ObjectiveType.Charmander),
            new Square("Charizard", ObjectiveType.Charmander),
            new Square("Squirtle", ObjectiveType.Squirtle),
            new Square("Wartortle", ObjectiveType.Squirtle),
            new Square("Blastoise", ObjectiveType.Squirtle),
            new Square("Caterpie", ObjectiveType.Caterpie),
            new Square("Metapod", ObjectiveType.Caterpie),
            new Square("Butterfree", ObjectiveType.Caterpie),
            new Square("Weedle", ObjectiveType.Weedle),
            new Square("Kakuna", ObjectiveType.Weedle),
            new Square("Beedrill", ObjectiveType.Weedle),
            new Square("Pidgey", ObjectiveType.Pidgey),
            new Square("Pidgeotto", ObjectiveType.Pidgey),
            new Square("Pidgeot", ObjectiveType.Pidgey),
            new Square("Rattata", ObjectiveType.Rattata),
            new Square("Raticate", ObjectiveType.Rattata),
            new Square("Spearow", ObjectiveType.Spearow),
            new Square("Fearow", ObjectiveType.Spearow),
            new Square("Ekans", ObjectiveType.Ekans),
            new Square("Arbok", ObjectiveType.Ekans),
            new Square("Pikachu", ObjectiveType.Pikachu),
            new Square("Raichu", ObjectiveType.Pikachu),
            new Square("Sandshrew", ObjectiveType.Sandshrew),
            new Square("Sandslash", ObjectiveType.Sandshrew),
            new Square("Nidoran ♀", ObjectiveType.Nidoran_F),
            new Square("Nidorina", ObjectiveType.Nidoran_F),
            new Square("Nidoqueen", ObjectiveType.Nidoran_F),
            new Square("Nidoran ♂", ObjectiveType.Nidoran_M),
            new Square("Nidorino", ObjectiveType.Nidoran_M),
            new Square("Nidoking", ObjectiveType.Nidoran_M),
            new Square("Clefairy", ObjectiveType.Clefairy),
            new Square("Clefable", ObjectiveType.Clefairy),
            new Square("Vulpix", ObjectiveType.Vulpix),
            new Square("Ninetails", ObjectiveType.Vulpix),
            new Square("Jigglypuff", ObjectiveType.Jigglypuff),
            new Square("Wigglytuff", ObjectiveType.Jigglypuff),
            new Square("Zubat", ObjectiveType.Zubat),
            new Square("Golbat", ObjectiveType.Zubat),
            new Square("Oddish", ObjectiveType.Oddish),
            new Square("Gloom", ObjectiveType.Oddish),
            new Square("Vileplume", ObjectiveType.Oddish),
            new Square("Paras", ObjectiveType.Paras),
            new Square("Parasect", ObjectiveType.Paras),
            new Square("Venonat", ObjectiveType.Venonat),
            new Square("Venomoth", ObjectiveType.Venonat),
            new Square("Diglett", ObjectiveType.Diglett),
            new Square("Dugtrio", ObjectiveType.Diglett),
            new Square("Meowth", ObjectiveType.Meowth),
            new Square("Persian", ObjectiveType.Meowth),
            new Square("Psyduck", ObjectiveType.Psyduck),
            new Square("Golduck", ObjectiveType.Psyduck),
            new Square("Mankey", ObjectiveType.Mankey),
            new Square("Primeape", ObjectiveType.Mankey),
            new Square("Growlithe", ObjectiveType.Growlithe),
            new Square("Arcanine", ObjectiveType.Growlithe),
            new Square("Poliwag", ObjectiveType.Poliwag),
            new Square("Poliwhirl", ObjectiveType.Poliwag),
            new Square("Poliwrath", ObjectiveType.Poliwag),
            new Square("Abra", ObjectiveType.Abra),
            new Square("Kadabra", ObjectiveType.Abra),
            new Square("Alakazam", ObjectiveType.Abra),
            new Square("Machop", ObjectiveType.Machop),
            new Square("Machoke", ObjectiveType.Machop),
            new Square("Machamp", ObjectiveType.Machop),
            new Square("Bellsprout", ObjectiveType.Bellsprout),
            new Square("Weepinbell", ObjectiveType.Bellsprout),
            new Square("Victreebel", ObjectiveType.Bellsprout),
            new Square("Tentacool", ObjectiveType.Tentacool),
            new Square("Tentacruel", ObjectiveType.Tentacool),
            new Square("Geodude", ObjectiveType.Geodude),
            new Square("Graveler", ObjectiveType.Geodude),
            new Square("Golem", ObjectiveType.Geodude),
            new Square("Ponyta", ObjectiveType.Ponyta),
            new Square("Rapidash", ObjectiveType.Ponyta),
            new Square("Slowpoke", ObjectiveType.Slowpoke),
            new Square("Slowbro", ObjectiveType.Slowpoke),
            new Square("Magnemite", ObjectiveType.Magnemite),
            new Square("Magneton", ObjectiveType.Magnemite),
            new Square("Farfetch'd", ObjectiveType.SingleEv),
            new Square("Doduo", ObjectiveType.Doduo),
            new Square("Dodrio", ObjectiveType.Doduo),
            new Square("Seel", ObjectiveType.Seel),
            new Square("Dewgong", ObjectiveType.Seel),
            new Square("Grimer", ObjectiveType.Grimer),
            new Square("Muk", ObjectiveType.Grimer),
            new Square("Shellder", ObjectiveType.Shellder),
            new Square("Cloyster", ObjectiveType.Shellder),
            new Square("Gastly", ObjectiveType.Gastly),
            new Square("Haunter", ObjectiveType.Gastly),
            new Square("Gengar", ObjectiveType.Gastly),
            new Square("Onix", ObjectiveType.SingleEv),
            new Square("Drowzee", ObjectiveType.Drowzee),
            new Square("Hypno", ObjectiveType.Drowzee),
            new Square("Krabby", ObjectiveType.Krabby),
            new Square("Kingler", ObjectiveType.Krabby),
            new Square("Voltorb", ObjectiveType.Voltorb),
            new Square("Electrode", ObjectiveType.Voltorb),
            new Square("Exeggcute", ObjectiveType.Exeggcute),
            new Square("Exeggutor", ObjectiveType.Exeggcute),
            new Square("Cubone", ObjectiveType.Cubone),
            new Square("Marowak", ObjectiveType.Cubone),
            new Square("Hitmonlee", ObjectiveType.SingleEv),
            new Square("Hitmonchan", ObjectiveType.SingleEv),
            new Square("Lickitung", ObjectiveType.SingleEv),
            new Square("Koffing", ObjectiveType.Koffing),
            new Square("Weezing", ObjectiveType.Koffing),
            new Square("Rhyhorn", ObjectiveType.Rhyhorn),
            new Square("Rhydon", ObjectiveType.Rhyhorn),
            new Square("Chansey", ObjectiveType.SingleEv),
            new Square("Tangela", ObjectiveType.SingleEv),
            new Square("Kangaskhan", ObjectiveType.SingleEv),
            new Square("Horsea", ObjectiveType.Horsea),
            new Square("Seadra", ObjectiveType.Horsea),
            new Square("Goldeen", ObjectiveType.Goldeen),
            new Square("Seaking", ObjectiveType.Goldeen),
            new Square("Staryu", ObjectiveType.Staryu),
            new Square("Starmie", ObjectiveType.Staryu),
            new Square("Mr. Mime", ObjectiveType.SingleEv),
            new Square("Scyther", ObjectiveType.SingleEv),
            new Square("Jynx", ObjectiveType.SingleEv),
            new Square("Electabuzz", ObjectiveType.SingleEv),
            new Square("Magmar", ObjectiveType.SingleEv),
            new Square("Pinsir", ObjectiveType.SingleEv),
            new Square("Tauros", ObjectiveType.SingleEv),
            new Square("Magikarp", ObjectiveType.Magikarp),
            new Square("Gyarados", ObjectiveType.Magikarp),
            new Square("Lapras", ObjectiveType.SingleEv),
            new Square("Ditto", ObjectiveType.SingleEv),
            new Square("Eevee", ObjectiveType.Eevee),
            new Square("Vaporeon", ObjectiveType.Eevee),
            new Square("Jolteon", ObjectiveType.Eevee),
            new Square("Flareon", ObjectiveType.Eevee),
            new Square("Porygon", ObjectiveType.SingleEv),
            new Square("Omanyte", ObjectiveType.Omanyte),
            new Square("Omastar", ObjectiveType.Omanyte),
            new Square("Kabuto", ObjectiveType.Kabuto),
            new Square("Kabutops", ObjectiveType.Kabuto),
            new Square("Snorlax", ObjectiveType.SingleEv),
            new Square("Articuno", ObjectiveType.SingleEv),
            new Square("Zapdos", ObjectiveType.SingleEv),
            new Square("Moltres", ObjectiveType.SingleEv),
            new Square("Dratini", ObjectiveType.Dratini),
            new Square("Dragonair", ObjectiveType.Dratini),
            new Square("Dragonite", ObjectiveType.Dratini),
            new Square("Mewtwo", ObjectiveType.SingleEv),
            new Square("Mew", ObjectiveType.SingleEv)
            }
};
        static SquarePool genIcleanedup = new SquarePool()
        {
            options = new List<Square>{
            new Square("Venusaur", ObjectiveType.Bulbasaur),
            new Square("Charizard", ObjectiveType.Charmander),
            new Square("Blastoise", ObjectiveType.Squirtle),
            new Square("Caterpie", ObjectiveType.Caterpie),
            new Square("Metapod", ObjectiveType.Caterpie),
            new Square("Butterfree", ObjectiveType.Caterpie),
            new Square("Weedle", ObjectiveType.Weedle),
            new Square("Kakuna", ObjectiveType.Weedle),
            new Square("Beedrill", ObjectiveType.Weedle),
            new Square("Pidgey", ObjectiveType.Pidgey),
            new Square("Pidgeotto", ObjectiveType.Pidgey),
            new Square("Pidgeot", ObjectiveType.Pidgey),
            new Square("Rattata", ObjectiveType.Rattata),
            new Square("Raticate", ObjectiveType.Rattata),
            new Square("Spearow", ObjectiveType.Spearow),
            new Square("Fearow", ObjectiveType.Spearow),
            new Square("Ekans", ObjectiveType.Ekans),
            new Square("Arbok", ObjectiveType.Ekans),
            new Square("Pikachu", ObjectiveType.Pikachu),
            new Square("Raichu", ObjectiveType.Pikachu),
            new Square("Sandshrew", ObjectiveType.Sandshrew),
            new Square("Sandslash", ObjectiveType.Sandshrew),
            new Square("Nidoran ♀", ObjectiveType.Nidoran_F),
            new Square("Nidorina", ObjectiveType.Nidoran_F),
            new Square("Nidoqueen", ObjectiveType.Nidoran_F),
            new Square("Nidoran ♂", ObjectiveType.Nidoran_M),
            new Square("Nidorino", ObjectiveType.Nidoran_M),
            new Square("Nidoking", ObjectiveType.Nidoran_M),
            new Square("Clefairy", ObjectiveType.Clefairy),
            new Square("Clefable", ObjectiveType.Clefairy),
            new Square("Vulpix", ObjectiveType.Vulpix),
            new Square("Ninetails", ObjectiveType.Vulpix),
            new Square("Jigglypuff", ObjectiveType.Jigglypuff),
            new Square("Wigglytuff", ObjectiveType.Jigglypuff),
            new Square("Zubat", ObjectiveType.Zubat),
            new Square("Golbat", ObjectiveType.Zubat),
            new Square("Oddish", ObjectiveType.Oddish),
            new Square("Gloom", ObjectiveType.Oddish),
            new Square("Vileplume", ObjectiveType.Oddish),
            new Square("Paras", ObjectiveType.Paras),
            new Square("Parasect", ObjectiveType.Paras),
            new Square("Venonat", ObjectiveType.Venonat),
            new Square("Venomoth", ObjectiveType.Venonat),
            new Square("Diglett", ObjectiveType.Diglett),
            new Square("Dugtrio", ObjectiveType.Diglett),
            new Square("Meowth", ObjectiveType.Meowth),
            new Square("Persian", ObjectiveType.Meowth),
            new Square("Psyduck", ObjectiveType.Psyduck),
            new Square("Golduck", ObjectiveType.Psyduck),
            new Square("Mankey", ObjectiveType.Mankey),
            new Square("Primeape", ObjectiveType.Mankey),
            new Square("Growlithe", ObjectiveType.Growlithe),
            new Square("Arcanine", ObjectiveType.Growlithe),
            new Square("Poliwag", ObjectiveType.Poliwag),
            new Square("Poliwhirl", ObjectiveType.Poliwag),
            new Square("Poliwrath", ObjectiveType.Poliwag),
            new Square("Abra", ObjectiveType.Abra),
            new Square("Kadabra", ObjectiveType.Abra),
            new Square("Alakazam", ObjectiveType.Abra),
            new Square("Machop", ObjectiveType.Machop),
            new Square("Machoke", ObjectiveType.Machop),
            new Square("Machamp", ObjectiveType.Machop),
            new Square("Bellsprout", ObjectiveType.Bellsprout),
            new Square("Weepinbell", ObjectiveType.Bellsprout),
            new Square("Victreebel", ObjectiveType.Bellsprout),
            new Square("Tentacool", ObjectiveType.Tentacool),
            new Square("Tentacruel", ObjectiveType.Tentacool),
            new Square("Geodude", ObjectiveType.Geodude),
            new Square("Graveler", ObjectiveType.Geodude),
            new Square("Golem", ObjectiveType.Geodude),
            new Square("Ponyta", ObjectiveType.Ponyta),
            new Square("Rapidash", ObjectiveType.Ponyta),
            new Square("Slowpoke", ObjectiveType.Slowpoke),
            new Square("Slowbro", ObjectiveType.Slowpoke),
            new Square("Magnemite", ObjectiveType.Magnemite),
            new Square("Magneton", ObjectiveType.Magnemite),
            new Square("Farfetch'd", ObjectiveType.SingleEv),
            new Square("Doduo", ObjectiveType.Doduo),
            new Square("Dodrio", ObjectiveType.Doduo),
            new Square("Seel", ObjectiveType.Seel),
            new Square("Dewgong", ObjectiveType.Seel),
            new Square("Grimer", ObjectiveType.Grimer),
            new Square("Muk", ObjectiveType.Grimer),
            new Square("Shellder", ObjectiveType.Shellder),
            new Square("Cloyster", ObjectiveType.Shellder),
            new Square("Gastly", ObjectiveType.Gastly),
            new Square("Haunter", ObjectiveType.Gastly),
            new Square("Gengar", ObjectiveType.Gastly),
            new Square("Onix", ObjectiveType.SingleEv),
            new Square("Drowzee", ObjectiveType.Drowzee),
            new Square("Hypno", ObjectiveType.Drowzee),
            new Square("Krabby", ObjectiveType.Krabby),
            new Square("Kingler", ObjectiveType.Krabby),
            new Square("Voltorb", ObjectiveType.Voltorb),
            new Square("Electrode", ObjectiveType.Voltorb),
            new Square("Exeggcute", ObjectiveType.Exeggcute),
            new Square("Exeggutor", ObjectiveType.Exeggcute),
            new Square("Cubone", ObjectiveType.Cubone),
            new Square("Marowak", ObjectiveType.Cubone),
            new Square("Hitmonlee", ObjectiveType.SingleEv),
            new Square("Hitmonchan", ObjectiveType.SingleEv),
            new Square("Lickitung", ObjectiveType.SingleEv),
            new Square("Koffing", ObjectiveType.Koffing),
            new Square("Weezing", ObjectiveType.Koffing),
            new Square("Rhydon", ObjectiveType.Rhyhorn),
            new Square("Chansey", ObjectiveType.SingleEv),
            new Square("Tangela", ObjectiveType.SingleEv),
            new Square("Kangaskhan", ObjectiveType.SingleEv),
            new Square("Seadra", ObjectiveType.Horsea),
            new Square("Seaking", ObjectiveType.Goldeen),
            new Square("Starmie", ObjectiveType.Staryu),
            new Square("Mr. Mime", ObjectiveType.SingleEv),
            new Square("Scyther", ObjectiveType.SingleEv),
            new Square("Jynx", ObjectiveType.SingleEv),
            new Square("Electabuzz", ObjectiveType.SingleEv),
            new Square("Magmar", ObjectiveType.SingleEv),
            new Square("Pinsir", ObjectiveType.SingleEv),
            new Square("Tauros", ObjectiveType.SingleEv),
            new Square("Gyarados", ObjectiveType.Magikarp),
            new Square("Lapras", ObjectiveType.SingleEv),
            new Square("Ditto", ObjectiveType.SingleEv),
            new Square("Vaporeon", ObjectiveType.Eevee),
            new Square("Jolteon", ObjectiveType.Eevee),
            new Square("Flareon", ObjectiveType.Eevee),
            new Square("Porygon", ObjectiveType.SingleEv),
            new Square("Omastar", ObjectiveType.Omanyte),
            new Square("Kabutops", ObjectiveType.Kabuto),
            new Square("Snorlax", ObjectiveType.SingleEv),
            new Square("Articuno", ObjectiveType.SingleEv),
            new Square("Zapdos", ObjectiveType.SingleEv),
            new Square("Moltres", ObjectiveType.SingleEv),
            new Square("Dragonite", ObjectiveType.Dratini),
            new Square("Mewtwo", ObjectiveType.SingleEv),
            new Square("Mew", ObjectiveType.SingleEv)
            }
        };

        static SquarePool genIfullyevolved = new SquarePool()
        {
            options = new List<Square>{
            new Square("Venusaur", ObjectiveType.Bulbasaur),
            new Square("Charizard", ObjectiveType.Charmander),
            new Square("Blastoise", ObjectiveType.Squirtle),
            new Square("Butterfree", ObjectiveType.Caterpie),
            new Square("Beedrill", ObjectiveType.Weedle),
            new Square("Pidgeot", ObjectiveType.Pidgey),
            new Square("Raticate", ObjectiveType.Rattata),
            new Square("Fearow", ObjectiveType.Spearow),
            new Square("Arbok", ObjectiveType.Ekans),
            new Square("Raichu", ObjectiveType.Pikachu),
            new Square("Sandslash", ObjectiveType.Sandshrew),
            new Square("Nidoqueen", ObjectiveType.Nidoran_F),
            new Square("Nidoking", ObjectiveType.Nidoran_M),
            new Square("Clefable", ObjectiveType.Clefairy),
            new Square("Ninetails", ObjectiveType.Vulpix),
            new Square("Wigglytuff", ObjectiveType.Jigglypuff),
            new Square("Golbat", ObjectiveType.Zubat),
            new Square("Vileplume", ObjectiveType.Oddish),
            new Square("Parasect", ObjectiveType.Paras),
            new Square("Venomoth", ObjectiveType.Venonat),
            new Square("Dugtrio", ObjectiveType.Diglett),
            new Square("Persian", ObjectiveType.Meowth),
            new Square("Golduck", ObjectiveType.Psyduck),
            new Square("Primeape", ObjectiveType.Mankey),
            new Square("Arcanine", ObjectiveType.Growlithe),
            new Square("Poliwrath", ObjectiveType.Poliwag),
            new Square("Alakazam", ObjectiveType.Abra),
            new Square("Machamp", ObjectiveType.Machop),
            new Square("Victreebel", ObjectiveType.Bellsprout),
            new Square("Tentacruel", ObjectiveType.Tentacool),
            new Square("Golem", ObjectiveType.Geodude),
            new Square("Rapidash", ObjectiveType.Ponyta),
            new Square("Slowbro", ObjectiveType.Slowpoke),
            new Square("Magneton", ObjectiveType.Magnemite),
            new Square("Farfetch'd", ObjectiveType.SingleEv),
            new Square("Dodrio", ObjectiveType.Doduo),
            new Square("Dewgong", ObjectiveType.Seel),
            new Square("Muk", ObjectiveType.Grimer),
            new Square("Cloyster", ObjectiveType.Shellder),
            new Square("Gengar", ObjectiveType.Gastly),
            new Square("Onix", ObjectiveType.SingleEv),
            new Square("Hypno", ObjectiveType.Drowzee),
            new Square("Kingler", ObjectiveType.Krabby),
            new Square("Electrode", ObjectiveType.Voltorb),
            new Square("Exeggutor", ObjectiveType.Exeggcute),
            new Square("Marowak", ObjectiveType.Cubone),
            new Square("Hitmonlee", ObjectiveType.SingleEv),
            new Square("Hitmonchan", ObjectiveType.SingleEv),
            new Square("Lickitung", ObjectiveType.SingleEv),
            new Square("Weezing", ObjectiveType.Koffing),
            new Square("Rhydon", ObjectiveType.Rhyhorn),
            new Square("Chansey", ObjectiveType.SingleEv),
            new Square("Tangela", ObjectiveType.SingleEv),
            new Square("Kangaskhan", ObjectiveType.SingleEv),
            new Square("Seadra", ObjectiveType.Horsea),
            new Square("Seaking", ObjectiveType.Goldeen),
            new Square("Starmie", ObjectiveType.Staryu),
            new Square("Mr. Mime", ObjectiveType.SingleEv),
            new Square("Scyther", ObjectiveType.SingleEv),
            new Square("Jynx", ObjectiveType.SingleEv),
            new Square("Electabuzz", ObjectiveType.SingleEv),
            new Square("Magmar", ObjectiveType.SingleEv),
            new Square("Pinsir", ObjectiveType.SingleEv),
            new Square("Tauros", ObjectiveType.SingleEv),
            new Square("Gyarados", ObjectiveType.Magikarp),
            new Square("Lapras", ObjectiveType.SingleEv),
            new Square("Ditto", ObjectiveType.SingleEv),
            new Square("Vaporeon", ObjectiveType.Eevee),
            new Square("Jolteon", ObjectiveType.Eevee),
            new Square("Flareon", ObjectiveType.Eevee),
            new Square("Porygon", ObjectiveType.SingleEv),
            new Square("Omastar", ObjectiveType.Omanyte),
            new Square("Kabutops", ObjectiveType.Kabuto),
            new Square("Snorlax", ObjectiveType.SingleEv),
            new Square("Articuno", ObjectiveType.SingleEv),
            new Square("Zapdos", ObjectiveType.SingleEv),
            new Square("Moltres", ObjectiveType.SingleEv),
            new Square("Dragonite", ObjectiveType.Dratini),
            new Square("Mewtwo", ObjectiveType.SingleEv),
            new Square("Mew", ObjectiveType.SingleEv)
            }
        };

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
                
                if (workingInputPool.options[curPokemon].lineage == ObjectiveType.SingleEv)
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
            SquarePool[] pools = new SquarePool[3]
                { genIpokemon, genIcleanedup, genIfullyevolved };

            int userChoice = 2;

            Console.WriteLine("Pokemon Board Generator\n\n" +
                "Choose mode:\n" +
                "1. Full 151\n" +
                "2. Starters Evolved\n" +
                "3. All Evolved\n");
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
