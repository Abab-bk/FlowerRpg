using FlowerRpg.Effects;

namespace FlowerRpg.Starter.Effects;

public class EffectManager : IHasEffect
{
    public Action<IEffect> OnEffectRemoved { get; private set; } = delegate { };
    public Action<IEffect> OnEffectAdded { get; private set; } = delegate { };
    
    public List<IEffect> Effects { get; } = new ();
    
    public void OnTick()
    {
        foreach (var effect in Effects)
        {
            effect.OnTick();
        }
    }
    
    public void AddEffect(IEffect effect)
    {
        Effects.Add(effect);
        OnEffectAdded(effect);

        effect.OnShouldRemove += () =>
        {
            RemoveEffect(effect);
        };

        effect.Apply();
    }

    public bool RemoveEffect(IEffect effect)
    {
        var result = Effects.Remove(effect);
        if (result) OnEffectRemoved(effect);
        return result;
    }

    public bool HasEffect(IEffect effect)
    {
        return Effects.Contains(effect);
    }

    public void ClearEffects()
    {
        for (var i = Effects.Count - 1; i >= 0; i--)
        {
            var effect = Effects[i];
            effect.Remove();
            Effects.RemoveAt(i);
            OnEffectRemoved(effect);
        }
    }
}