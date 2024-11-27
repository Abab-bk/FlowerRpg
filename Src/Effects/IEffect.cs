namespace FlowerRpg.Effects;

public interface IEffect
{
    public float Potency { get; set; }
    public void Apply();
    public void Remove();
}