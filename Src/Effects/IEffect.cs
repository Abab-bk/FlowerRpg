using FlowerRpg.Stats;

namespace FlowerRpg.Effects;

public interface IEffect
{
    public float Potency { get; set; }
    public Stat Data { get; }
    
    public void Apply();
    public void Remove();
}