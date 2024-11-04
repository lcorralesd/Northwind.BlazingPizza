namespace Northwind.BlazingPizza.GetSpecials.BusinessObjects.Interfaces;
public interface IGetSpecialsOutputPort
{
    IEnumerable<PizzaSpecialDto> PizzaSpecials { get; }
    Task HandleResultAsync(IEnumerable<PizzaSpecialDto> pizzaSpecials);
}
