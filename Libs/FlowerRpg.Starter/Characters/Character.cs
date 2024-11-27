using FlowerRpg.Characters;
using FlowerRpg.Starter.Effects;
using FlowerRpg.Starter.Stats;

namespace FlowerRpg.Starter.Characters;

public class Character : ICharacter
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public CharacterStats Stats { get; init; } = new ();
    public EffectManager EffectManager { get; init; } = new ();
}