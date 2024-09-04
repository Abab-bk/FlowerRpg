using FlowerRpg.Effects;
using FlowerRpg.Fantasy.Classes.Classes;
using FlowerRpg.Fantasy.Classes.Races;
using FlowerRpg.Fantasy.Effects;
using FlowerRpg.Interfaces;
using FlowerRpg.Stats;

namespace FlowerRpg.Fantasy.Classes.Characters;

public class Character :
    ICharacter<CharacterStats>,
    IHasEffect<Effect>,
    IHasClass<BaseClass>,
    IHasRace<BaseRace>
{
    public Action<Effect> OnEffectAdded { get; set; }
    public event Action<BaseClass> OnClassAdded;
    public event Action<BaseClass> OnClassRemoved;
    public event Action<BaseRace> OnRaceSet;
    
    public int Id { get; set; } = 0;
    public string Name { get; set; } = "";
    public CharacterStats StatsData { get; } = new CharacterStats();
    public List<BaseClass> Classes { get; private set; }
    public BaseRace Race { get; private set; }
    public List<Effect> Effects { get; }
    
    public Character(List<BaseClass> classes, BaseRace race, List<Effect> effects)
    {
        Classes = classes;
        Effects = effects;
        
        SetRace(race);
        SetAllClasses();
        
        foreach (var effect in effects)
        {
            ApplyEffect(effect);
        }
    }

    private void SetAllClasses()
    {
        foreach (var @class in Classes)
        {
            @class.Target = this;
        }
    }

    public void AddClass(BaseClass @class)
    {
        Classes.Add(@class);
        @class.Target = this;
        OnClassAdded?.Invoke(@class);
    }

    public void RemoveClass(BaseClass @class)
    {
        Classes.Remove(@class);
        OnClassRemoved?.Invoke(@class);
    }

    public bool HasClass(BaseClass @class) => Classes.Contains(@class);

    public void SetRace(BaseRace race)
    {
        Race = race;
        race.Target = this;
        OnRaceSet?.Invoke(race);
    }
    
    public void AddEffect(Effect effect)
    {
        Effects.Add(effect);
        OnEffectAdded?.Invoke(effect);
        ApplyEffect(effect);
    }

    private void ApplyEffect(Effect effect)
    {
        var modifiers = effect.EffectType.Data(StatsData);
        modifiers.Add(Modifier.Plus(effect.Potency));
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