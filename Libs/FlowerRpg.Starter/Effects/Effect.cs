using FlowerRpg.Effects;
using FlowerRpg.Stats;
using FlowerRpg.Stats.Modifiers;

namespace FlowerRpg.Starter.Effects;

public struct Effect(IStat stat, Modifier modifier) : IEffect
{
    public event Action OnShouldRemove = delegate { };
    
    public void Apply()
    {
        stat.AddModifier(modifier);
    }

    public void Remove()
    {
        stat.RemoveModifier(modifier);
        OnShouldRemove();
    }

    public void OnTick()
    {
    }
}