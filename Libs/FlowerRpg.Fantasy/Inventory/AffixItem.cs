using FlowerRpg.Fantasy.Classes;
using FlowerRpg.Fantasy.Classes.Affixes;
using FlowerRpg.Fantasy.Classes.Characters;

namespace FlowerRpg.Fantasy.Inventory;

public class AffixItem(ItemTemplate itemTemplate) : Item(itemTemplate)
{
    public List<Affix> Affixes { get; set; } = [];
    protected bool Active { get; set; }
    
    public void AddAffix(Affix affix, CharacterStats stats)
    {
        Affixes.Add(affix);
        ApplyAffixes(stats);
    }
    
    public void RemoveAffix(Affix affix, CharacterStats stats)
    {
        Affixes.Remove(affix);
        if (!Active) return;
        affix.Remove(stats);
    }
    
    protected void ApplyAffixes(CharacterStats stats)
    {
        if (!RemoveAffixes(stats)) return;
        
        foreach (var affix in Affixes)
        {
            affix.Apply(stats);
        }
    }
    
    protected bool RemoveAffixes(CharacterStats stats)
    {
        if (!Active) return false;
        foreach (var affix in Affixes)
        {
            affix.Remove(stats);
        }
        return true;
    }
}