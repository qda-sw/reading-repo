namespace Classic;

public class CustomerTests
{
    [Fact]
    public void Purchase_succeeds_when_enough_inventory()
    {
        // Arrange
        var store = new Store();
        store.AddInventory(Product.Book, 10);
        var customer = new Customer();

        // Act
        bool result = customer.Purchase(store, Product.Book, 10);

        // Assert
        Assert.True(result);
        Assert.Equal(0, store.GetInventory(Product.Book));
    }

    [Fact]
    public void Purchase_fails_when_not_enough_inventory()
    {
        // Arrange
        var store = new Store();
        store.AddInventory(Product.Book, 10);
        var customer = new Customer();

        // Act
        bool result = customer.Purchase(store, Product.Book, 11);

        // Assert
        Assert.False(result);
        Assert.Equal(10, store.GetInventory(Product.Book));
    }

    [InlineData(0)]
    [InlineData(-1)]
    [Theory]
    public void Purchase_fails_when_quantity_is_zero_or_negative(int quantity)
    {
        // Arrange
        var store = new Store();
        store.AddInventory(Product.Book, 10);
        var customer = new Customer();

        // Act
        bool result = customer.Purchase(store, Product.Book, quantity);

        // Assert
        Assert.False(result);
        Assert.Equal(10, store.GetInventory(Product.Book));
    }
}