using FlowerRpg.Fantasy.Classes.Affixes;

namespace FlowerRpg.Fantasy.Inventory;

public class AffixItem(ItemTemplate itemTemplate) : Item(itemTemplate)
{
    public List<Affix> Affixes { get; set; } = new ();
    
    public void AddAffix(Affix affix)
    {
        Affixes.Add(affix);
    }
    
    public void RemoveAffix(Affix affix)
    {
        Affixes.Remove(affix);
    }
}