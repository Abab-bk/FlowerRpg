namespace FlowerRpg.Effects;

public interface IHasEffect
{
    public Action<IEffect> OnEffectAdded { get; set; }
    public List<IEffect> Effects { get; }
    public void AddEffect(IEffect effectAbstract);
    public bool RemoveEffect(IEffect effectAbstract);
    public bool HasEffect(IEffect effectAbstract);
    public void ClearEffects();
}