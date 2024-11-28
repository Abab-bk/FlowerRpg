using FlowerRpg.Stats.Modifiers;

namespace FlowerRpg.Stats;

public interface IStat
{
    public Action<float> OnValueChanged { get; set; }
    public float Value { get; }
    
    public bool HasModifier(Modifier modifier);
    public bool AddModifier(Modifier modifier);
    public bool RemoveModifier(Modifier modifier);
    public void RemoveAllModifiers();
    public void RemoveAllModifiersFromSource(object source);
    
    public IEnumerable<Modifier> GetModifiers();
}