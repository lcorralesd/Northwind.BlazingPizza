namespace Northwind.BlazingPizza.GetSpecials.Core.Presenters;
internal class GetSpecialsPresenter(IOptions<GetSpecialsOptions> options) : IGetSpecialsOutputPort
{
    public IEnumerable<PizzaSpecialDto> PizzaSpecials { get; private set; }

    public Task HandleResultAsync(IEnumerable<PizzaSpecialDto> pizzaSpecials)
    {
        PizzaSpecials = pizzaSpecials.Select(special => new PizzaSpecialDto(
            special.Id,
            special.Name,
            special.BasePrice,
            special.Description,
            $"{options.Value.ImageUrlBase}/{special.ImageUrl}"));

        return Task.CompletedTask;
    }
}
