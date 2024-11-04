namespace Northwind.BlazingPizza.GetSpecials.Repositories;
internal class GetSpecialsRepository(GetSpecialsContext context) : IGetSpecialsRepository
{
    public async Task<IEnumerable<PizzaSpecialDto>> GetSpecialsSortedByDescendingPriceAsync() =>
        await context.PizzaSpecials
        .OrderByDescending(s => s.BasePrice)
        .Select(s => new PizzaSpecialDto(
            s.Id, s.Name, s.BasePrice, s.Description, s.ImageUrl))
        .ToListAsync();
}

