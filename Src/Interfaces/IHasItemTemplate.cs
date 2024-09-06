using FlowerRpg.Items;

namespace FlowerRpg.Interfaces;

public interface IHasItemTemplate<out T> where T : IItemTemplate
{
    public T Template { get; }
}