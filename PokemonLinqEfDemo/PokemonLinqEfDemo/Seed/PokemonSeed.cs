using PokemonLinqEfDemo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonLinqEfDemo.Seed
{
    public static class PokemonSeed
    {
        public static List<Pokemon> GetPokedex() => new()
        {
            new(  1, "Bulbasaur",  "Grass",  "Poison", 49, 49, 45, 318, false),
            new(  4, "Charmander", "Fire",   null,     52, 43, 65, 309, false),
            new(  7, "Squirtle",   "Water",  null,     48, 65, 43, 314, false),
            new( 25, "Pikachu",    "Electric",null,    55, 40, 90, 320, false),
            new( 39, "Jigglypuff", "Normal", "Fairy",  45, 20, 20, 270, false),
            new( 52, "Meowth",     "Normal", null,     45, 35, 90, 290, false),
            new( 63, "Abra",       "Psychic",null,     20, 15, 90, 310, false),
            new( 92, "Gastly",     "Ghost",  "Poison", 35, 30, 80, 310, false),
            new( 95, "Onix",       "Rock",   "Ground", 45,160, 70, 385, false),
            new(129, "Magikarp",   "Water",  null,     10, 55, 80, 200, false),
            new(131, "Lapras",     "Water",  "Ice",    85, 80, 60, 535, false),
            new(133, "Eevee",      "Normal", null,     55, 50, 55, 325, false),
            new(143, "Snorlax",    "Normal", null,    110, 65, 30, 540, false),
            new(149, "Dragonite",  "Dragon", "Flying",134, 95, 80, 600, false),
            new(150, "Mewtwo",     "Psychic",null,    110, 90,130, 680, true),
            new(151, "Mew",        "Psychic",null,    100,100,100, 600, true),
            new(245, "Suicune",    "Water",  null,     75,115, 85, 580, true),
            new(248, "Tyranitar",  "Rock",   "Dark",  134,110, 61, 600, false),
            new(384, "Rayquaza",   "Dragon", "Flying",150, 90, 95, 680, true),
            new(445, "Garchomp",   "Dragon", "Ground",130, 95,102, 600, false),
        };
    }

}
