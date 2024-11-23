using FlowerRpg.Fantasy.Classes;
using FlowerRpg.Fantasy.Inventory;
using FlowerRpg.Fantasy.Items.Affixes;
using FlowerRpg.Stats;

namespace FlowerRpg.Fantasy.Items;

public class AffixItem(ItemTemplate itemTemplate) : Item(itemTemplate)
{
    public List<Affix> Affixes { get; set; } = [];
    protected bool Active { get; set; }
    
    public void AddAffix(Affix affix, IEnumerable<IStat> stats)
    {
        Affixes.Add(affix);
        ApplyAffixes(stats);
    }
    
    public void RemoveAffix(Affix affix, IEnumerable<IStat> stats)
    {
        Affixes.Remove(affix);
        if (!Active) return;
        affix.Remove(stats);
    }
    
    protected void ApplyAffixes(IEnumerable<IStat> stats)
    {
        if (!RemoveAffixes(stats)) return;
        
        foreach (var affix in Affixes)
        {
            affix.Apply(stats);
        }
    }
    
    protected bool RemoveAffixes(IEnumerable<IStat> stats)
    {
        if (!Active) return false;
        foreach (var affix in Affixes)
        {
            affix.Remove(stats);
        }
        return true;
    }
}