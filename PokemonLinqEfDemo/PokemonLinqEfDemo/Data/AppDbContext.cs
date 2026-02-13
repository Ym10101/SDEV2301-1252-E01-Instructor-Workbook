using Microsoft.EntityFrameworkCore;
using PokemonLinqEfDemo.Data;

namespace PokemonLinqEfCore.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<PokemonEntity> PokemonEntitys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var dbPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "trainerdex.db");
            dbPath = Path.GetFullPath(dbPath);

            options.UseSqlite($"Data Source={dbPath}");
        }
    }
}