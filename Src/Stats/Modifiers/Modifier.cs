namespace FlowerRpg.Stats.Modifiers;

public class Modifier(
    float value,
    ModifierType type,
    int order = 0,
    Object source = null
    ) : IModifier
{
    public Modifier(float value, ModifierType type, Object source)
        : this(value, type, 0, source) {}
    
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