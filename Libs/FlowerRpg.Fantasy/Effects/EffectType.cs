using System.Numerics;
using FlowerRpg.Effects;
using FlowerRpg.Fantasy.Classes;
using FlowerRpg.Stats;

namespace FlowerRpg.Fantasy.Effects;

public class EffectType(Func<CharacterStats, IModifiable<float>> data)
    : IEffectType<CharacterStats>
{
    public Func<CharacterStats, IModifiable<float>> Data => data;

    private IModifier<IReadOnlyValue<float>, float> _data;
    
    public IModifier<IReadOnlyValue<float>, float> GetModifier(float value)
    {
        if (_data == null)
        {
            _data = Modifier.Plus(value);
        }
        
        return _data;
    }
}