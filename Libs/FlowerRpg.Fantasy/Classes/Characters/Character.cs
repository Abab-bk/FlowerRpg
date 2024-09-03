using FlowerRpg.Interfaces;

namespace FlowerRpg.Fantasy.Classes.Characters;

public class Character(List<IClass> classes, IRace race) : ICharacter
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = "";
    public List<IClass> Classes { get; set; } = classes;
    public IRace Race { get; set; } = race;
}