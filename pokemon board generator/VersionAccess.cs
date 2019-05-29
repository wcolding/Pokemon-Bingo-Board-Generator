using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_board_generator
{
    enum GameVersion: uint
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

    enum EvolveType : int
    {
        Level,
        Stone,
        Trading,
        Friendship,
        Move,
        Location,
        Time,
        ItemHold,
        Gender,
        Version
    }
}
