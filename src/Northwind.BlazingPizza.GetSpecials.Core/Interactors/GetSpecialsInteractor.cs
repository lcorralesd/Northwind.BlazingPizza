namespace Northwind.BlazingPizza.GetSpecials.Core.Interactors;

internal class GetSpecialsInteractor(
    IGetSpecialsRepository repository,
    IGetSpecialsOutputPort presenter,
    IGetSpecialsCache cache) : IGetSpecialsInputPort
{
    public async Task GetSpecialsAsync()
    {
        var result = await cache.GetSpecialsAsync();
        if (result == null)
        {
            result = await repository.GetSpecialsSortedByDescendingPriceAsync();
            await cache.SetSpecialsAsync(result);
            await presenter.HandleResultAsync(result);
        }
        
        await presenter.HandleResultAsync(result);
    }
}
