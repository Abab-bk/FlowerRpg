using FastEnumUtility;
using FlowerRpg.Stats;

namespace FlowerRpg.Starter.Stats;

public class CharacterStats : IStats
{
    private readonly Vital[] _vitals;
    private readonly IStat[] _stats;
    
    public CharacterStats(StatsConfig config)
    {
        _vitals = new Vital[FastEnum.GetValues<VitalType>().Length];
        _stats = new IStat[FastEnum.GetValues<StatType>().Length];
        
        Vital NewVital(VitalType type, Stat maxValue, float minValue = 0f, float ratio = 1f)
        {
            var vital = new Vital(maxValue, 0f, 0, true, ratio);
            _vitals[(int)type] = vital;
            return vital;
        }

        Stat NewStat(StatType type, float value)
        {
            var stat = new Stat(value);
            _stats[(int)type] = stat;
            return stat;
        }

        NewStat(StatType.Damage, config.Damage);
        NewStat(StatType.Defense, config.Defense);
        NewStat(StatType.Level, config.Level);

        var maxHealth = NewStat(StatType.MaxHealth, config.MaxHealth);

        NewVital(VitalType.Health, maxHealth);
    }

    
    public IStat GetStat(StatType statType) => GetStat((int)statType);
    public Vital GetVital(VitalType statType) => GetVital((int)statType);
    public Vital GetVital(int statType) => _vitals[statType]; 
    public IStat GetStat(int statType) => _stats[statType];
}