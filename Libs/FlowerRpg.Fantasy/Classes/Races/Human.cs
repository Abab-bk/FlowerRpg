using FlowerRpg.Interfaces;

namespace FlowerRpg.Fantasy.Classes.Races;

public class Human : IRace
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = "Human";
}