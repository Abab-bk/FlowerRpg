using FlowerRpg.Effects;

namespace FlowerRpg.Interfaces;

public interface IRace : IHasEffect
{
    public int Id { get; set; }
    public string Name { get; set; }
}