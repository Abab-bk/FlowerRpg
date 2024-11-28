namespace FlowerRpg.Stats;

public interface IStats
{
    public Vital[] Vitals { get; }
    public IStat[] Stats { get; }
    
    public Vital GetVital(int statType) => Vitals[statType];
    public IStat GetStat(int statType) => Stats[statType];
}