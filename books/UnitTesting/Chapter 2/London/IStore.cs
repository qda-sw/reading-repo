namespace London;

public interface IStore
{
    void AddInventory(Product product, int quantity);
    int GetInventory(Product product);
    void RemoveInventory(Product product, int quantity);
}
