namespace FlowerRpg.Stats.Modifiers;

public class Modifier(
    float value,
    ModifierType type,
    int order = 0,
    Object source = null
    ) : IModifier
{
    public Modifier(ModifierType type, float value, int order, object source)
        : this(value, type, order, source) {}
    
    public Modifier(ModifierType type, float value, int order)
        : this(value, type, order) {}
    
    public Modifier(ModifierType type, float value, object source)
        : this(value, type, 0, source) {}
    
    public Modifier(ModifierType type, float value)
        : this(value, type) {}
    
    public float Value { get; } = value;
    public Object Source { get; } = source;
    public ModifierType Type { get; } = type;

    public virtual float GetValue(float baseValue)
    {
        switch (Type)
        {
            case ModifierType.Flat:
                return Value;
            case ModifierType.PercentAdd:
                return Value;
            case ModifierType.PercentMult:
                return Value;
            default:
                return baseValue;
        }
    }

    public int Order { get; } = order;
}