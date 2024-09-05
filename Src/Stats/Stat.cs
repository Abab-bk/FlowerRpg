using System.Collections.ObjectModel;

namespace FlowerRpg.Stats;

public class Stat
{
    public event Action<float> ValueChanged;

    public float BaseValue
    {
        get => _baseValue;
        set
        {
            if (_baseValue.Equals(value)) return;
            _baseValue = value;
            _isDirty = true;
            ValueChanged?.Invoke(Value);
        }
    }
    
    private float _baseValue;

    private bool _isDirty = true;
    private float _value;
 
    public float Value {
        get
        {
            if (!_isDirty) return _value;

            _isDirty = false;

            _value = CalculateFinalValue();
            ValueChanged?.Invoke(_value);

            return _value;
        }
    }

    private readonly List<StatModifier> _statModifiers;
    public readonly ReadOnlyCollection<StatModifier> StatModifiers;

    public Stat(float baseValue)
    {
        BaseValue = baseValue;
        _statModifiers = new List<StatModifier>();
        StatModifiers = _statModifiers.AsReadOnly();
    }
    
    public void ForceCalculate()
    {
        _isDirty = true;
        var a = Value;
    }
 
    private int CompareModifierOrder(StatModifier a, StatModifier b)
    {
        if (a.Order < b.Order)
            return -1;
        else if (a.Order > b.Order)
            return 1;
        return 0;
    }

    public void AddModifier(StatModifier mod)
    {
        _isDirty = true;
        _statModifiers.Add(mod);
        _statModifiers.Sort(CompareModifierOrder);
        ForceCalculate();
    }

    public bool HasModifier(StatModifier mod)
    {
        return _statModifiers.Contains(mod);
    }

    public bool RemoveModifier(StatModifier mod)
    {
        if (_statModifiers.Remove(mod))
        {
            _isDirty = true;
            ForceCalculate();
            return true;
        }
        return false;
    }
 
    private float CalculateFinalValue()
    {
        float finalValue = BaseValue;
        float sumPercentAdd = 0;
 
        for (int i = 0; i < _statModifiers.Count; i++)
        {
            StatModifier mod = _statModifiers[i];
 
            if (mod.Type == ModifierType.Flat)
            {
                finalValue += mod.Value;
            }
            else if (mod.Type == ModifierType.PercentAdd)
            {
                sumPercentAdd += mod.Value;
 
                if (i + 1 >= _statModifiers.Count || _statModifiers[i + 1].Type != ModifierType.PercentAdd)
                {
                    finalValue *= 1 + sumPercentAdd;
                    sumPercentAdd = 0;
                }
            }
            else if (mod.Type == ModifierType.PercentMult)
            {
                finalValue *= 1 + mod.Value;
            }
        }
 
        return (float)Math.Round(finalValue, 4);
    }
    
    public bool RemoveAllModifiersFromSource(object source)
    {
        bool didRemove = false;
 
        for (int i = _statModifiers.Count - 1; i >= 0; i--)
        {
            if (_statModifiers[i].Source == source)
            {
                didRemove = true;
                _statModifiers.RemoveAt(i);
            }
        }
        
        _isDirty = true;
        return didRemove;
    }
}