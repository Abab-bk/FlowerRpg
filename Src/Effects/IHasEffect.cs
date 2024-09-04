namespace FlowerRpg.Effects;

public interface IHasEffect
{
    public Action<Effect> OnEffectAdded { get; set; }
    public List<Effect> Effects { get; }
    public void AddEffect(Effect effect);
    public bool RemoveEffect(Effect effect);
    public bool HasEffect(Effect effect);
    public void ClearEffects();
}