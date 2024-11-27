namespace FlowerRpg.Stats.Modifiers;

public interface IModifier
{
    float Value { get; }
    int Order { get; }
    object Source { get; }
    ModifierType Type { get; }
    float GetValue(float baseValue);
}