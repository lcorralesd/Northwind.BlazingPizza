namespace Northwind.BlazingPizza.GetSpecials.BusinessObjects.Interfaces;
public interface IGetSpecialsCache
{
    Task SetSpecialsAsync(IEnumerable<PizzaSpecialDto> pizzaSpecials);
    Task<IEnumerable<PizzaSpecialDto>> GetSpecialsAsync();
}
