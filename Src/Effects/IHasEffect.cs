namespace FlowerRpg.Effects;

public interface IHasEffect
{
    public List<IEffect> Effects { get; }
    public void AddEffect(IEffect effect);
    public bool RemoveEffect(IEffect effect);
    public bool HasEffect(IEffect effect);
    public void ClearEffects();
}