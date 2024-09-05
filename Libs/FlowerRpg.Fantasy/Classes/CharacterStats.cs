using FlowerRpg.Interfaces;
using FlowerRpg.Stats;

namespace FlowerRpg.Fantasy.Classes;

public class CharacterStats : IStatsData
{
    public readonly Stat
        Level = new Stat(1f),
        Health = new Stat(100f),
        Mana = new Stat(100f),
        Strength = new Stat(0f),
        Dexterity = new Stat(0f),
        Constitution = new Stat(0f),
        Intelligence = new Stat(0f),
        Wisdom = new Stat(0f),
        Charisma = new Stat(0f);
}