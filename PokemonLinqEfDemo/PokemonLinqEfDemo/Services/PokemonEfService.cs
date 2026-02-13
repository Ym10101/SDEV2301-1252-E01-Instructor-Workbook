using PokemonLinqEfCore.Data;
using PokemonLinqEfDemo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonLinqEfDemo.Services
{
    public class PokemonEfService
    {
        private readonly AppDbContext _context;

        public PokemonEfService(AppDbContext context)
        {
            _context = context; 
        }

        // Copy methods from PokemonLinqService and change `_pokedex` to `_context.PokemonEntitys`
        public List<string> GetWaterNames() =>
            _context.PokemonEntitys
                .Where(p => p.Type1 == "Water")
                .Select(p => p.Name)
                .ToList();

        public List<NameSpeed> GetFastPokemon(int minSpeed) =>
            _context.PokemonEntitys
                .Where(p => p.Speed >= minSpeed)
                .OrderByDescending(p => p.Speed)
                .ThenBy(p => p.Name)
                .Select(p => new NameSpeed(p.Name, p.Speed))
                .ToList();

        public List<FastFlag> GetFastFlags(int fastSpeed = 90) =>
            _context.PokemonEntitys
                .Select(p => new FastFlag(p.Name, p.Speed >= fastSpeed))
                .ToList();

        public List<GroupCount> CountByType1() =>
            _context.PokemonEntitys
                .GroupBy(p => p.Type1)
                .Select(g => new GroupCount(g.Key, g.Count()))
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Key)
                .ToList();

        public List<NameTotal> GetLegendaryByTotalDesc() =>
            _context.PokemonEntitys
                .Where(p => p.IsLegendary)
                .OrderByDescending(p => p.Total)
                .Select(p => new NameTotal(p.Name, p.Total))
                .ToList();
    }
}
