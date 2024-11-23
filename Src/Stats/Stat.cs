namespace FlowerRpg.Stats;

public class Stat : IStat
{
    public Action<float> OnValueChanged { get; }
    public float Value {
        get
        {
            if (_isDirty)
            {
                _value = CalculateValue();
                OnValueChanged(_value);
                _isDirty = false;
            }
            return _value;
        }
    }
    
    private float _value;
    
    public List<Modifier> Modifiers { get; } = new ();
    
    private bool _isDirty;

    private float CalculateValue()
    {
        var value = Value;
        
        foreach (var modifier in Modifiers)
        {
            switch (modifier.Type)
            {
                case ModifierType.Flat:
                    value += modifier.Value;
                    break;
                case ModifierType.PercentAdd:
                    value += value * modifier.Value;
                    break;
                case ModifierType.PercentMult:
                    value *= 1 + modifier.Value;
                    break;
            }
        }

        return value;
    }

    public void AddModifier(Modifier modifier)
    {
        Modifiers.Add(modifier);
        _isDirty = true;
    }

    public void RemoveModifier(Modifier modifier)
    {
        Modifiers.Remove(modifier);
        _isDirty = true;
    }

    public void RemoveAllModifiers()
    {
        Modifiers.Clear();
        _isDirty = true;
    }

    public void RemoveAllModifiersFromSource(object source)
    {
        Modifiers.RemoveAll(m => m.Source == source);
        _isDirty = true;
    }

    public IEnumerable<Modifier> GetModifiers() => Modifiers;
}