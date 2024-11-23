using FlowerRpg.Stats;

namespace FlowerRpg.Effects;

public abstract class Effect(Stat stat, ModifierType modifierType) : IEffect
{
    public float Potency { get; set; }
    public IStat Data => stat;

    public abstract void Apply();

    public abstract void Remove();
}