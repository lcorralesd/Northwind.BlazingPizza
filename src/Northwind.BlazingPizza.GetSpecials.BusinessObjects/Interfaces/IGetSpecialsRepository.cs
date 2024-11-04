namespace Northwind.BlazingPizza.GetSpecials.BusinessObjects.Interfaces;
public interface IGetSpecialsRepository
{
    Task<IEnumerable<PizzaSpecialDto>> GetSpecialsSortedByDescendingPriceAsync();
}
