namespace London;

using NSubstitute;

public class CustomerTests
{
    [Fact]
    public void Purchase_succeeds_when_enough_inventory()
    {
        // Arrange
        var storeMock = Substitute.For<IStore>();
        storeMock.GetInventory(Product.Book)
            .Returns(10);
        var customer = new Customer();

        // Act
        bool result = customer.Purchase(storeMock, Product.Book, 10);

        // Assert
        Assert.True(result);
        storeMock.Received(1)
            .RemoveInventory(Product.Book, 10);
    }

    [Fact]
    public void Purchase_fails_when_not_enough_inventory()
    {
        // Arrange
        var storeMock = Substitute.For<IStore>();
        storeMock.GetInventory(Product.Book)
            .Returns(10);
        var customer = new Customer();

        // Act
        bool result = customer.Purchase(storeMock, Product.Book, 11);

        // Assert
        Assert.False(result);
        storeMock.DidNotReceive()
            .RemoveInventory(Product.Book, 11);
    }

    [InlineData(0)]
    [InlineData(-1)]
    [Theory]
    public void Purchase_fails_when_quantity_is_zero_or_negative(int quantity)
    {
        // Arrange
        var storeMock = Substitute.For<IStore>();
        storeMock.GetInventory(Product.Book)
            .Returns(10);
        var customer = new Customer();

        // Act
        bool result = customer.Purchase(storeMock, Product.Book, quantity);

        // Assert
        Assert.False(result);
        storeMock.DidNotReceive()
            .RemoveInventory(Product.Book, quantity);
    }
}
