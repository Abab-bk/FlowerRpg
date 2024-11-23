using FlowerRpg.Stats;

namespace FlowerRpg.Effects;

public interface IEffect
{
    public float Potency { get; set; }
    public IStat Data { get; }
    
    public void Apply();
    public void Remove();
}