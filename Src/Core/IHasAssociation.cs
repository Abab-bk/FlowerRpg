namespace FlowerRpg.Core;
public interface IHasAssociation
{ 
    public int AssociatedId { get; }
    public int AssociatedValue { get; }
}