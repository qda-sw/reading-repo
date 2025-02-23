namespace Classic;

public class Store
{
    private readonly Dictionary<Product, int> _inventory = new();
    public void AddInventory(Product product, int quantity)
    {
        if (quantity <= 0)
        {
            throw new InvalidOperationException("Quantity must be greater than zero");
        }
        if (!_inventory.ContainsKey(product))
        {
            _inventory[product] = 0;
        }
        _inventory[product] += quantity;
    }

    public int GetInventory(Product product)
    {
        bool found = _inventory.TryGetValue(product, out int quantity);
        return found ? quantity : 0;
    }

    public void RemoveInventory(Product product, int quantity)
    {
        if (quantity <= 0)
        {
            throw new InvalidOperationException("Quantity must be greater than zero");
        }
        int currentInventory = GetInventory(product);
        if (currentInventory < quantity)
        {
            throw new InvalidOperationException("Not enough inventory");
        }
        
        _inventory[product] -= quantity;
    }
}