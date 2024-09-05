namespace FlowerRpg.Classes;

public interface IHasClass<T> where T : IClass
{
    public event Action<T> OnClassAdded;
    public event Action<T> OnClassRemoved;
    public List<T> Classes { get; }
    
    public void AddClass(T @class);
    public void RemoveClass(T @class);
    public bool HasClass(T @class);
}