namespace FlowerRpg.Effects;

public interface IEffect
{
    public event Action OnShouldRemove;
    public void Apply();
    public void Remove();
    public void OnTick();
}