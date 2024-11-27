using FlowerRpg.Characters;
using FlowerRpg.Starter.Stats;

namespace FlowerRpg.Starter.Characters;

public class Character : ICharacter
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public CharacterStats Stats { get; set; } = new ();
}