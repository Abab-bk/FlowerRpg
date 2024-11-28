namespace FlowerRpg.Combat;

public struct Damage
{
    public int Type { get; set; }
    public float Value { get; set; }
    
    public Damage() { }

    public Damage(int type, float value)
    {
        Type = type;
        Value = value;
    }
}