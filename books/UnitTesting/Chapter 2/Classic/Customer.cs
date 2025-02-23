namespace Classic;

public class Customer
{
    public bool Purchase(Store store, Product product, int quantity)
    {
        if (quantity <= 0)
        {
            return false;
        }

        if (store.GetInventory(product) < quantity)
        {
            return false;
        }

        store.RemoveInventory(product, quantity);
        return true;
    }
}