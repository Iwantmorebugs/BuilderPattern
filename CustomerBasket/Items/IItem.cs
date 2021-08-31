namespace CustomerBasket.Items
{
  public interface IItem
  {
    decimal Price { get; }
    string ItemName { get; }
  }
}