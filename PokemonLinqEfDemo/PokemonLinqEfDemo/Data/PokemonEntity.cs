using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonLinqEfDemo.Data
{
    public class PokemonEntity
    {
        public int Id { get; set; } // Database Primary Key
        public int Dex { get; set; }
        public string Name { get; set; }
        public string Type1 { get; set; }
        public string? Type2 { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int Total { get; set; }
        public bool IsLegendary { get; set; }
    }
}
