using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonLinqEfDemo.Domain
{
    public record NameSpeed(string Name, int Speed);
    public record NameTotal(string Name, int Total);
    public record GroupCount(string Key, int Count);
    public record FastFlag(string Name, bool IsFast);
}
