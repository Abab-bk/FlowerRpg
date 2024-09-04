namespace FlowerRpg.Effects;

public interface IEffect
{
    public int EffectType { get; set; }
    public float Potency { get; set; }
}