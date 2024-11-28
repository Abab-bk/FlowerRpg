using FlowerRpg.Starter.Characters;
using FlowerRpg.Starter.Data;

namespace FlowerRpg.Starter;

public sealed class RpgManager
{
    public IDataBase DataBase { get; private set; }
    public Character Player { get; set; }

    public static RpgManager? Instance { get; private set; }
    
    public RpgManager(IDataBase dataBase, Character player)
    {
        Instance = this;
        Player = player;
        DataBase = dataBase;
    }
}