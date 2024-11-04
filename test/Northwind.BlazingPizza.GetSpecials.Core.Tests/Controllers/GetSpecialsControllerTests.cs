namespace Northwind.BlazingPizza.GetSpecials.Core.Tests.Controllers;
public class GetSpecialsControllerTests
{
    [Fact]
    public async Task ShouldInvokeInputPortAndReturnPizzaSpecials()
    {
        // Arrange
        var inputPort = Substitute.For<IGetSpecialsInputPort>();
        var outputPort = Substitute.For<IGetSpecialsOutputPort>();

        var expectedSpecials = new List<PizzaSpecialDto>
        {
            new PizzaSpecialDto(3, "s3", 30, "d3", "i3"),
            new PizzaSpecialDto(4, "s4", 40, "d4", "i4"),
            new PizzaSpecialDto(5, "s5", 50, "d5", "i5")
        };
        outputPort.PizzaSpecials.Returns(expectedSpecials);
        inputPort.GetSpecialsAsync().Returns(Task.CompletedTask);

        var controller = new GetSpecialsController(inputPort, outputPort);

        // Act
        var returnedSpecials = await controller.GetSpecialsAsync();

        // Assert
        await inputPort.Received(1).GetSpecialsAsync();
        Assert.Equal(expectedSpecials, returnedSpecials);
    }
}
