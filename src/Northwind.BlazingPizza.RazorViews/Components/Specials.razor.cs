using Microsoft.AspNetCore.Components;
using Northwind.BlazingPizza.ViewModels.GetSpecials;

namespace Northwind.BlazingPizza.RazorViews.Components;
public partial class Specials
{
    [Inject]
    public GetSpecialsViewModel GetSpecialsViewModel { get; set; }

    protected override async Task OnInitializedAsync() =>
        await GetSpecialsViewModel.GetSpecialsAsync();
}