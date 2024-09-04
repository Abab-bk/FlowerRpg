using FlowerRpg.Effects;
using FlowerRpg.Fantasy.Classes;
using FlowerRpg.Stats;

namespace FlowerRpg.Fantasy.Effects;

public class EffectType(Func<CharacterStats, IPriorityCollection<IModifier<float>>> data)
    : IEffectType<CharacterStats>
{
    public Func<CharacterStats, IPriorityCollection<IModifier<float>>> Data => data;
}