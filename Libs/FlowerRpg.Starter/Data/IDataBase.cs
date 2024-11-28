using FlowerRpg.Core;
using FlowerRpg.Items;
using FlowerRpg.Quests;
using FlowerRpg.Starter.Characters;
using FlowerRpg.Starter.Loot;

namespace FlowerRpg.Starter.Data;

public interface IDataBase
{
    public IItem GetItem(int id);
    public IQuest GetQuest(int id);
    public Reward GetReward(int id);
    public Character GetCharacter(int id);
    public LootTable GetLootTable(int id);
}