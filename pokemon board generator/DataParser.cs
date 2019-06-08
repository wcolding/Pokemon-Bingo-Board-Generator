using Microsoft.VisualBasic.FileIO;
using System;
using System.Net;

namespace pokemon_board_generator
{
    class DataParser
    {
        string path = "Pokedex.csv";
        TextFieldParser csv;
        int lineLength = PokemonAccess.VersionCount + 3;
        int entries = 5;
        string[] buffer;
        
        public DataParser()
        {
            UpdatePokedex();
            
            csv = new TextFieldParser(path);
            csv.TextFieldType = FieldType.Delimited;
            csv.SetDelimiters(",");

            buffer = new string[lineLength];
            buffer = csv.ReadFields();  // Reads header
            for (int i=0; i < entries; i++)
                LineToPokemon();

            csv.Dispose();
        }

        private Pokemon LineToPokemon()
        {
            buffer = csv.ReadFields();
            try
            {
                Pokemon currentPokemon = new Pokemon(Convert.ToInt32(buffer[0]), buffer[1], Convert.ToInt32(buffer[2]));
                Console.WriteLine("#{0:D3} {1}\n", currentPokemon.number, currentPokemon.name);
                for (int i = 3; i < lineLength; i++)
                {
                    Acquisition a = (Acquisition)Convert.ToInt32(buffer[i]);
                    currentPokemon.methods[i - 3] = a;
                    GameVersion b = (GameVersion)(1 << (i - 3));
                    if (PokemonAccess.GameIsInRules(b))
                        Console.WriteLine("{0} ({1})", a, b);
                }
                Console.WriteLine();

                return currentPokemon;
            }
            catch
            {
                throw new Exception("Invalid line detected! Unable to parse Pokemon. Check .csv format.");
            }
            
        }

        public void UpdatePokedex()
        {
            WebClient updater = new WebClient();
            try
            {
                updater.DownloadFile("https://docs.google.com/spreadsheets/d/1bTHhY5o741buGHWQP5t4vTVEYa0_NmOtYORDnUgTGjU/export?format=csv", path);
            }
            catch
            {
                Console.WriteLine("Unable to update Pokedex from Google Sheet");
            }
        }

        
    }
}
