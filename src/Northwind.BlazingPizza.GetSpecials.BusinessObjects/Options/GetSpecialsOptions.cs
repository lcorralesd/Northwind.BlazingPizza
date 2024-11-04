namespace Northwind.BlazingPizza.GetSpecials.BusinessObjects.Options;
public class GetSpecialsOptions
{
    public const string SectionKey = nameof(GetSpecialsOptions);
    public string ImageUrlBase { get; set; } = default!;
}
