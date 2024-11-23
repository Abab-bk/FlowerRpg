namespace FlowerRpg.Effects;

public interface IHasEffect<T> where T : IEffect
{
    public Action<T> OnEffectAdded { get; set; }
    public List<T> Effects { get; }
    public void AddEffect(T effectAbstract);
    public bool RemoveEffect(T effectAbstract);
    public bool HasEffect(T effectAbstract);
    public void ClearEffects();
}