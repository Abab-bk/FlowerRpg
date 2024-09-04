using FlowerRpg.Interfaces;
using FlowerRpg.Stats;

namespace FlowerRpg.Fantasy.Classes;

public class CharacterStats : IStatsData
{
    public Stat<float>
        Health = new Stat<float>(100f),
        Mana = new Stat<float>(100f),
        Strength = new Stat<float>(0f),
        Dexterity = new Stat<float>(0f),
        Constitution = new Stat<float>(0f),
        Intelligence = new Stat<float>(0f),
        Wisdom = new Stat<float>(0f),
        Charisma = new Stat<float>(0f);
}