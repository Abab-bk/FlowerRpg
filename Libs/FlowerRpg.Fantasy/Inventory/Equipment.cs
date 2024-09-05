using FlowerRpg.Fantasy.Classes;

namespace FlowerRpg.Fantasy.Inventory;

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