using FlowerRpg.Stats;

namespace FlowerRpg.Fantasy.Effects;

public class Effect : FlowerRpg.Effects.EffectAbstract
{
    public EffectType EffectType { get; set; }
    
    public void Apply()
    {
        EffectType.Apply(Potency);
    }
}