namespace FlowerRpg.Interfaces;

/// <summary>
/// A character.
/// </summary>
public interface ICharacter
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<IClass> Classes { get; set; }
    public IRace Race { get; set; }
}