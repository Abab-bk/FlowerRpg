namespace FlowerRpg.Characters;

/// <summary>
/// A character.
/// </summary>
public interface ICharacter
{
    public int Id { get; set; }
    public string Name { get; set; }
}