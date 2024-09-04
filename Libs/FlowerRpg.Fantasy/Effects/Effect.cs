using FlowerRpg.Stats;

namespace FlowerRpg.Fantasy.Effects;

public class Effect : FlowerRpg.Effects.EffectAbstract
{
    public EffectType EffectType { get; set; }
    public IModifier<IReadOnlyValue<float>, float> GetModifier()
    {
        return EffectType.GetModifier(Potency);
    }
}