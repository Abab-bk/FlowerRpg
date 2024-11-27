using FlowerRpg.Starter.Data;

namespace FlowerRpg.Starter;

public sealed class RpgManager
{
    public IDataBase DataBase { get; private set; }

    public static RpgManager Instance { get; private set; }
    
    public void Setup(
        IDataBase dataBase
    )
    {
        Instance = this;
        DataBase = dataBase;
    }
}