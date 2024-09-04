using FlowerRpg.Effects;
using FlowerRpg.Interfaces;

namespace FlowerRpg.Fantasy.Classes.Races;

public class Human : IRace
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = "Human";

    public Action<EffectAbstract> OnEffectAdded { get; set; }

    public List<EffectAbstract> Effects { get; private set; }

    public void AddEffect(EffectAbstract effectAbstract)
    {
        Effects.Add(effectAbstract);
        OnEffectAdded?.Invoke(effectAbstract);
    }

    public bool RemoveEffect(EffectAbstract effectAbstract)
    {
        if (Effects.Remove(effectAbstract))
        {
            OnEffectAdded?.Invoke(effectAbstract);
            return true;
        }

        return false;
    }

    public bool HasEffect(EffectAbstract effectAbstract)
    {
        return Effects.Contains(effectAbstract);
    }

    public void ClearEffects()
    {
        Effects.Clear();
    }
}