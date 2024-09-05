using FlowerRpg.Fantasy.Enums;
using FlowerRpg.Interfaces;
using FlowerRpg.Inventory;
using FlowerRpg.Items;

namespace FlowerRpg.Fantasy.Items;

public class Item(ItemTemplate itemTemplate) : IItem, IHasItemTemplate<ItemTemplate>
{
    public event Action<int> OnQuantityChanged;
    public event Action OnRemoved;
    
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Desc { get; set; } = "";
    public ItemTemplate Template { get; set; } = itemTemplate;
    IItemTemplate IHasItemTemplate<IItemTemplate>.Template => Template;

    public int Price;

    public int MaxStack
    {
        get => _maxStack;
        set
        {
            _maxStack = (int)MathF.Max(1, value);
            if (Quantity > _maxStack) Quantity = _maxStack;
        }
    }

    public int Quantity
    {
        get => _quantity;
        set
        {
            _quantity = Math.Max(0, value);
            if (_quantity <= 0) OnRemoved?.Invoke();
            OnQuantityChanged?.Invoke(value);
        }
    }

    private int _quantity = 1;
    private int _maxStack = 1;

    public Item Clone() => new Item(Template)
    {
        Price = Price,
        MaxStack = MaxStack,
        Quantity = Quantity
    };

    public bool TryAddQuantity(int amount, out int needAdded)
    {
        if (Quantity >= MaxStack)
        {
            needAdded = amount;
            return false;
        }

        if (Quantity + amount > MaxStack)
        {
            needAdded = Quantity + amount - MaxStack;
            Quantity = MaxStack;
            return true;
        }
        
        Quantity += amount;
        needAdded = 0;
        return true;
    }

    public bool AddQuantity(int amount)
    {
        return TryAddQuantity(amount, out _);
    }

    public void RemoveQuantity(int amount)
    {
        Quantity -= amount;
    }

    public bool IsEqual(Item item)
    {
        if (item.Template.ItemType == ItemType.Weapon
            || Template.ItemType == ItemType.Weapon
           )
            return false;
        return true;
    }

    public Item WithMaxStack(int maxStack)
    {
        MaxStack += maxStack;
        return this;
    }

    public virtual void Use()
    {
    }

    public virtual void Release()
    {
    }
}