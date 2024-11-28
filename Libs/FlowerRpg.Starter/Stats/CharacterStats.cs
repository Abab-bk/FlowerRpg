using FlowerRpg.Stats;

namespace FlowerRpg.Starter.Stats;

public class CharacterStats : IStats
{
    public Vital[] Vitals { get; }
    public IStat[] Stats { get; }

    public bool GetVital(StatType statType, out Vital? vital)
    {
        if (!StatTypeUtil.IsVital(statType))
        {
            vital = null;
            return false;
        }

        vital = Vitals[(int)statType];
        return true;
    }
    
    public bool GetStat(StatType statType, out IStat? stat)
    {
        if (StatTypeUtil.IsVital(statType))
        {
            stat = null;
            return false;
        }

        stat = Stats[(int)statType];
        return true;
    }

    public Vital GetVital(StatType statType) => Vitals[(int)statType];
    public IStat GetStat(StatType statType) => Stats[(int)statType];
    
    public CharacterStats()
    {
        Vitals = new Vital[StatTypeUtil.GetVitalCount()];
        Stats = new IStat[StatTypeUtil.GetStatCount()];
        
        for (int i = 0; i < Vitals.Length; i++)
        {
            Vitals[i] = new Vital(new Stat(100), 0, 0, true, 1);
        }
        for (int i = 0; i < Stats.Length; i++)
        {
            Stats[i] = new Stat(100);
        }
    }
}