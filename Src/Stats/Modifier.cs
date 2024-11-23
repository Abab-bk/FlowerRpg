namespace FlowerRpg.Stats;

public readonly struct Modifier(
    float value,
    ModifierType type,
    Object source = null
    ) : IEquatable<Modifier>
{
    public float Value { get; } = value;
    public ModifierType Type { get; } = type;
    public Object Source { get; } = source;

    public override bool Equals(object obj)
    {
        return obj is Modifier other && Equals(other);
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Value, (int)Type, Source);
    }
    
    public static bool operator ==(Modifier left, Modifier right)
    {
        return left.Equals(right);
    }
    
    public static bool operator !=(Modifier left, Modifier right)
    {
        return !(left == right);
    }

    public bool Equals(Modifier other) =>
        Value.Equals(other.Value) &&
        Type == other.Type &&
        Equals(Source, other.Source);
}