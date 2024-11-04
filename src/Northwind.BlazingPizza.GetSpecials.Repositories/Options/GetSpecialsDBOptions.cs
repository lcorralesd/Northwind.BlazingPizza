namespace Northwind.BlazingPizza.GetSpecials.Repositories.Options;
public class GetSpecialsDBOptions
{
    public const string SectionKey = nameof(GetSpecialsDBOptions);
    public string ConnectionString { get; set; }
}
