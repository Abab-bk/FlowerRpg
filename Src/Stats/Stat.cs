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
        float finalValue = BaseValue;
        float sumPercentAdd = 0;
 
        for (int i = 0; i < Modifiers.Count; i++)
        {
            var mod = Modifiers[i];
            
            switch (mod.Type)
            {
                case ModifierType.Flat:
                    finalValue += mod.Value;
                    break;
                case ModifierType.PercentAdd:
                    sumPercentAdd += mod.Value;
 
                    if (i + 1 >= Modifiers.Count || Modifiers[i + 1].Type != ModifierType.PercentAdd)
                    {
                        finalValue *= 1 + sumPercentAdd;
                        sumPercentAdd = 0;
                    }
                    
                    break;
                case ModifierType.PercentMult:
                    finalValue *= 1 + mod.Value;
                    break;
            }
        }
 
        return (float)Math.Round(finalValue, 4);
    }

    public bool HasModifier(Modifier modifier) => Modifiers.Contains(modifier);

    public void AddModifier(Modifier modifier)
    {
        Modifiers.Add(modifier);
        Modifiers.Sort(CompareModifierOrder);
        IsDirty = true;
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