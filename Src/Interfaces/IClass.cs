using FlowerRpg.Effects;

namespace FlowerRpg.Interfaces;

public interface IClass : IHasEffect<EffectAbstract>
{
    public int Id { get; set; }
    public string Name { get; set; }
}