using FlowerRpg.Effects;

namespace FlowerRpg.Interfaces;

public interface IClass : IHasEffect
{
    public int Id { get; set; }
    public string Name { get; set; }
}