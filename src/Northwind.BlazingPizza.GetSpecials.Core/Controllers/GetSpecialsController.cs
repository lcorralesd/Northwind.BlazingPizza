namespace Northwind.BlazingPizza.GetSpecials.Core.Controllers;
internal class GetSpecialsController(IGetSpecialsInputPort inputPort, IGetSpecialsOutputPort presenter) : IGetSpecialsController
{
    public async Task<IEnumerable<PizzaSpecialDto>> GetSpecialsAsync()
    {
        await inputPort.GetSpecialsAsync();
        return presenter.PizzaSpecials;
    }
}

