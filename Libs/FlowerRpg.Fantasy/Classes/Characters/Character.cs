using FlowerRpg.Effects;
using FlowerRpg.Fantasy.Effects;
using FlowerRpg.Interfaces;
using FlowerRpg.Stats;

namespace FlowerRpg.Fantasy.Classes.Characters;

public class Character(List<IClass> classes, IRace race, List<Effect> effects) : ICharacter<CharacterStats>
{
    public Action<Effect> OnEffectAdded { get; set; }
    public event Action<IClass> OnClassAdded;
    public event Action<IClass> OnClassRemoved;
    public event Action<IRace> OnRaceSet;
    
    public int Id { get; set; } = 0;
    public string Name { get; set; } = "";
    
    public List<IClass> Classes { get; } = classes;
    public IRace Race { get; private set; } = race;
    public List<Effect> Effects { get; } = effects;
    
    public CharacterStats StatsData { get; } = new CharacterStats();
    
    public void AddClass(IClass @class)
    {
        Classes.Add(@class);
        OnClassAdded?.Invoke(@class);
    }

    public void RemoveClass(IClass @class)
    {
        Classes.Remove(@class);
        OnClassRemoved?.Invoke(@class);
    }

    public bool HasClass(IClass @class) => Classes.Contains(@class);

    public void SetRace(IRace race)
    {
        Race = race;
        OnRaceSet?.Invoke(race);
    }
    
    public void AddEffect(Effect effect)
    {
        Effects.Add(effect);
        OnEffectAdded?.Invoke(effect);

        switch (effect.EffectType)
        {
            case EffectType.HealthBonusFlat:
                StatsData.Health.flat.modifiers.Add(Modifier.Plus(effect.Potency));
                break;
            case EffectType.HealthBonusPercentAdd:
                StatsData.Health.percentAdd.modifiers.Add(Modifier.Plus(effect.Potency));
                break;
            case EffectType.HealthBonusPercentMul:
                StatsData.Health.percentTimes.modifiers.Add(Modifier.Plus(effect.Potency));
                break;
        }
    }

    public bool RemoveEffect(Effect effect)
    {
        if (Effects.Remove(effect)) return true;
        return false;
    }

    public bool HasEffect(Effect effect) => Effects.Contains(effect);

    public void ClearEffects()
    {
        Effects.Clear();
    }
}