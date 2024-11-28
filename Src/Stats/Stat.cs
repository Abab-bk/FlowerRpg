using FlowerRpg.Stats.Modifiers;

namespace FlowerRpg.Stats;

public class Stat(float baseValue) : IStat
{
    public Action<float> OnValueChanged { get; set; }
    
    public float Value {
        get
        {
            if (!IsDirty) return _value;
            
            _value = CalculateValue();
            OnValueChanged?.Invoke(_value);
            IsDirty = false;
            return _value;
        }
    }
    
    private float _value;
    
    public List<Modifier> Modifiers { get; } = new ();
    
    protected bool IsDirty { get; set; } = true;
    protected float BaseValue {
        get => _baseValue;
        set
        {
            if (_baseValue.Equals(value)) return;
            _baseValue = value;
            IsDirty = true;
            OnValueChanged?.Invoke(Value);
        }
    }
    
    private float _baseValue = baseValue;

    
    private int CompareModifierOrder(Modifier a, Modifier b)
    {
        if (a.Order < b.Order)
            return -1;
        if (a.Order > b.Order)
            return 1;
        return 0;
    }
    
    private float CalculateValue()
    {
        var finalValue = BaseValue;
        var flatValue = 0f;
        var percentAddValue = 0f;
        var percentMultValue = 1f;
        
        foreach (var modifier in Modifiers)
        {
            switch (modifier.Type)
            {
                case ModifierType.Flat:
                    flatValue += modifier.GetValue(BaseValue);
                    break;
                case ModifierType.PercentAdd:
                    percentAddValue += modifier.GetValue(BaseValue);
                    break;
                case ModifierType.PercentMult:
                    percentMultValue *= 1 + modifier.GetValue(BaseValue);
                    break;
            }
        }
        
        finalValue += flatValue;
        finalValue *= 1 + percentAddValue;
        finalValue *= percentMultValue;
        
        return (float)Math.Round(finalValue, 4);
    }

    public bool HasModifier(Modifier modifier) => Modifiers.Contains(modifier);

    public bool AddModifier(Modifier modifier)
    {
        if (modifier == null) return false;

        Modifiers.Add(modifier);
        Modifiers.Sort(CompareModifierOrder);
        IsDirty = true;
        return true;
    }

    public bool RemoveModifier(Modifier modifier)
    {
        var result = Modifiers.Remove(modifier);
        IsDirty = true;
        return result;
    }

    public void RemoveAllModifiers()
    {
        Modifiers.Clear();
        IsDirty = true;
    }

    public void RemoveAllModifiersFromSource(object source)
    {
        Modifiers.RemoveAll(m => m.Source == source);
        IsDirty = true;
    }

    public IEnumerable<Modifier> GetModifiers() => Modifiers;
}