using FlowerRpg.Characters;
using FlowerRpg.Classes;
using FlowerRpg.Effects;
using FlowerRpg.Fantasy.Classes;
using FlowerRpg.Fantasy.Effects;
using FlowerRpg.Fantasy.Races;
using FlowerRpg.Interfaces;

namespace FlowerRpg.Fantasy.Characters;

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
        
        foreach (var effect in Effects)
        {
            ApplyEffect(effect);
        }
        
        SetRace(race);
        SetAllClasses();
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
        @class.RemoveSelf();
        OnClassRemoved?.Invoke(@class);
    }

    public bool HasClass(BaseClass @class) => Classes.Contains(@class);

    public void SetRace(BaseRace race)
    {
        if (Race != null) Race.RemoveSelf();
        Race = race;
        Race.Target = this;
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
        effect.Apply();
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