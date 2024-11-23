namespace FlowerRpg.Stats;

public interface IStat
{
    public Action<float> OnValueChanged { get; }
    public float Value { get; }
    
    public void AddModifier(Modifier modifier);
    public void RemoveModifier(Modifier modifier);
    public void RemoveAllModifiers();
    public void RemoveAllModifiersFromSource(object source);
    
    public IEnumerable<Modifier> GetModifiers();
}