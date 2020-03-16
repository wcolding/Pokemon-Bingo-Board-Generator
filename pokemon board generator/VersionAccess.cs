using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_board_generator
{
    public enum GameVersion: uint
    {
        Red         = 0x0001,
        Blue        = 0x0002,
        Yellow      = 0x0004,

        Gold        = 0x0008,
        Silver      = 0x0010,
        Crystal     = 0x0020,

        Ruby        = 0x0040,
        Sapphire    = 0x0080,
        Emerald     = 0x0100,
        FireRed     = 0x0200,
        LeafGreen   = 0x0400,

        Diamond     = 0x0800,
        Pearl       = 0x1000,
        Platinum    = 0x2000,
        HeartGold   = 0x4000,
        SoulSilver  = 0x8000,

        Black       = 0x00010000,
        White       = 0x00020000,
        Black2      = 0x00040000,
        White2      = 0x00080000,

        X           = 0x00100000,
        Y           = 0x00200000,
        OmegaRuby   = 0x00400000,
        AlphaSapphire = 0x00800000,

        Sun         = 0x01000000,
        Moon        = 0x02000000,
        UltraSun    = 0x04000000,
        UltraMoon   = 0x08000000,

        LGPikachu   = 0x10000000,
        LGEevee     = 0x20000000,

        Sword       = 0x40000000,
        Shield      = 0x80000000
    }

    public enum Acquisition : int
    {
        Unattainable,   // Unavailable in this game
        Normal,         // Starter, wild, NPC trade, gift or evolvable through level or stone
        Special,        // Requires friendship, move, location, time, a held item, or specific gender
        Breed,          // Requires breeding
        Trade,          // Requires trade/dualslot, be it for any access or evolution
        Raid,           // Requires a raid battle (Sword & Shield only)
        Event           // Requires an event
    }

    public static class PokemonAccess
    {
        public static GameVersion versionRules = GameVersion.Sun | GameVersion.Moon;
        public static string versionString
        {
            get
            {
                string s = "Game Versions: ";
                for (int v = 0; v < VersionCount; v++)
                {
                    if (GameIsInRules((GameVersion)(1 << v)))
                        s += ((GameVersion)(1 << v)).ToString() + ", ";
                }
                s = s.Substring(0, s.Length - 2);
                return s;
            }
        }

        private static string[] methodStrings = new string[6]
        {
            "Normal (Starter, wild, NPC trade, gift, evolvable by level/stone, time of day catch)",
            "Special (Friendship, move, location, timed evolution, held item, gender, day of week catch)",
            "Breeding",
            "Trading/Transferring",
            "Raid Battle",
            "Event"
        };

        public static string rulesString
        {
            get
            {
                int ruleLevel = (int)gameRules;
                string s = "Rules:\n";

                for (int i = 0; i < ruleLevel; i++)
                {
                    s += String.Format("- {0}\n", methodStrings[i]);
                }
                s += String.Format("- Max Legendaries: {0}\n- Shuffle Alolan Forms: {1}", maxLegendaries, shuffleAlolanForms);
                return s;
            }
        }

        public static int numVersionsInRules
        {
            get
            {
                int v = 0;
                GameVersion currentVersion;
                for (int i=0; i < VersionCount; i++)
                {
                    currentVersion = (GameVersion)(1 << i);
                    if (GameIsInRules(currentVersion))
                        v++;
                }

                return v;
            }
        }

        public static readonly int VersionCount = 32;
        public static int maxLegendaries = 3;
        public static bool shuffleAlolanForms = false;
        public static bool evenSplit = true;
        public static List<Pokemon> Pokedex = new List<Pokemon>();
        public static bool GameIsInRules(GameVersion game)
        {
            return (game & versionRules) != 0;
        }

        public static Acquisition gameRules = Acquisition.Special;

        public static bool AcquisitionIsInRules(Acquisition a)
        {
            if (a == Acquisition.Unattainable)
                return false;
            if ((int)a <= (int)gameRules)
                return true;
            return false;
        }

        public static Acquisition GetMethod(Pokemon p, GameVersion version)
        {
            int i = (int)Math.Log((uint)version, 2);
            return p.methods[i];
        }

        public static void MarkGameAccess(Pokemon p)
        {
            GameVersion thisVersion;
            for (int v = 0; v < VersionCount; v++)
            {
                thisVersion = (GameVersion)(1 << v);
                if (GameIsInRules(thisVersion))
                {
                    if (AcquisitionIsInRules(p.methods[v]))
                    {
                        p.gameAccess = p.gameAccess | thisVersion;
                        if (!RegionalPokedex.Contains(p))
                            RegionalPokedex.Add(p);
                    }
                }

            }
        }

        public static List<Pokemon> RegionalPokedex = new List<Pokemon>();
    }

    public class PokemonOverride
    {
        public readonly string displayName;
        private List<int> dexNumbers;

        public OverrideType PokemonHasOverride(Pokemon p)
        {
            if (dexNumbers.Contains(p.number))
                return OverrideType.Added;
            if (dexNumbers.Contains(-p.number))
                return OverrideType.Removed;
            return OverrideType.Unchanged;
        }
    }

    public enum OverrideType
    {
        Unchanged,
        Added,
        Removed
    }
}
