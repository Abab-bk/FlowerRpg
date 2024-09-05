using FlowerRpg.Classes;
using FlowerRpg.Fantasy.Characters;
using FlowerRpg.Fantasy.Effects;
using FlowerRpg.Interfaces;

namespace FlowerRpg.Fantasy.Classes;

public class BaseClass : IClass, IHasEffect<Effect>
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = "BaseClass";

    public Action<Effect> OnEffectAdded { get; set; }

    public List<Effect> Effects { get; private set; } = [];

    public Character Target
    {
        get => _target;
        set
        {
            _target = value;
            foreach (var effect in Effects)
            {
                ApplyEffect(effect);
            }
        }
    }

    private Character _target;

    public void RemoveSelf()
    {
        for (int i = Effects.Count - 1; i >= 0 ; i--)
        {
            RemoveEffect(Effects[i]);
        }
    }

    public void AddEffect(Effect effect)
    {
        Effects.Add(effect);
        if (_target != null) effect.Apply();
        OnEffectAdded?.Invoke(effect);
    }

    private void ApplyEffect(Effect effect)
    {
        if (_target == null) return;
        effect.Apply();
    }

    public bool RemoveEffect(Effect effect)
    {
        if (Effects.Remove(effect))
        {
            if (_target != null) effect.Remove();
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