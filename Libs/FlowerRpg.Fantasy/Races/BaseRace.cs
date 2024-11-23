using FlowerRpg.Effects;
using FlowerRpg.Fantasy.Characters;
using FlowerRpg.Interfaces;

namespace FlowerRpg.Fantasy.Races;

public class BaseRace : IRace, IHasEffect<Effect>
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = "BaseRace";
    public Character Target
    {
        get => _target;
        set
        {
            if (_target != null) RemoveSelf();

            _target = value;
            foreach (var effect in Effects)
            {
                ApplyEffect(effect);
            }
        }
    }
    public Action<Effect> OnEffectAdded { get; set; }
    public List<Effect> Effects { get; private set; } = [];
    
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