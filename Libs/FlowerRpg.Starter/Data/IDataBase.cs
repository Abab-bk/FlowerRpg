using FlowerRpg.Items;

namespace FlowerRpg.Starter.Data;

public interface IDataBase
{
    public IItem GetItem(int id);
}