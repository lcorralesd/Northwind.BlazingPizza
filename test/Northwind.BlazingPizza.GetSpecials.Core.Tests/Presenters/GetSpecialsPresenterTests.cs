namespace Northwind.BlazingPizza.GetSpecials.Core.Tests.Presenters;
public class GetSpecialsPresenterTests
{
    [Fact]
    public async Task HandleResultAsync_Should_Set_PizzaSpecials()
    {
        // Arrange
        IOptions<GetSpecialsOptions> options = Options.Create(new GetSpecialsOptions()
        {
            ImageUrlBase = "https://localhost:5001/images/specials/",
        });

        var presenter = new GetSpecialsPresenter(options);

        var specials = new List<PizzaSpecialDto>
        {
            new PizzaSpecialDto(3, "s3", 30, "d3", "i3"),
            new PizzaSpecialDto(4, "s4", 40, "d4", "i4"),
            new PizzaSpecialDto(5, "s5", 50, "d5", "i5")
        };

        // Act
        await presenter.HandleResultAsync(specials);

        // Assert
        Assert.Equal(specials.Count, presenter.PizzaSpecials.Count());

        for (int i = 0; i < specials.Count; i++)
        {
            var expectedImageUrl = options.Value.ImageUrlBase + "/" + specials[i].ImageUrl;

            Assert.Equal(expectedImageUrl, presenter.PizzaSpecials.ElementAt(i).ImageUrl);
        }

    }
}
