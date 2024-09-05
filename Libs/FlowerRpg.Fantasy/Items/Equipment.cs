using FlowerRpg.Fantasy.Classes;
using FlowerRpg.Fantasy.Inventory;

namespace FlowerRpg.Fantasy.Items;

public class Equipment(ItemTemplate itemTemplate) : AffixItem(itemTemplate)
{
    public void Equip(CharacterStats stats)
    {
        base.Use();
        Active = true;
        ApplyAffixes(stats);
    }

    public void Release(CharacterStats stats)
    {
        RemoveAffixes(stats);
        Active = false;
    }
}