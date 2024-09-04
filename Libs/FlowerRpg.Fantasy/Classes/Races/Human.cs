using FlowerRpg.Effects;
using FlowerRpg.Interfaces;

namespace FlowerRpg.Fantasy.Classes.Races;

public class Human : IRace
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = "Human";

    public Action<Effect> OnEffectAdded { get; set; }

    public List<Effect> Effects { get; private set; }

    public void AddEffect(Effect effect)
    {
        Effects.Add(effect);
        OnEffectAdded?.Invoke(effect);
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