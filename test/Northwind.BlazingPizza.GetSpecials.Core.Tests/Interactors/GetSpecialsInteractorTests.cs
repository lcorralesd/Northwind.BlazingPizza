namespace Northwind.BlazingPizza.GetSpecials.Core.Tests.Interactors;
public class GetSpecialsInteractorTests
{
    [Fact]
    public async Task GetSpecialsAsync_ShouldInvokeHandleResultAsync_WithPizzaSpecials()
    {
        // Arrange
        var _repository = Substitute.For<IGetSpecialsRepository>();
        var _presenter = Substitute.For<IGetSpecialsOutputPort>();
        var _cache = Substitute.For<IGetSpecialsCache>();

        var _interactor = new GetSpecialsInteractor(_repository, _presenter, _cache);

        var expectedSpecials = new List<PizzaSpecialDto>
        {
            new PizzaSpecialDto(3, "s3", 30, "d3", "i3"),
            new PizzaSpecialDto(4, "s4", 40, "d4", "i4"),
            new PizzaSpecialDto(5, "s5", 50, "d5", "i5")
        };

        _cache.GetSpecialsAsync().Returns(expectedSpecials);

        _repository.GetSpecialsSortedByDescendingPriceAsync().Returns(expectedSpecials);

        // Act
        await _interactor.GetSpecialsAsync();

        // Assert
        await _presenter.Received(1).HandleResultAsync(Arg.Is<IEnumerable<PizzaSpecialDto>>(specials => specials == expectedSpecials));
    }

    [Fact]
    public async Task GetSpeciaslAsync_Should_GetFromCache_When_CacheHasData()
    {
        // Arrange
        var expectedSpecials = new List<PizzaSpecialDto>
        {
            new PizzaSpecialDto(3, "s3", 30, "d3", "i3"),
            new PizzaSpecialDto(4, "s4", 40, "d4", "i4"),
            new PizzaSpecialDto(5, "s5", 50, "d5", "i5")
        };

        var _repository = Substitute.For<IGetSpecialsRepository>();
        var _presenter = Substitute.For<IGetSpecialsOutputPort>();
        var _cache = Substitute.For<IGetSpecialsCache>();

        _cache.GetSpecialsAsync().Returns(expectedSpecials);

        var _interactor = new GetSpecialsInteractor(_repository, _presenter, _cache);

        // Act
        await _interactor.GetSpecialsAsync();

        // Assert
        await _cache.Received(1).GetSpecialsAsync();
        await _repository.DidNotReceive().GetSpecialsSortedByDescendingPriceAsync();
    }

    [Fact]
    public async Task GetSpeciaslAsync_Should_GetFromRepository_When_CacheIsEmpty()
    {
        // Arrange
        var expectedSpecials = new List<PizzaSpecialDto>
        {
            new PizzaSpecialDto(3, "s3", 30, "d3", "i3"),
            new PizzaSpecialDto(4, "s4", 40, "d4", "i4"),
            new PizzaSpecialDto(5, "s5", 50, "d5", "i5")
        };

        var _repository = Substitute.For<IGetSpecialsRepository>();
        var _presenter = Substitute.For<IGetSpecialsOutputPort>();
        var _cache = Substitute.For<IGetSpecialsCache>();

        _cache.GetSpecialsAsync().Returns((IEnumerable<PizzaSpecialDto>)null);
        _repository.GetSpecialsSortedByDescendingPriceAsync().Returns(expectedSpecials);

        var _interactor = new GetSpecialsInteractor(_repository, _presenter, _cache);

        // Act
        await _interactor.GetSpecialsAsync();

        // Assert
        await _cache.Received(1).GetSpecialsAsync();
        await _repository.Received(1).GetSpecialsSortedByDescendingPriceAsync();
        await _cache.Received(1).SetSpecialsAsync(expectedSpecials);
    }
}
