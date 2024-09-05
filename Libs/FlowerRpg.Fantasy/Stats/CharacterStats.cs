using FlowerRpg.Fantasy.Combat;
using FlowerRpg.Interfaces;
using FlowerRpg.Stats;

namespace FlowerRpg.Fantasy.Classes;

public class CharacterStats : IStatsData
{
    public readonly Stat
        Damage = new Stat(2f, (int)BasicDamageType.Physical),
        Defence = new Stat(1f, (int)BasicDamageType.Physical),
        Level = new Stat(1f, -1),
        Health = new Stat(100f, -1),
        Mana = new Stat(100f, -1),
        Strength = new Stat(0f, -1),
        Dexterity = new Stat(0f, -1),
        Constitution = new Stat(0f, -1),
        Intelligence = new Stat(0f, -1),
        Wisdom = new Stat(0f, -1),
        Charisma = new Stat(0f, -1);

    public Stat[] GetDefenseStats()
    {
        return [Defence];
    }
    
    public Stat[] GetDamageStats()
    {
        return [Damage];
    }
}