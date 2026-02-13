using PokemonLinqEfCore.Data;
using PokemonLinqEfDemo.Data;
using PokemonLinqEfDemo.Seed;
using PokemonLinqEfDemo.Services;

// LINQ on list
var pokedex = PokemonSeed.GetPokedex();
var linqService = new PokemonLinqService(pokedex);
// Continue pattern with GetFastFlags(), CountByType1(), GetLengendaryByTotalDesc()

Print("LINQ: Water Names", linqService.GetWaterNames());
Print("LINQ: Fast Pokemon (>= 90)", linqService.GetFastPokemon(90));

// EF Core SQlite 
using var context = new AppDbContext();
context.Database.EnsureCreated();

// seed if empty
if (!context.PokemonEntitys.Any())
{
    // Transform each Pokemon to a PokemonEntity
    var entities = pokedex.Select(p => new PokemonEntity
    {
        Dex = p.Dex,
        Name = p.Name,
        Type1 = p.Type1,
        Type2 = p.Type2,
        Attack = p.Attack,
        Defense = p.Defense,
        Speed = p.Speed,
        Total = p.Total,
        IsLegendary = p.IsLegendary
    });

    context.PokemonEntitys.AddRange(entities);
    context.SaveChanges();
}

var efService = new PokemonEfService(context);
// Continue pattern with GetFastFlags(), CountByType1(), GetLengendaryByTotalDesc()
Print("EF Core: Water Names", efService.GetWaterNames());
Print("EF Core: Fast Pokemon (>= 90)", efService.GetFastPokemon(90));


static void Print<T>(string title, IEnumerable<T> rows)
{
    Console.WriteLine($"\n==> {title} <==");
    foreach (var row in rows)
        Console.WriteLine(row);
}
