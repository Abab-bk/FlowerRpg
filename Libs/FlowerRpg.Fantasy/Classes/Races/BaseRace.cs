using FlowerRpg.Effects;
using FlowerRpg.Fantasy.Classes.Characters;
using FlowerRpg.Fantasy.Effects;
using FlowerRpg.Interfaces;
using FlowerRpg.Stats;

namespace FlowerRpg.Fantasy.Classes.Races;

public class BaseRace : IRace, IHasEffect<Effect>
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = "BaseRace";
    public Character Target;
    
    public Action<Effect> OnEffectAdded { get; set; }

    public List<Effect> Effects { get; private set; }
    
    public void AddEffect(Effect effect)
    {
        Effects.Add(effect);
        OnEffectAdded?.Invoke(effect);
    }
    
    private void ApplyEffect(Effect effect)
    {
        var modifiers = effect.EffectType.Data(Target.StatsData);
        modifiers.Add(Modifier.Plus(effect.Potency));
    }

    public bool RemoveEffect(Effect effect)
    {
        if (Effects.Remove(effect))
        {
            OnEffectAdded?.Invoke(effect);
            return true;
        }

        return false;
    }

    public bool HasEffect(Effect effect)
    {
        return Effects.Contains(effect);
    }

    public void ClearEffects()
    {
        Effects.Clear();
    }
}