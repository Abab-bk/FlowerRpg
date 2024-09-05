using FlowerRpg.Interfaces;

namespace FlowerRpg.Characters;

/// <summary>
/// A character.
/// </summary>
public interface ICharacter<T> : IHasStats<T> where T : IStatsData
{
    public int Id { get; set; }
    public string Name { get; set; }
}