namespace FlowerRpg.Stats;

// TODO: Add Applier
public readonly struct Modifier(
    float value,
    ModifierType type,
    // Func<Stat, float, float> applier = null,
    int order = 0,
    Object source = null
    ) : IEquatable<Modifier>
{
    public Modifier(float value, ModifierType type, Object source) : this(value, type, 0, source) { }
    
    // public Modifier(float value, ModifierType type) :
    //     this(value, type, null, 0, null) { }
    //
    // public Modifier(float value, ModifierType type, int order) :
    //     this(value, type, null, order) { }
    //
    // public Modifier(float value, ModifierType type, Object source) :
    //     this(value, type, null, 0, source) { }
    //
    // public Modifier(float value, ModifierType type, int order, Object source) :
    //     this(value, type, null, order, source) { }
    
    
    // public Modifier(float value, Func<Stat, float, float> applier) :
    //     this(value, ModifierType.Flat, applier) { }
    
    // public Modifier(float value, Func<Stat, float, float> applier, int order) :
    //     this(value, ModifierType.Flat, applier, order) { }
    //
    // public Modifier(float value, Func<Stat, float, float> applier, Object source) :
    //     this(value, ModifierType.Flat, applier, 0, source) { }
    //
    // public Modifier(float value, Func<Stat, float, float> applier, int order, Object source) :
    //     this(value, ModifierType.Flat, applier, order, source) { }
    
    public float Value { get; } = value;
    public ModifierType Type { get; } = type;
    public Object Source { get; } = source;
    // public Func<Stat, float, float> Applier { get; } = applier;
    public int Order { get; } = order;

    public override bool Equals(object obj)
        => obj is Modifier other && Equals(other);
    
    public override int GetHashCode()
        => HashCode.Combine(Value, (int)Type, Source);
    
    public static bool operator ==(Modifier left, Modifier right)
        => left.Equals(right);
    
    public static bool operator !=(Modifier left, Modifier right) 
        => !(left == right);

    public bool Equals(Modifier other) =>
        Value.Equals(other.Value) &&
        Type == other.Type &&
        // Equals(Applier, other.Applier) &&
        Order == other.Order &&
        Equals(Source, other.Source);
}